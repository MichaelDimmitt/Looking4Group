using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Looking4Group.Data;
using Looking4Group.Models;
using BCrypt.Net;

namespace Looking4Group.Controllers
{
    public class LoginController : Controller
    {
        private readonly Looking4GroupContext _context;

        public LoginController(Looking4GroupContext context)
        {
            _context = context;    
        }

        // GET: Login
        public IActionResult Index()
        {
            return View();
        }

        // Login and setup a session ID
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("UserID,Username,Password")] User user)
        {
            if (user != null)
            {
                if (user.Password != null && user.Username != null)
                {
                    if (ValidateUser(user))
                    {
                        return View("Questions");
                    }
                    ViewBag.ErrorMessage = "The user name or password provided is incorrect.";
                    return View(user);
                }
            }
            return View(user);
        }

        // GET: Login/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserID,Username,Password,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                //Check to see if username is already taken
                if(!_context.Users.Any(m => m.Username == user.Username))
                {
                    //Generate salt and hash password for storage
                    user.PasswordSalt = BCrypt.Net.BCrypt.GenerateSalt();
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, user.PasswordSalt);

                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.ErrorMessage = "The user name you selected has already been taken.";
            }
            return View(user);
        }

        // GET: Login/Create
        public async Task<IActionResult> Questions()
        {
            return View(await _context.Questions.ToListAsync());
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }

        private bool ValidateUser(User clientUser)
        {
            User user = _context.Users.SingleOrDefault(m => m.Username.Equals(clientUser.Username));

            //Does the user actually exist?
            if (user != null)
            {
                //Validate password
                String hashedPWD = BCrypt.Net.BCrypt.HashPassword(clientUser.Password, user.PasswordSalt);
                if (hashedPWD.Equals(user.Password))
                {
                    HttpContext.Session.Set("UserID", BitConverter.GetBytes(user.UserID));
                    return true;
                }
            }

            return false;
        }
    }
}
