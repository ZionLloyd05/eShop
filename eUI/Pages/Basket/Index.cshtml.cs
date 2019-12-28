using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Interfaces;
using eUI.Interfaces;
using eUI.ViewModels;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eUI.Pages.Basket
{
    public class IndexModel : PageModel
    {
        private const string _basketSessionKey = "basketId";
        private string _username = null;
        private readonly IBasketService _basketService;
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly IOrderService _orderService;
        private readonly IUriComposer _uriComposer;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            IBasketService basketService,
            IBasketViewModelService basketViewModelService,
            IOrderService orderService,
            IUriComposer uriComposer,

            SignInManager<ApplicationUser> signInManager
            )
        {
            _basketService = basketService;
            _basketViewModelService = basketViewModelService;
            _orderService = orderService;
            _uriComposer = uriComposer;
            _signInManager = signInManager;
        }

        public BasketViewModel BasketModel { get; set; } = new BasketViewModel();

        public async Task<IActionResult> OnGet()
        {
            await SetBasketModelAsync();
            return Page();
        }

        public async Task<IActionResult> OnPost(CatalogItemViewModel productDetails)
        {
            if(productDetails?.Id == null)
            {
                return RedirectToPage("/Index");
            }

            await SetBasketModelAsync();

            await _basketService.AddItemToBasket(BasketModel.Id, productDetails.Id, productDetails.Price, 1);
            await SetBasketModelAsync();

            return RedirectToPage("/Index");
        }

        private async Task SetBasketModelAsync()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(User.Identity.Name);
            }
            else
            {
                GetOrSetBasketCookieAndUserName();
                BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(_username);
            }
        }

        public async Task OnPostUpdate(Dictionary<string, int> items)
         {
            await SetBasketModelAsync();
            await _basketService.SetQuantities(BasketModel.Id, items);

            await SetBasketModelAsync();
        }

        public async Task<IActionResult> OnPostCheckoutuser(Dictionary<string, int> items)
        {
            Console.WriteLine("Checkout handler");
            await SetBasketModelAsync();

            await _basketService.SetQuantities(BasketModel.Id, items);
            await _orderService.CreateOrderAsync(BasketModel.Id, new Address("123 Main St.", "Zion", "Lloyd", "United States", "44240"));
            await _basketService.DeleteBasketAsync(BasketModel.Id);

            return RedirectToPage("../Checkout/Index");
        }

        private void GetOrSetBasketCookieAndUserName()
        {
            if (Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
            {
                _username = Request.Cookies[Constants.BASKET_COOKIENAME];
            }
            if (_username != null) return;

            _username = Guid.NewGuid().ToString();
            var cookieOption = new CookieOptions { IsEssential = true };
            cookieOption.Expires = DateTime.Today.AddYears(19);
            Response.Cookies.Append(Constants.BASKET_COOKIENAME, _username, cookieOption);
        }
    }
}