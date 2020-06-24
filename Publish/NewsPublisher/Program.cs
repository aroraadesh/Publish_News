using NewsPublisher.Modal;
using NewsPublisher.NewsSource;
using NewsPublisher.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewsPublisher
{
    public class Program
    {
        static void Main(string[] args)
        {
            var newsSource = new GoogleNews();
            var newsPTISource = new PTINews();
            //var newsInternal = new InternalNews();
            var adSource = new ADSource();
            var newsAgency = new PrepareNews(newsSource, adSource);
            var PTIAgency = new PrepareNews(newsPTISource, adSource);
            //var InternalAgency = new PrepareNews(newsInternal, adSource);

            newsPTISource.PublishNews(new NewsItem
            {
                Title = "Monsoon",
                Priority = Priority.Low,
                Category = Category.Other,
                Body = "Monsoon reached Kerala today, expected heavy rainfall."
            });

            //newsInternal.PublishNews(new NewsItem
            //{
            //    Title = "Maharashra on risk",
            //    Priority = Priority.High,
            //    Category = Category.Other,
            //    Body = "Covid -19 Cases in Marashtra is incresing very fast."
            //});


            var newsPaper = newsAgency.CompileNewsPaper();
            newsPaper = PTIAgency.CompileNewsPaper();
            //newsPaper = InternalAgency.CompileNewsPaper();

            Console.WriteLine("--------------" + newsPaper.Name + "-" + newsPaper.date.ToShortDateString() + "-----------------");
            int pageNumber = 1;
            foreach (var page in newsPaper.PageList)
            {
                Console.WriteLine("-----Page -" + pageNumber + "--------");
                foreach (var news in page.News)
                {
                    Console.WriteLine(news.Title);
                    Console.WriteLine(news.Body);
                    Console.WriteLine("-----------------------------------");
                }
                Console.WriteLine("----------Advertisements Section-------------------");
                foreach (var add in page.Advertisements)
                {
                    Console.WriteLine(add.Product);
                    Console.WriteLine(add.AdContent);
                    Console.WriteLine("-----------------------------------");
                }
                pageNumber++;
            }
            Console.ReadLine();
        }
    }
}
