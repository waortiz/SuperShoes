using SuperShoes.Services;
using SuperShoes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShoes.Controllers
{
    public class StoreController : Controller
    {
        /// <summary>
        /// Represents a service for the store.
        /// </summary>
        IStoreService storeService;

        /// <summary>
        /// Constructor of the controller.
        /// </summary>
        /// <param name="service">Service for the store.</param>
        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        
        // GET: Store
        public ActionResult Index()
        {
            List<Store> stores = storeService.GetStores();
            IEnumerable<StoreViewModel> list = stores.Select(x => new StoreViewModel
            {
                StoreId = x.StoreId.ToString(),
                Address = x.Address,
                Name = x.Name
            });

            return View("GetStores", list);
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View("EditStores");
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View("CreateStores");
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(StoreViewModel model)
        {
            try
            {
                storeService.SaveStore(new Store() { Address = model.Address, Name = model.Name });
                return RedirectToAction("Index");
            }
            catch
            {
            }

            return View();
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View("EditStores");
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StoreViewModel model)
        {
            try
            {
                storeService.SaveStore(new Store() { StoreId = id, Address = model.Address, Name = model.Name });
                return RedirectToAction("Index");
            }
            catch
            {
            }

            return View("Index");
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Index");
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                storeService.DeleteStore(id);
                return RedirectToAction("Index");
            }
            catch
            {
                
            }

            return View("Index");
        }
    }
}
