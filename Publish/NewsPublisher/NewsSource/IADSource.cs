using NewsPublisher.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisher.NewsSource
{
    public interface IADSource
    {
        List<AdvertismentItem> GetAdvertisment();
    }
}
