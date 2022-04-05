using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomTomEcommerce.Core;

namespace TomTomEcommerce.EFCore
{

    public class TTWebServiceEFCore
    {
        private TTContext dbContext { get; set; }

        public TTWebServiceEFCore (TTContext tTContext)
        {
            this.dbContext = tTContext;
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            var entity = dbContext.Products.Where(x => x.CategoryId == id).ToList();
            return entity;
        }

        public List<Product> ListProduct()
        {
            var entity = dbContext.Products
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .ToList();
            return entity;
        }

        public List<Category> ListCategory()
        {
            var entity = dbContext.Categories.ToList();
            return entity;
        }

        public Product GetProduct(int id)
        {
            var entity = dbContext.Products.Find(id);
            return entity;
        }

        public Category GetCategory(int id)
        {
            var entity = dbContext.Categories.Find(id);
            return entity;
        }


        public Cart GetCart(int userId)
        {
            var entity = dbContext.Carts.Where(x=>x.UserID==userId).SingleOrDefault();
            return entity;
        }

        public CartProduct GetCartProduct(int id)
        {
            var entity = dbContext.CartProducts.Where(x=>x.ProductId == id).FirstOrDefault();
            return entity;
        }

        public void PlusCartProduct(int id)
        {
            var entity = dbContext.CartProducts.Find(id);
            entity.Quantity++;
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }


        public void MinusCartProduct(int id)
        {
            
            var entity = dbContext.CartProducts.Find(id);
            entity.Quantity--;

            if (entity.Quantity == 0)
            {
                dbContext.Remove(entity);
            }
            else
            {
                dbContext.Update(entity);
            }
            dbContext.SaveChanges();
        }

        public void AddProductToCart(int productId, int userId)
        {
            var anyCart = dbContext.Carts.Where(x => x.UserID == userId).SingleOrDefault();
            if (anyCart==null)
            {
                Cart cart = new Cart();
                cart.UserID = userId;
                dbContext.Carts.Add(cart);
                dbContext.SaveChanges();

                CartProduct cartProduct = new CartProduct();
                cartProduct.ProductId = productId;
                cartProduct.Quantity = 1;
                cartProduct.CartId = cart.Id;
                dbContext.CartProducts.Add(cartProduct);
            }
            else
            {
                var entity = GetCartProduct(productId);
                if (entity == null)
                {
                    CartProduct cartProduct = new CartProduct();
                    cartProduct.ProductId = productId;
                    cartProduct.Quantity = 1;
                    Cart cart = dbContext.Carts.Where(x => x.UserID == userId).SingleOrDefault();
                    cartProduct.CartId = cart.Id;
                    dbContext.CartProducts.Add(cartProduct);
                }
                else
                {
                    entity.Quantity++;
                }
            }
            

            dbContext.SaveChanges();
        }

        public void DeleteAdress(int id)
        {
            var entity = dbContext.Adresses.Find(id);
            dbContext.Adresses.Remove(entity);
            dbContext.SaveChanges();
        }

        public void NewOrder(int adressId, int userId)
        {
            Order order = new Order();
            order.AdressId = adressId;
            order.OrderDate = DateTime.Now;
            order.cartProducts = CartProductListByCartId(userId);
            double totalPrice = 0;
            foreach (var item in order.cartProducts)
            {
                double totalProductPrice = item.Product.Price * item.Quantity;
                totalPrice = totalPrice + totalProductPrice;
            }

            order.TotalPrice = totalPrice;
            order.UserId = userId;
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            var orderId = dbContext.Orders.Where(x => x.OrderDate == order.OrderDate).FirstOrDefault().Id;
            RabbitMQ.Publisher.Publish("order",orderId);

            foreach (var item in order.cartProducts)
            {
                item.OrderId = orderId;
                dbContext.SaveChanges();
            }

            var cart = dbContext.Carts.Where(x => x.UserID == userId).SingleOrDefault();
            dbContext.Remove(cart);
            dbContext.SaveChanges();


        }

        public List<Order> OrderList(int userId)
        {
            var entity = dbContext.Orders.Where(x => x.UserId == userId)
                .Include(x=>x.Adress)
                .Include(x => x.Adress.District)
                .Include(x => x.Adress.City)
                .Include(x=>x.User)
                .ToList();


            foreach (var item in entity)
            {
                var cartProductList = dbContext.CartProducts.Where(x => x.OrderId == item.Id)
                    .Include(x => x.Product)
                    .Include(x => x.Product.ProductImages)
                    .ToList();
                item.cartProducts = cartProductList;
            }
            return entity;

           

        }




        public List<CartProduct> CartProductListByCartId(int userId)
        {
            var anyCart = dbContext.Carts.Where(x => x.UserID == userId).SingleOrDefault();

            if (anyCart==null)
            {
                return null;
            }
            else
            {
                var entity = dbContext.CartProducts.Where(x => x.CartId == anyCart.Id)
                .Include(x => x.Product.ProductImages)
                .ToList();
                return entity;
            }
            
        }


        public void ClearCart(int userId)
        {
            var entity = GetCart(userId);
            var cartProducts = dbContext.CartProducts.Where(x => x.CartId == entity.Id).ToList();
            foreach (var cartProduct in cartProducts)
            {
                dbContext.Remove(cartProduct);
            }
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public void AddAdress(Adress adress)
        {
            dbContext.Add(adress);
            dbContext.SaveChanges();
        }

        public List<Adress> ListAdresses(int userId)
        {
            var entity = dbContext.Adresses.Where(x => x.UserId == userId)
                .Include(x => x.City)
                .Include(x => x.District)
                .ToList();

            return entity;
        }
    }
}
