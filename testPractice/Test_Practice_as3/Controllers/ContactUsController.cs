using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Test_Practice_as3.Data;
using Test_Practice_as3.Models;

namespace Test_Practice_as3.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly as3Context _context;

        public ContactUsController(as3Context context)
        {
            _context = context;
        }

        // GET: ContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact.ToListAsync());
        }

        // GET: ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: ContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Topic,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.TimeStamp = DateTime.Now;

                if (!SendEmail(contact))
                {
                    return View("/Views/ContactUs/FailPage.cshtml");
                }

                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Success), contact);
            }
            return View(contact);
        }

        public IActionResult Success(Contact c)
        {

            return View(c);
        }
        private bool SendEmail(Contact contact)
        {
            bool success = false;

            try
            {
                var messageObj = new MimeMessage();
                messageObj.From.Add(new MailboxAddress("Contact Us Form", "harpreetgumbersingh@gmail.com"));
                messageObj.To.Add(new MailboxAddress("MVC Masters bike", "harpreetgumbersingh@gmail.com"));
                messageObj.To.Add(new MailboxAddress(contact.FirstName + " " + contact.LastName, contact.Email));
                messageObj.ReplyTo.Add(new MailboxAddress(contact.FirstName + " " + contact.LastName, contact.Email));

                messageObj.Subject = contact.Topic;
                messageObj.Body = new TextPart("plain")
                {
                    Text = contact.Message
                };

                using var client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("harpreetgumbersingh@gmail.com", "Harpreet123");
                client.Send(messageObj);
                client.Disconnect(true);
                success = true;

            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }

        // GET: ContactUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: ContactUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Email,Topic,Message")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        

        // GET: ContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}
