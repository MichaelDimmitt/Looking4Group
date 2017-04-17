using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Looking4Group.Data;
using Looking4Group.Models;
using Looking4Group.Libraries;

namespace Looking4Group.Controllers
{
    public class GameSearchController : Controller
    {
        private readonly Looking4GroupContext _context;

        public GameSearchController(Looking4GroupContext context)
        {
            _context = context;    
        }

        // GET: GameSearch
        public IActionResult Index()
        {
            //Check for a user
            User user = Globals.GetUser(_context, HttpContext);
            if(user == null)
            {
                return View();
            }
            //Get users tags
            List<UserTag> uTags = _context.UserTags.Where(t => t.UserID == user.UserID).ToList();

            //Weed out low value tags
            foreach (UserTag tag in uTags)
            {
                if (tag.Weight < 70)
                {
                    uTags.Remove(tag);
                }
            }

            //Get list of game tags based on user tags
            List<GameTag> gTags = new List<GameTag>();
            foreach (UserTag tag in uTags)
            {
                gTags.AddRange(_context.GameTags.Where(gt => gt.Label.Equals(tag.Label)));
            }
            //Get dupes in descending order
            var dupes = gTags.GroupBy(x => x.GameID).Select(x => new { Count = x.Count(), Name = x.Key, ID = x.First().GameID }).OrderByDescending(x => x.Count);

            //Search for group with most corresponding IDs
            var model = _context.Games.SingleOrDefault(g => g.GameID == dupes.First().ID);

            return View(model);
        }

        public async Task<IActionResult> Game(int id)
        {
            var model = await _context.Games.SingleOrDefaultAsync(g => g.GameID == id);
            return View(model);
        }

        public IActionResult Info(Game game)
        {
            return View(game);
        }
    }
}
