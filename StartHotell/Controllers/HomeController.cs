using Model.DAO;
using Model.FE;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer.Symbols;

namespace StartHotell.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var product = new ProductDao();
            ViewBag.Product = product.ListNewProduct(8);
            ViewBag.FeatureProduct = product.ListFeatureProduct(8);
            return View();
        }
        public ActionResult Menu()
        {
            var model = new MenuDao().GetListByGroupId(1);
            return PartialView(model);
        }
        public ActionResult Phong(int? page, int? pageSize, string keyword)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 3;
            }
            ViewBag.PageSize = pageSize;
            // Kiểm tra xem có từ khóa tìm kiếm không
            if (!string.IsNullOrEmpty(keyword))
            {
                // Nếu có từ khóa tìm kiếm, lọc danh sách sản phẩm
                var filteredProducts = new ProductDao().ListProducts().Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
                return View(filteredProducts.ToPagedList((int)page, (int)pageSize));
            }

            // Nếu không có từ khóa tìm kiếm, hiển thị tất cả sản phẩm
            var allProducts = new ProductDao().ListProducts();
            return View(allProducts.ToPagedList((int)page, (int)pageSize));
        }

        public ActionResult ProductDetail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
        public JsonResult Search()
        {
            var product = new ProductDao().ListProducts();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(product, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }



        public ActionResult SearchResult(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View("Phong", new List<Product> { product });
        }
    }
}
