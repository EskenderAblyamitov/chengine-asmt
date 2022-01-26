using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChEngine.Assessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService, IProductService productService)
        {
            _logger = logger;
            _orderService = orderService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();

            try
            {
                var topSoldProducts = await _orderService.GetTopSoldProducts(5);
                viewModel.SoldProducts = topSoldProducts;

                if (topSoldProducts?.Any() == true)
                {
                    var merchantProductNo = topSoldProducts.First().MerchantProductNo;
                    var newStock = 25;
                    await _productService.SetStockAsync(merchantProductNo, newStock);
                    viewModel.UpdateStockMessage = $"The stock has been set to {newStock} for product {merchantProductNo}";
                }

                viewModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.Message;
            }

            return View(viewModel);
        }
    }
}