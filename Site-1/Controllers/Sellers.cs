using Microsoft.AspNetCore.Mvc;
using Site_1.Data;
using Site_1.Models;
using Site_1.Models.Extension;
using Site_1.Services;
using Site_1.Services.Exceptions;
using System.Diagnostics;

namespace Site_1.Controllers
{
    public class Sellers : Controller
    {
        private readonly SellerService sellerService;
        private readonly Site_1Context context;
        private readonly DepartamentService departamentService;


        public Sellers(SellerService seller, Site_1Context _1Context, DepartamentService service) {
        sellerService = seller;
        context = _1Context;    
        departamentService = service;
        }
        public async Task<IActionResult> Index()
        {
            var list = await sellerService.GetSellersAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var viewmodel = new SellerFormViewModel { departaments = await departamentService.FindAllAsync()};

            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller) {
            if (!ModelState.IsValid)
            {
                var departament = await departamentService.FindAllAsync();
                var viewModel = new SellerFormViewModel() { seller = seller, departaments = departament };
 
                return View(viewModel);
            }
            await context.Sellers.AddAsync(seller);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }
        public async Task<IActionResult> Delete (int? id){
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id  not provided"});
            }
            var obj = await sellerService.FindByIdAsync(id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id  not found" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await sellerService.RemoverAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegretyException e){
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id  not provided" });
            }
            var obj = await sellerService.FindByIdAsync(id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id  not found" });
            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id) {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id  not provided" });
            }
            var obj = await sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id  not found" });
            }
            List<Departament> departaments =  await departamentService.FindAllAsync();
            SellerFormViewModel sellerForm = new SellerFormViewModel() { seller = obj, departaments = departaments };
            return View(sellerForm);    
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller) {
            if (id != seller.Id) {
                return RedirectToAction(nameof(Error), new { message = "Id mismach"});
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    var departament = await departamentService.FindAllAsync();
                    var viewModel = new SellerFormViewModel() { seller = seller, departaments = departament };

                    await sellerService.UpdateAsync(seller);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Edit));

            }
            catch (ApplicationException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message});
            }
           
        }
        public async Task<IActionResult> Error(string message) {
        var viewModel = new ErrorViewModel { Message = message,
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };   
            return View(viewModel);
        }
    }
}
