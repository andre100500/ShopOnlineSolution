using ShopOnline.Api.Entites;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductCategoryDto> ConvertToDto(this IEnumerable<ProductCategory> productCategories)
        {
            return (from productCategory in productCategories
                    select new ProductCategoryDto
                    {
                        Id = productCategory.Id,
                        Name = productCategory.Name,
                        IconCSS = productCategory.IconCSS,
                    }).ToList();
        }
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products)
        {
            return (from product in products
                    select new ProductDto
                    {
                        Id=product.Id,
                        Name=product.Name,
                        CategoryId=product.ProductCategory.Id,
                        CategoryName=product.ProductCategory.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty =product.Qty
                    }).ToList();
        }
        public static ProductDto ConvertToDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.ProductCategory.Id,
                Qty = product.Qty,
                Price = product.Price,
                ImageURL=product.ImageURL,
                Description = product.Description,  
                CategoryName = product.ProductCategory.Name
            };
        }
        public static CartItemDto ConvertToDto(this CartItem cartItem,
                                               Product product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                Price = product.Price,
                CartId = cartItem.CartId,
                ProductDescription = product.Description,
                ProductId = product.Id,
                ProductImageURL = product.ImageURL,
                ProductName = product.Name,
                Qty = cartItem.Qty,
                TotalPrice = product.Price + cartItem.Qty
            };
        }
    }
}
