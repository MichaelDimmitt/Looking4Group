using Looking4Group.Libraries;
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

            if(context.Questions.Any())
            {
                return; //DB already seeded
            }

            //Q1
            var q = new Question { DefaultQuestion = true, Title = "What is your preffered genre?", Answer1 = "MOBA ie. DotA, League of Lengends, Smite", Answer2 = "RTS ie. Starcraft, Age of Empires, etc.", Answer3 = "FPS ie. Counter Strike, Overwatch, Battlefront", Answer4 = "Other" };
            context.Questions.Add(q);
            context.SaveChanges();

            var qt = new QuestionTag { Label = "MOBA", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "FPS", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "RTS", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            //Q2
            q = new Question { DefaultQuestion = true, Title = "How do you feel about multiplayer?", Answer1 = "Competitive!!", Answer2 = "Casual", Answer3 = "I like Co-Op", Answer4 = "What's multiplayer?" };
            context.Questions.Add(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "Competitve", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "Casual", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "Co-Op", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "Solo", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            //Q3
            q = new Question { DefaultQuestion = true, Title = "What type of group if any are you looking for?", Answer1 = "Large Guild", Answer2 = "Small Guild/Group", Answer3 = "Small group of friends", Answer4 = "Just looking for someone to play games with." };
            context.Questions.Add(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "LargeGuild", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "SmallGuild", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "Friends", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "Partner", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            //Q4
            q = new Question { DefaultQuestion = true, Title = "Which of these games appeals the most to you?", Answer1 = "Rocket League", Answer2 = "Kerbal Space Program", Answer3 = "World of Warcraft", Answer4 = "Ovewrwatch" };
            context.Questions.Add(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "Sports", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "Sandbox", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "MMO", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            qt = new QuestionTag { Label = "FPS", Question = q };
            context.QuestionTags.Add(qt);
            q.Tags.Add(qt);
            context.Questions.Update(q);
            context.SaveChanges();

            //Add a test groups
            //Group 1
            var g = new Group { Name = "UpAllNight", Link = "http://www.upallnight.com", Description = "Casual group of friends who like to play games. Come join us we play just about everything!" };
            context.Groups.Add(g);
            context.SaveChanges();

            var gt = new GroupTag { Label = "Casual", Weight = 25, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Friends", Weight = 50, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "FPS", Weight = 20, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Sandbox", Weight = 10, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            //Group 2
            g = new Group { Name = "MLG", Link = "http://www.mlg.com", Description = "Highly competitive group. Think you got what it takes?" };
            context.Groups.Add(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Competitve", Weight = 100, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "SmallGuild", Weight = 50, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "FPS", Weight = 75, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "RTS", Weight = 30, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            //Group 3
            g = new Group { Name = "Noob", Link = "http://www.noob.com", Description = "Clan noob is a friendly envirnment for people looking to get a jumpstart into Eve! We welcome everyone no matter your skill!" };
            context.Groups.Add(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Casual", Weight = 66, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "LargeGuild", Weight = 100, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "MMO", Weight = 100, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            //Group 4
            g = new Group { Name = "42", Link = "http://www.42.com", Description = "The answer to everything, especially rocket league! Come join us for some awesome high speed action! Comp, Casual, doesn't matter!" };
            context.Groups.Add(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Casual", Weight = 35, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "LargeGuild", Weight = 100, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Sports", Weight = 80, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Competitive", Weight = 40, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            //Group 5
            g = new Group { Name = "Match.Gamer", Link = "http://www.coop.com", Description = "Do you like co-op? Do you prefer to just play with a small group of 1 or 2 friends? This is the place for you! Join us and we'll match you up with someone to play with!" };
            context.Groups.Add(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Casual", Weight = 75, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Partner", Weight = 60, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Co-Op", Weight = 80, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            gt = new GroupTag { Label = "Friends", Weight = 40, Group = g };
            context.GroupTags.Add(gt);
            g.Tags.Add(gt);
            context.Groups.Update(g);
            context.SaveChanges();

            //Add test games
            //Game 1
            var game = new Game
            {
                Name = "Counter-Strike: Global Offensive", Description= "Counter-Strike: Global Offensive (CS: GO) will expand upon the team-based action gameplay that it pioneered when it was launched 14 years ago. " +
                "CS: GO features new maps, characters, and weapons and delivers updated versions of the classic CS content(de_dust, etc.).In addition, CS: GO will introduce new gameplay modes, matchmaking, leader boards, and more.",
                Link= "http://store.steampowered.com/app/730/"
            };
            context.Games.Add(game);
            context.SaveChanges();

            var gameTag = new GameTag { Label = "Competitive", Weight = 70, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "FPS", Weight = 100, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Team-Based", Weight = 80, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            //Game 2
            game = new Game
            {
                Name = "Overwatch",
                Description = "Overwatch is a team-based multiplayer first-person shooter video game developed and published by Blizzard Entertainment. It was released in May 2016 for Microsoft Windows, PlayStation 4, and Xbox One.",
                Link = "https://playoverwatch.com/en-us/"
            };
            context.Games.Add(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Team-Based", Weight = 90, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "FPS", Weight = 100, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Casual", Weight = 40, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            //Game 3
            game = new Game
            {
                Name = "Minecraft",
                Description = "Minecraft is a game about placing blocks and going on adventures",
                Link = "https://minecraft.net/en-us/"
            };
            context.Games.Add(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Sandbox", Weight = 90, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Casual", Weight = 50, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Solo", Weight = 60, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Co-Op", Weight = 20, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            //Game 4
            game = new Game
            {
                Name = "League of Legends",
                Description = "Minecraft is a game about placing blocks and going on adventures",
                Link = "https://minecraft.net/en-us/"
            };
            context.Games.Add(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "MOBA", Weight = 100, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Casual", Weight = 60, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Competitive", Weight = 50, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Co-Op", Weight = 5, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            //Game 5
            game = new Game
            {
                Name = "Rocket League",
                Description = "Soccer meets driving once again in the long-awaited, physics-based multiplayer-focused sequel to Supersonic Acrobatic Rocket-Powered Battle-Cars! Choose a variety of high-flying vehicles equipped with huge rocket boosters to score amazing aerial goals and pull-off incredible game-changing saves!",
                Link = "http://store.steampowered.com/app/252950/"
            };
            context.Games.Add(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Sports", Weight = 100, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Casual", Weight = 60, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Competitive", Weight = 60, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            //Game 6
            game = new Game
            {
                Name = "EVE Online",
                Description = "Explore. Build. Conquer. A limitless universe awaits you! EVE is Free · Every Journey Is Unique · Every Decision Counts · EVE Is People · EVE Is Challenging In Terms Of Scale And Substance There's Nothing Like It",
                Link = "https://www.eveonline.com/"
            };
            context.Games.Add(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "MMO", Weight = 100, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Casual", Weight = 20, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();

            gameTag = new GameTag { Label = "Competitive", Weight = 30, Game = game };
            context.GameTags.Add(gameTag);
            game.Tags.Add(gameTag);
            context.Games.Update(game);
            context.SaveChanges();
        }
    }
}
