using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProductAssignment.Models;

namespace ProductAssignment.Controllers
{
    public class ProductcrudController : Controller
    {
        // GET: Productcrud

        HttpClient client = new HttpClient();
        ProductDBEntities3 db = new ProductDBEntities3();

        public ActionResult Index()
        {
             List<ProductTB> Pro_list = db.ProductTBs.ToList();
           // List<ProductTB> Pro_list = new List<ProductTB>();
            client.BaseAddress = new Uri("http://localhost:55898/api/ProductWebapi");
            var response = client.GetAsync("ProductWebapi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<ProductTB>>();
                display.Wait();
                Pro_list = display.Result;
            }


            return View(Pro_list);

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductTB pro)
        {


            client.BaseAddress = new Uri("http://localhost:55898/api/ProductWebapi");
            var response = client.PostAsJsonAsync<ProductTB>("ProductWebapi", pro);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Create");
        }

        [HttpGet]

        public ActionResult Details(int id)
        {
            // List<ProductTB> p = db.ProductTBs.ToList();

            // ProductTB p = null;
            ProductTB p = db.ProductTBs.Find(id);
            client.BaseAddress = new Uri("http://localhost:55898/api/ProductWebapi");
            var response = client.GetAsync("ProductWebapi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<ProductTB>();
                display.Wait();
                p = display.Result;
            }


            return View(p);


        }

        public ActionResult Edit(int id)
        {
            // ProductTB p = null;
            ProductTB p = db.ProductTBs.Find(id);

            client.BaseAddress = new Uri("http://localhost:55898/api/ProductWebapi");
            var response = client.GetAsync("ProductWebapi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<ProductTB>();
                display.Wait();
                p = display.Result;
            }


            return View(p);


        }

        [HttpPost]
        public ActionResult Edit(ProductTB p)
        {
            client.BaseAddress = new Uri("http://localhost:55898/api/ProductWebapi");
            var response = client.PutAsJsonAsync<ProductTB>("ProductWebapi", p);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            // ProductTB p = null;
            ProductTB p = db.ProductTBs.Find(id);

            client.BaseAddress = new Uri("http://localhost:55898/api/ProductWebapi");
            var response = client.GetAsync("ProductWebapi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<ProductTB>();
                display.Wait();
                p = display.Result;
            }


            return View(p);


        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("http://localhost:55898/api/ProductWebapi");
            var response = client.DeleteAsync("ProductWebapi/" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Delete");


        }






    }
}