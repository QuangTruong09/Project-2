using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using JORDAN_2T.Infrastructure.Data;
using JORDAN_2T.Infrastructure.Interfaces;
using JORDAN_2T.ApplicationCore.Models;
using JORDAN_2T.ApplicationCore.ViewModels;
using JORDAN_2T.ApplicationCore.ViewModels.Admin;
using JORDAN_2T.ApplicationCore.Utilities;
using JORDAN_2T.Web.Controllers;


namespace JORDAN_2T.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = WebsiteRole.Admin)]
    public class SubCategoryController : BaseController
    {
        public SubCategoryController(IUnitOfWork uow) : base(uow)
        {

        }
        public IActionResult Index()
        {


            SubCategoryVM vM= new SubCategoryVM();
            vM.subcategory=((SubCategoryRepository)_uow.SubCategorys).GetAll(p=>p.Id !=null);
            
           return View(vM);
        }

        public ActionResult Create()
        {
            SubCategoryVM subCategoryVM =new SubCategoryVM();
            
            subCategoryVM.ListCategory=new SelectList(_uow.Categorys.GetAll(p=>p.Id!=null).ToList(),"Id","Name");
             
            return View(subCategoryVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( IFormCollection collection)
        {
            SubCategory Subcategory = new SubCategory();
            
            try
            {
                if (ModelState.IsValid)
                {
                    
                    Subcategory.Name = collection["Name"];
                    Subcategory.CategoryId=int.Parse(collection["CategoryId"]);
                    _uow.SubCategorys.Add(Subcategory);
                    _uow.Save();
                   
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
            }
            return View("Index");
        }

        public ActionResult Edit(int id, bool isPhoto = false)
        {

            SubCategory Subcategory = ((SubCategoryRepository)_uow.SubCategorys).GetSubCategory(id);
            if (Subcategory == null)
            {
                Subcategory = new SubCategory();
            }
            SubCategoryDetailsVm vm = new SubCategoryDetailsVm(Subcategory);

            vm.ListCategory=new SelectList(_uow.Categorys.GetAll(p=>p.Id!=null).ToList(),"Id","Name");
            // vm.categories=((CategoryRepository)_uow.Categorys).GetAll(p=>p.Id!=null);

            return View("Details", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            SubCategory Subcategory = new SubCategory();
            
            try
            {
                if (ModelState.IsValid)
                {
                    Subcategory = ((SubCategoryRepository)_uow.SubCategorys).GetSubCategory(id);
                    Subcategory.Name = collection["Name"];
                    Subcategory.CategoryId=int.Parse(collection["CategoryId"]);
                    
                    _uow.Save();
                   
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
            }
            return View("Edit",new SubCategoryDetailsVm(Subcategory) );
        }
         public ActionResult Delete(int id){
            
            SubCategory subcategory=((SubCategoryRepository)_uow.SubCategorys).GetSubCategory(id);
            
                ((SubCategoryRepository)_uow.SubCategorys).Remove(subcategory);
            
                _uow.Save();
                
            
            return RedirectToAction("Index");
            
        }
    }
    

}
