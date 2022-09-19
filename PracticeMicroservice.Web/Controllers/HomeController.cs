using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticeMicroservice.Web.Models;
using PracticeMicroservice.Web.Services.IServices;

namespace PracticeMicroservice.Web.Controllers
{
  public class HomeController : Controller
  {
    private readonly IProductService _productService;

    public HomeController(IProductService productService)
    {
      _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
      List<ProductDto> list = new();
      var response = await _productService.GetAllProductsAsync<ResponseDto>("");
      if (response != null && response.IsSuccess)
      {
        list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
      }
      return View(list);
    }

    public async Task<IActionResult> Details(int productId)
    {
      ProductDto model = new();
      var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, "");
      if (response != null && response.IsSuccess)
      {
        model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
      }

      return View(model);
    }


    [Authorize]
    public async Task<IActionResult> Login()
    {
      var accessToken = await HttpContext.GetTokenAsync("access_token");
      return RedirectToAction(nameof(Index));
    }

    public IActionResult Logout()
    {
      return SignOut("Cookies", "oidc");
    }
  }
}
