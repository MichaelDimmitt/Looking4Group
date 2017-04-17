using Looking4Group.Data;
using Looking4Group.Libraries;
using Looking4Group.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;


using BCrypt.Net;
using System.Collections.Generic;

namespace Looking4Group.Controllers
{
    public class LoginController : Controller
    {
        public String SelectedAnswer { get; set; }

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
                        return RedirectToAction("Index", "Home");
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
                    user.UserTags = new List<UserTag>();
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.Set("UserID", BitConverter.GetBytes(user.UserID));
                    return View("Questions");
                }
                ViewBag.ErrorMessage = "The user name you selected has already been taken.";
            }
            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Account()
        {
            return View(Globals.GetUser(_context, HttpContext));
        }

        // GET: Login/Create
        public IActionResult Questions()
        {
            var questions = _context.Questions.Where(q => q.DefaultQuestion == true).ToList();
            HttpContext.Session.Set("State", BitConverter.GetBytes(0));
            return View(questions);
        }

        [HttpPost, ActionName("Questions")]
        public IActionResult BeginQuestions()
        {
            var questions = _context.Questions.Where(q => q.DefaultQuestion == true).ToList();

            //Get current page state
            int state = 0;
            byte[] outVal;
            if (HttpContext.Session.TryGetValue("State", out outVal))
            {
                state = BitConverter.ToInt32(outVal, 0);
            } else
            {
                HttpContext.Session.Set("State", BitConverter.GetBytes(state));
            }
            

            //If an answer was submitted add it to the user
            int answerNumber;
            if(Int32.TryParse(Request.Form["answer"], out answerNumber))
            {
                //Get get user
                byte[] idOutVal;
                HttpContext.Session.TryGetValue("UserID", out idOutVal);
                int userID = BitConverter.ToInt32(idOutVal, 0);
                User user = _context.Users.SingleOrDefault(u => u.UserID == userID);

                //Create new user tag
                List<QuestionTag> tags = _context.QuestionTags.Where(qt => qt.QuestionID == questions[state-1].QuestionID).ToList();
                //Ensure we don't get an out of bounds error
                if (answerNumber < tags.Count)
                {
                    UserTag tag = new UserTag { Label = tags[answerNumber].Label, Weight = 80, UserID = userID };
                    _context.UserTags.Add(tag);
                    _context.SaveChanges();

                    //Add user tag to the user
                    user.UserTags.Add(tag);
                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
            }
 
            HttpContext.Session.Set("State", BitConverter.GetBytes(++state));

            return View(questions);
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
        }//end Validate User
    }
}
