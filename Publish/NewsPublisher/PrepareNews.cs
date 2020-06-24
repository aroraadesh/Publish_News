using NewsPublisher.Modal;
using NewsPublisher.NewsSource;
using NewsPublisher.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisher
{
    public class PrepareNews : IObserver
    {
        //The news agency has News source(for the sake of demo there's just one, however, could be multiple)
        //Different implementations of News source could be injected at run time via depndency injection.
        //e.g. In unit tests, we could inject a faked/mocked datasource.
        INewsSource NewsSource { get; set; }

        IADSource AdvertisementSource { get; set; }

        List<NewsItem> NewsItems = new List<NewsItem>();

        string subscriberId { get; set; }

        const int maxPageLimit = 8;
        const int maxNewsItemsOnPage = 6;
        public PrepareNews(INewsSource newsSources, IADSource advertisementSource)
        {
            NewsSource = newsSources;
            AdvertisementSource = advertisementSource;
            subscriberId = NewsSource.Register(this);
        }

        public eNewsPaper CompileNewsPaper()
        {
            //Step 1. Fetch all the news from the news source.(This demos the pull mode of the publis-subscribe/observable pattern)
            var newsItems = NewsSource.FetchNews(subscriberId);
            if (newsItems == null || newsItems.Count() <= 0)
            {
                throw new Exception("No news items returned from the news source");
            }
            NewsItems.AddRange(newsItems.OrderBy(n => n.Priority));
            //Step 1.1 Fetch all the ads
            var adds = AdvertisementSource.GetAdvertisment().ToArray();

            //Step 2. Start Compiling newspaper for the fetched news and ads
            var newsPaper = new eNewsPaper
            {
                Name = "The News Express",
                date = DateTime.Now.Date,
                PageList = new List<PageItem>()
            };
            PageItem page = new PageItem();
            newsPaper.PageList.Add(page);
            int advertisementEnumerator = 0;
            foreach (var news in NewsItems)
            {
                if (IsPageFull(page))
                {
                    page = new PageItem();
                    newsPaper.PageList.Add(page);
                }
                if (page.News.Count < maxNewsItemsOnPage)
                {
                    page.News.Add(news);
                }
                else //max news items added to page, now we can accomodate advertisements
                {
                    //Keep adding advertisements to the page till page is full
                    while (!IsPageFull(page) && advertisementEnumerator < adds.Count())
                    {
                        page.Advertisements.Add(adds[advertisementEnumerator]);
                        advertisementEnumerator++;
                    }
                    //Create new page if after adding advertisements, the page is full, else add news to the same page
                    if (IsPageFull(page))
                    {
                        page = new PageItem();
                        newsPaper.PageList.Add(page);
                        page.News.Add(news);
                    }
                    else
                    {
                        page.News.Add(news);
                    }
                }
            }
            //There are still some adds to be placed on the pages
            if (advertisementEnumerator < adds.Count())
            {
                while (advertisementEnumerator < adds.Count())
                {
                    var lastPage = newsPaper.PageList.LastOrDefault();
                    if (!IsPageFull(lastPage))
                    {
                        lastPage.Advertisements.Add(adds[advertisementEnumerator]);
                        advertisementEnumerator++;
                    }
                    else
                    {
                        var newPage = new PageItem();
                        newsPaper.PageList.Add(newPage);
                        newPage.Advertisements.Add(adds[advertisementEnumerator]);
                        advertisementEnumerator++;
                    }
                }
            }
            return newsPaper;
        }

        private bool IsPageFull(PageItem page)
        {
            return page.News.Count + page.Advertisements.Count == maxPageLimit;
        }

        //This is to demo Push model of the publisher-subscriber/observable pattern.
        //Whenever the news source publishes a news, the subscriber will receive the news.
        void IObserver.Update(NewsItem newNews)
        {
            NewsItems.Add(newNews);
        }
    }
}
