using NewsPublisher.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisher.NewsRepository
{
    public static class NewsRepository
    {
        public static List<NewsItem> GetNews()
        {
            var news = new List<NewsItem>()
            {
                new NewsItem
                {
                    Title = "Unlock 1.0",
                    Category = Category.Political,
                    Body = "Maharashtra CMO issues guidelines for Unlock 1.0 after Central government’s instructions.",
                    Priority = Priority.High
                },
                new NewsItem
                {
                    Title = "Madhya Pradesh CM to Resigned",
                    Category = Category.Political,
                    Body = "MP CM resigned today just before confidence motion.",
                    Priority = Priority.High
                },
                new NewsItem
                {
                    Title = "Air Travel to be resumed in ",
                    Category = Category.Travel,
                    Body = "Airports are getting ready for first flight after lockdown.",
                    Priority = Priority.Medium
                },
                new NewsItem
                {
                    Title = "India Women enters final",
                    Category = Category.Sports,
                    Body = "Indian womens cricket team enters maiden T20 final.",
                    Priority = Priority.High
                },
                new NewsItem
                {
                    Title = "Bus Operator demanded compensation",
                    Category = Category.Travel,
                    Body = "Bus Operator demanded compensation for the loss because of Lockdown.",
                    Priority = Priority.Low
                },
                new NewsItem
                {
                    Title = "A 16 year old Indian girl tops ICC rankings",
                    Category = Category.Sports,
                    Body = "Indias 16 year old rising sensastion tops ICC ranking for T20 batters after scoring heavily in the ICC world cup tournment",
                    Priority = Priority.Medium
                },
                new NewsItem
                {
                    Title = "Virat kohli to play Ranji",
                    Category = Category.Sports,
                    Body = "Virat Kohli decided to play a Ranji match from his side.",
                    Priority = Priority.Low
                },
                new NewsItem
                {
                    Title = "India - China to discussion",
                    Category = Category.Other,
                    Body= "After despute over galwan, India - china to meet to discuss the issues.",
                    Priority = Priority.Medium
                }
            };
            return news;
        }
    }
}
