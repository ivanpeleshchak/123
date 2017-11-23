using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using MimeKit;
using System.Net.Mail;
using MailKit.Net.Smtp;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        UserContext context;
        public HomeController(UserContext userContext)
        {
            context = userContext;
        }
        public IActionResult Index()
        {
            User model1 = new User();
            return View(model1);
        }
        [HttpPost]
        public IActionResult Index(User model)
        {
            context.Users.Add(model);
            context.SaveChanges();
            SendMail(model);
            return View(new User());
        }
        public void SendMail(User user)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Project", "testprog432@gmail.com"));
            message.To.Add(new MailboxAddress("Test", user.UserMail));
            message.Subject = "Test";
            message.Body = new TextPart("plain")
            {
                Text = "Hello!"
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("testprog432@gmail.com", "20398657");
                client.Send(message);
                client.Disconnect(true);
              
            }
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
