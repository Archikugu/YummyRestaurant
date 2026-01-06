using YummyRestaurant.Application.DTOs.CategoryDTOs;
using YummyRestaurant.Application.DTOs.ProductDTOs;

namespace YummyRestaurant.WebUI.Models
{
    public class MenuViewModel
    {
        public List<ResultCategoryDto> Categories { get; set; }
        public List<ResultProductDto> Products { get; set; }
    }
}
