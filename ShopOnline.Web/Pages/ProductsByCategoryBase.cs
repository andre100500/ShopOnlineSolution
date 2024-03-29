﻿using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductsByCategoryBase: ComponentBase
    {
        [Parameter]
        public int CategoryId { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IManageProductsLocalStorageService ManageProductsLocalStorageService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        public string CategoryName { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Products = await GetProductCollectionByCategoryId(CategoryId);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private async  Task<IEnumerable<ProductDto>> GetProductCollectionByCategoryId(int categoryId)
        {
            var productCollection = await ManageProductsLocalStorageService.GetCollection();
            if(productCollection == null)
            {
                return productCollection.Where(x => x.CategoryId == categoryId);
            }
            else
            {
                return await ProductService.GetItemsByCategory(categoryId);
            }
        }
    }
}
