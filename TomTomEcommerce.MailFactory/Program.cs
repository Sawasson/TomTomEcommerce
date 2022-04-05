using System;
using System.Net;
using System.Net.Mail;
using TomTomEcommerce.Core;

namespace TomTomEcommerce.MailFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mail m = new Mail();
            //m.Name = "Savaş";
            //m.LastName = "Çağlı";
            //m.Email = "sawasson@hotmail.com";
            //m.Title = "Siparişiniz başarıyla oluşturuldu.";
            //m.Message = "239482948 sayılı siparişiniz verildi.Teşekkürler";
            //try
            //{
            //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            //    client.Credentials = new NetworkCredential("sawashadow86@gmail.com", "0258456");
            //    client.EnableSsl = true;
            //    MailMessage msj = new MailMessage();
            //    msj.From = new MailAddress(m.Email, m.Name + " " + m.LastName);
            //    msj.To.Add("sawasson@hotmail.com");
            //    msj.Subject = m.Title + "" + m.Email;
            //    msj.Body = m.Message;
            //    client.Send(msj);
            //}
            //catch (Exception ex)
            //{
            //    var error = ex;
            //}
        }

        //public string MailSender(Mail m)
        //{
        //    try
        //    {
        //        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        //        client.Credentials = new NetworkCredential("sawashadow86@gmail.com", "0258456");
        //        client.EnableSsl = true;
        //        MailMessage msj = new MailMessage();
        //        msj.From = new MailAddress(m.Email, m.Name + " " + m.LastName);
        //        msj.To.Add("sawashadow86@gmail.com");
        //        msj.Subject = m.Title + "" + m.Email;
        //        msj.Body = m.Message;
        //        client.Send(msj);
        //    }
        //    catch (Exception ex)
        //    {
        //        var error = ex;
        //    }
        //    return "OK";
        //}
    }
}
