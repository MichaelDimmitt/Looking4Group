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

            //Create the questions
            var questions = new Question[]
            {
                new Question{DefaultQuestion=true, Title="What is your preffered genre?", Answer1="MOBA ie. DotA, League of Lengends, Smite", Answer2="RTS ie. Starcraft, Age of Empires, etc.", Answer3="FPS ie. Counter Strike, Overwatch, Battlefront", Answer4="Other", Tags=new List<QuestionTag>()},
                new Question{DefaultQuestion=true, Title="How do you feel about multiplayer?", Answer1="Competitive!!", Answer2="Casual", Answer3="I like Co-Op", Answer4="What's multiplayer?", Tags=new List<QuestionTag>()},
                new Question{DefaultQuestion=true, Title="What type of group if any are you looking for?", Answer1="Large Guild", Answer2="Small Guild/Group", Answer3="Small group of friends", Answer4="Just looking for someone to play games with.", Tags=new List<QuestionTag>()},
                new Question{DefaultQuestion=true, Title="Which of these games appeals the most to you?", Answer1="Rocket League", Answer2="Kerbal Space Program", Answer3="World of Warcraft", Answer4="Ovewrwatch", Tags=new List<QuestionTag>()}
            };

            foreach (Question q in questions)
            {
                context.Questions.Add(q);
            }
            context.SaveChanges();

            //Create the tags for the questions
            var tags = new QuestionTag[]
            {
                new QuestionTag{Label="MOBA"},
                new QuestionTag{Label="FPS"},
                new QuestionTag{Label="RTS"},
                new QuestionTag{Label="Competitve"},
                new QuestionTag{Label="Casual"},
                new QuestionTag{Label="Co-Op"},
                new QuestionTag{Label="Solo"},
                new QuestionTag{Label="LargeGuild"},
                new QuestionTag{Label="SmallGuild"},
                new QuestionTag{Label="Friends"},
                new QuestionTag{Label="Partner"},
                new QuestionTag{Label="Sports"},
                new QuestionTag{Label="Sandbox"},
                new QuestionTag{Label="MMO"},
                new QuestionTag{Label="FPS"}
            };
            foreach(QuestionTag q in tags)
            {
                context.QuestionTags.Add(q);
            }
            context.SaveChanges();

            //Question 1
            AddOrUpdateQustion(context, 1, 1);
            AddOrUpdateQustion(context, 1, 3);
            AddOrUpdateQustion(context, 1, 2);

            //Question 2
            AddOrUpdateQustion(context, 2, 4);
            AddOrUpdateQustion(context, 2, 5);
            AddOrUpdateQustion(context, 2, 6);
            AddOrUpdateQustion(context, 2, 7);

            //Question 3
            AddOrUpdateQustion(context, 3, 8);
            AddOrUpdateQustion(context, 3, 9);
            AddOrUpdateQustion(context, 3, 10);
            AddOrUpdateQustion(context, 3, 11);

            //Question 4
            AddOrUpdateQustion(context, 4, 12);
            AddOrUpdateQustion(context, 4, 13);
            AddOrUpdateQustion(context, 4, 14);
            AddOrUpdateQustion(context, 4, 15);

            context.SaveChanges();
        }

        private static void AddOrUpdateQustion(Looking4GroupContext context, int questionID, int tagID)
        {
            var question = context.Questions.SingleOrDefault(q => q.QuestionID == questionID);
            var tag = question.Tags.SingleOrDefault(t => t.TagID == tagID);
            if(tag == null)
            {
                question.Tags.Add(context.QuestionTags.Single(t => t.TagID == tagID));
            }
        }
    }
}
