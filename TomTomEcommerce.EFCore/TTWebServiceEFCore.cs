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


        //public void CartTotalPrice()
        //{
        //    var entity = dbContext.CartProducts.Where(x => x.CartId == 6).ToList();

        //    foreach (var item in entity)
        //    {
        //        var price = (item.Product.Price) * (item.Quantity);
        //        double total = 0;
        //        total = total + price;
        //        var cart = GetCart();
        //        cart.TotalPrice = total;
        //    }
            

        //}


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

    }
}
