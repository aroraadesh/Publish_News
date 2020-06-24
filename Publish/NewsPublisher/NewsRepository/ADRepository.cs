using NewsPublisher.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublisher.NewsRepository
{
    public static class ADRepository
    {
        public static List<AdvertismentItem> GetAdds()
        {
            var adds = new List<AdvertismentItem>
            {
                new AdvertismentItem
                {
                    Product = "Beauty soap",
                    AddCategory = AddCategory.BeautyProducts,
                    AdContent = "This is a beautiful soap with excellent aroma to make you feel refreshed."
                },
                new AdvertismentItem
                {
                    Product = "Vote for BPP",
                    AddCategory = AddCategory.Political,
                    AdContent = "Vote for BPP as we are working day in and day out to make our country extremely powerful."
                },
                 new AdvertismentItem
                {
                    Product = "Gym Accessories",
                    AddCategory = AddCategory.SportsAccessories,
                    AdContent = "A brand can be trusted."
                }
            };
            return adds;
        }

    }
}
