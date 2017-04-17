using Looking4Group.Data;
using Looking4Group.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Looking4Group.Libraries
{
    /// <summary>
    /// This is a temporary class for demonstration purposes only!!!
    /// In the future all of these variables will be moved somewhere more appropriate and are only here for
    /// showcasing the website. These variables persist across all clients who connect to the website which
    /// for obvious reasons is undeseriable and needs to be fixed.
    /// </summary>
    public static class Globals
    {
        public static User GetUser(Looking4GroupContext context, HttpContext httpContext)
        {
            byte[] outVal;
            if(httpContext.Session.TryGetValue("UserID", out outVal))
            {
                return context.Users.SingleOrDefault(u => u.UserID == BitConverter.ToInt32(outVal, 0));
            }

            return null;
        }
    }
}
