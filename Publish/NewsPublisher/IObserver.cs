using NewsPublisher.Modal;
using System;
using System.Collections.Generic;

namespace NewsPublisher.Observer
{
    public interface IObserver
    {
        void Update(NewsItem newsItem);
    }
}
