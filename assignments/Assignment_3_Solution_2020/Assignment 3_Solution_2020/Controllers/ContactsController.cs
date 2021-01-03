using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Net;

namespace Milestone_4A.Models {
    public class ContactsController : Controller {
        private readonly Milestone_4AContext _context;

        public ContactsController(Milestone_4AContext context) {
            _context = context;
        }

        // GET: Contacts
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact([Bind("FirstName", "LastName", "Email", "Topic", "Message", "PostalCode", "Phone")] Contact contact, string token) {

            if (ModelState.IsValid)     //Backend validation
            {
                string verify = "https://www.google.com/recaptcha/api/siteverify";
                string secret = "6Ld9oMIUAAAAACSXYibqE0pRkwmb05P_PGfNRMy_";

                string data = $"secret={secret}&response={token}";

                // Check with reCaptcha
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.UploadString(verify, data);
                    dynamic json = JObject.Parse(HtmlResult);
                    if (json["success"] == "false")
                    {
                        return View("/Views/Contacts/Failure.cshtml", json["error-codes"]);
                    }
                }

                if (! SendEmail(contact))
                {
                    return View("/Views/Contacts/Failure.cshtml");
                }

                contact.TimeStamp = DateTime.Now;       //sets the current date and time before adding to the db

                _context.Add(contact);                  //add info in the db
                _context.SaveChanges();                 //commit changes
                return RedirectToAction(nameof(Success), contact);
            }
            return View();
        }

        private bool SendEmail(Contact contact)
        {
            bool success = false; 

            try
            {
                // Send the email
                var messageObj = new MimeMessage();
                messageObj.From.Add(new MailboxAddress("We Sell Bikes", "YOUREMAIL@gmail.com"));
                messageObj.To.Add(new MailboxAddress("We Sell Bikes", "YOUREMAIL@gmail.com"));
                messageObj.To.Add(new MailboxAddress(contact.FirstName + " " + contact.LastName, contact.Email));
                messageObj.ReplyTo.Add(new MailboxAddress(contact.FirstName + " " + contact.LastName, contact.Email));

                messageObj.Subject = contact.Topic;
                messageObj.Body = new TextPart("plain")
                {
                    Text = contact.Message
                };

                using var client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("YOUREMAIL@gmail.com", "REPLACEPASSWORD");
                client.Send(messageObj);
                client.Disconnect(true);
                success = true;
            }
            catch (Exception ex)
            {   
                //There is room for improvement here 
                success = false;             
            }

            return success;
        }

        public IActionResult Success (Contact c) {
            return View(c);
        }
    }
}
