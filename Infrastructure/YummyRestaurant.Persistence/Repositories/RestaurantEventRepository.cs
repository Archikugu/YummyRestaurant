using YummyRestaurant.Application.Abstract;
using YummyRestaurant.Domain.Entities;
using YummyRestaurant.Persistence.Context;

namespace YummyRestaurant.Persistence.Repositories
{
    public class RestaurantEventRepository : GenericRepository<RestaurantEvent>, IRestaurantEventRepository
    {
        public RestaurantEventRepository(YummyRestaurantContext context) : base(context)
        {
        }
    }
}
