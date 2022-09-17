using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticeMicroservice.Web.Models;
using PracticeMicroservice.Web.Services.IServices;

namespace PracticeMicroservice.Web.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
      _productService = productService;
    }
    public async Task<IActionResult> ProductIndex()
    {
      List<ProductDto> list = new();
      var accessToken = await HttpContext.GetTokenAsync("access_token");
      var response = await _productService.GetAllProductsAsync<ResponseDto>(accessToken);
      if (response != null && response.IsSuccess)
      {
        list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
      }
      return View(list);
    }

    public async Task<IActionResult> ProductCreate()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductCreate(ProductDto model)
    {
      if (ModelState.IsValid)
      {

        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var response = await _productService.CreateProductAsync<ResponseDto>(model, accessToken);
        if (response != null && response.IsSuccess)
        {
          return RedirectToAction(nameof(ProductIndex));
        }
      }
      return View(model);
    }



    public async Task<IActionResult> EditProduct(int productId)
    {
      var accessToken = await HttpContext.GetTokenAsync("access_token");

      var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken);
      if (response != null && response.IsSuccess)
      {
        ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
        return View(model);
      }

      return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProduct(ProductDto model)
    {
      if (ModelState.IsValid)
      {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var response = await _productService.UpdateProductAsync<ResponseDto>(model, accessToken);
        if (response != null && response.IsSuccess)
        {
          return RedirectToAction(nameof(ProductIndex));
        }
      }

      return View(model);
    }


    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
      var accessToken = await HttpContext.GetTokenAsync("access_token");

      var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken);
      if (response != null && response.IsSuccess)
      {
        ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
        return View(model);
      }

      return NotFound();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteProduct(ProductDto model)
    {
      if (model.ProductId != null)
      {
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        var response = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId, accessToken);
        if (response.IsSuccess)
        {
          return RedirectToAction(nameof(ProductIndex));
        }
      }

      return View(model);
    }
  }
}
