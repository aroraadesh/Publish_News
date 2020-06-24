using NewsPublisher.Modal;
using NewsPublisher.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisher.NewsSource
{
    public interface INewsSource
    {
        /// <summary>
        /// Registers a subscriber for news feed
        /// </summary>
        /// <param name="subscriber"></param>
        /// <returns>Unique subscriber Id for the registered subscriber</returns>
        string Register(IObserver Observer);


        /// <summary>
        /// Unregisters a subscriber from the news feed
        /// </summary>
        /// <param name="subscriberId">subscriber Id to unregister</param>
        void Unregister(string subscriberId);


        /// <summary>
        /// Broadcasts/Pushes new news to all the registered subscribers
        /// </summary>
        /// <param name="news"></param>
        void PublishNews(NewsItem news);

        /// <summary>
        /// Pull mechanism for subscribers to fetch news from the news source.
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        List<NewsItem> FetchNews(string subscriberId);
    }
}
