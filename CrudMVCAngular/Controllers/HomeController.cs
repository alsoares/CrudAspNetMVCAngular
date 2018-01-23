using CrudMVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVCAngular.Controllers
{
    public class HomeController : Controller
    {

        DatabaseEntities ctx = new DatabaseEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {

            try
            {
                List<Item> items = GetAllItems();
                return Json(items, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        public JsonResult Add(Item item)
        {
            try
            {
                AddItem(item);
                List<Item> items = GetAllItems();

                return Json(items, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public JsonResult Delete(Item item)
        {
            try
            {
                DeleteItem(item);
                List<Item> itens = GetAllItems();
                return Json(itens, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void DeleteItem(Item item)
        {
            var _item = ctx.Items.Find(item.Id);
            ctx.Items.Remove(_item);
            ctx.SaveChanges();
        }

        private List<Item> GetAllItems()
        {
            return ctx.Items.ToList();
        }

        private void AddItem(Item newItem)
        {
            ctx.Items.Add(new Item
            {
                Name = newItem.Name
            });

            ctx.SaveChanges();
        }
    }
}