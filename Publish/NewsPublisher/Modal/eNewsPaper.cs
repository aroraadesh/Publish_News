using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisher.Modal
{
    public class eNewsPaper
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PageItem> PageList { get; set; }
    }
}
