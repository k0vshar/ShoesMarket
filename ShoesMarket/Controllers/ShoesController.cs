using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoesMarket.Domain.ViewModels.Shoes;
using ShoesMarket.Service.Interfaces;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesMarket.Controllers
{
    public class ShoesController : Controller
    {
        private readonly IShoesService _shoesService;

        public ShoesController(IShoesService shoesService)
        {
            _shoesService = shoesService;
        }

        [HttpGet]
        public IActionResult GetShoeses()
        {
            var response = _shoesService.GetShoeses();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _shoesService.DeleteShoes(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetShoeses");
            }
            return View("Error", $"{response.Description}");
        }

        public IActionResult Compare() => PartialView();

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
                return PartialView();

            var response = await _shoesService.GetShoes(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ShoesViewModel viewModel)
        {
            ModelState.Remove("Id");
            ModelState.Remove("DateCreate");
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(viewModel.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)viewModel.Avatar.Length);
                    }
                    await _shoesService.Create(viewModel, imageData);
                }
                else
                {
                    await _shoesService.Edit(viewModel.Id, viewModel);
                }
            }
            return RedirectToAction("GetShoeses");
        }


        [HttpGet]
        public async Task<ActionResult> GetShoes(int id, bool isJson)
        {
            var response = await _shoesService.GetShoes(id);
            if (isJson)
            {
                return Json(response.Data);
            }
            return PartialView("GetShoes", response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> GetShoes(string term)
        {
            var response = await _shoesService.GetShoes(term);
            return Json(response.Data);
        }

        [HttpPost]
        public JsonResult GetTypes()
        {
            var types = _shoesService.GetTypes();
            return Json(types.Data);
        }
    }
}









//if (!HttpContext.User.Identity.IsAuthenticated)
//{
//    return RedirectToAction("Login", "Account");
//}

//var response = await _shoesRepository.GetAllAsync();

//var response1 = await _shoesRepository.GetByName("Adidas");
//var response2 = await _shoesRepository.Get(0);

//var shoes = new Shoes()
//{
//    Name = "Adidas",
//    Model = "Ultra",
//    Price = 1200,
//    Description = "Кроссовки для бега",
//    DateCreated = DateTime.Now,
//    Speed = 20
//};

//await _shoesRepository.Create(shoes);

//await _shoesRepository.Delete(shoes);
