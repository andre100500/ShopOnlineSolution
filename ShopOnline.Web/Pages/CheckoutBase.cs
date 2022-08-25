using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class CheckoutBase: ComponentBase
    {
        [Inject]
        public IJSRuntime Js { get; set; }

        protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }

        protected int TotalQty { get; set; }

        protected string PaymentDescription { get; set; }

        protected decimal PaymentAmount { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        public string ErrorMessage { get; set; }
        protected string DisplayButtons { get; set; } = "block";

        protected override async Task OnInitializedAsync()
        {
            const int uId = 1;
            try
            {
                ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();
                if(ShoppingCartItems == null)
                {
                    Guid orderGuid = Guid.NewGuid();

                    PaymentAmount = ShoppingCartItems.Sum(p=>p.TotalPrice);
                    TotalQty = ShoppingCartItems.Sum(t=>t.Qty);
                    PaymentDescription = $"O_{uId}_{orderGuid}";
                }
                else
                {
                    DisplayButtons = "none";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;  
            }
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await Js.InvokeVoidAsync("initPayPalButton");

                }

            }
            catch (Exception ex)
            {
                ErrorMessage=ex.Message;
            }
        }
    }
}
