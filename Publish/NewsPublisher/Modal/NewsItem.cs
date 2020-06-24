using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisher.Modal
{
    public class NewsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title {get; set;}
        /// <summary>
        /// 
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Priority Priority { get; set; }

    }

    public enum Category
    {
        Political,
        Sports,
        Travel,
        Other
    }

    public enum Priority
    {
        High,
        Medium,
        Low
    }
}
