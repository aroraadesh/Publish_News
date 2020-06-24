using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPublisher.Modal;
using NewsPublisher.NewsRepository;

namespace NewsPublisher.NewsSource
{
    public class ADSource : IADSource
    {
        public List<AdvertismentItem> GetAdvertisment()
        {
            return ADRepository.GetAdds();
        }
    }
}
