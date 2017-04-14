using Looking4Group.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Looking4Group.Data
{
    public class DbInitializer
    {
        public static void Initialize(Looking4GroupContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users
            if (context.Users.Any())
            {
                return; //DB has been seeded
            }

            

            var users = new User[]
            {
                new User{Username="ckchessmaster", Password="testpwd",PasswordSalt="testSalt", Email="ckgiveout@gmail.com"},
                new User{Username="bob", Password="testpwd",PasswordSalt="testSalt", Email="bob@gmail.com"}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var test = new UserTag { UserID = 1, Label = "FPS", Weight = 7 };
            context.UserTags.Add(test);

            context.SaveChanges();
        }
    }
}
