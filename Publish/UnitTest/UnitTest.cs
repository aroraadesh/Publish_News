using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPublisher;
using NewsPublisher.Modal;
using NewsPublisher.NewsSource;
using NewsPublisher.Observer;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private INewsSource testGoogleNewsSource;
        private IADSource testAdSource;
        private PrepareNews newsAgency { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            testGoogleNewsSource = new GoogleNews();
            testAdSource = new ADSource();
            newsAgency = new PrepareNews(testGoogleNewsSource, testAdSource);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewsSourceReturningNewsItems_Succeds()
        {
            var newsPaper = newsAgency.CompileNewsPaper();
            //Assert
            Assert.IsNotNull(newsPaper);
            Assert.IsTrue(newsPaper.PageList.Count >= 1);
            Assert.IsTrue(newsPaper.PageList[0].News.Count >= 1);
            Assert.IsTrue(newsPaper.PageList[0].Advertisements.Count >= 1);
        }



        private List<NewsItem> GetNewsItems()
        {
            var news = new List<NewsItem>()
            {
                new NewsItem
                {
                    Title = "Test Political Headline",
                    Category = Category.Political,
                    Body = "This is political news content for test purpose",
                    Priority = Priority.High
                },
                new NewsItem
                {
                    Title = "Test Finance Headline",
                    Category = Category.Other,
                    Body = "This is financial news content for test purpose",
                    Priority = Priority.High
                }
            };
            return news;
        }

        private List<AdvertismentItem> GetAds()
        {
            var adds = new List<AdvertismentItem>
            {
                new AdvertismentItem
                {
                    Product = "Test beauty product",
                    AddCategory = AddCategory.BeautyProducts,
                    AdContent = "This is a test beauty product"
                },
                new AdvertismentItem
                {
                    Product = "Test political banner",
                    AddCategory = AddCategory.Political,
                    AdContent = "This is a test political add"
                }
            };
            return adds;
        }
    }
}
