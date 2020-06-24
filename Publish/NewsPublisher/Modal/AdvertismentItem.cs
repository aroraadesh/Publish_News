using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisher.Modal
{
    /// <summary>
    /// 
    /// </summary>
    public class AdvertismentItem
    {
        /// <summary>
        /// 
        /// </summary>

        /// <summary>
        /// 
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AdContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AddCategory AddCategory { get; set; }
    }

    public enum AddCategory
    {
        BeautyProducts,
        SportsAccessories,
        Political
    }


}

