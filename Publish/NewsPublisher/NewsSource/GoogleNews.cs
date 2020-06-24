using NewsPublisher.Modal;
using NewsPublisher.NewsSource;
using System;
using System.Collections.Generic;

namespace NewsPublisher.Observer
{
    public class GoogleNews : INewsSource
    {
        public Dictionary<string, IObserver> Subscribers = new Dictionary<string, IObserver>();
        public string Register(IObserver subscriber)
        {
            if (!Subscribers.ContainsValue(subscriber))
            {
                string subscriberId = Guid.NewGuid().ToString();
                Subscribers.Add(subscriberId, subscriber);
                return subscriberId;
            }
            else
            {
                throw new Exception("Already subscribed...");
            }
        }

        public void Unregister(string subscriberId)
        {
            if (Subscribers.ContainsKey(subscriberId))
            {
                Subscribers.Remove(subscriberId);
            }
        }

        public void PublishNews(NewsItem news)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Value.Update(news);
            }
        }

        public List<NewsItem> FetchNews(string subscriberId)
        {
            if (Subscribers.ContainsKey(subscriberId))
            {
                return NewsRepository.NewsRepository.GetNews();
            }
            throw new Exception("Please subscribe to get latest news.");
        }
    }
}
