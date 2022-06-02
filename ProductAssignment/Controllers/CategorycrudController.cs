using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProductAssignment.Models;


namespace ProductAssignment.Controllers
{
    public class CategorycrudController : Controller
    {
        // GET: Categorycrud
        HttpClient client = new HttpClient();
        ProductDBEntities3 db = new ProductDBEntities3();

        public ActionResult Index()
        {
            List<CategoryTB> Pro_list = db.CategoryTBs.ToList();
           // List<CategoryTB> Pro_list = db.C

             //List<CategoryTB> Pro_list = new List<CategoryTB>();
            client.BaseAddress = new Uri("http://localhost:55898/api/Categoryapi");
            var response = client.GetAsync("Categoryapi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<CategoryTB>>();
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
        public ActionResult Create(CategoryTB pro)
        {


            client.BaseAddress = new Uri("http://localhost:55898/api/Categoryapi");
            var response = client.PostAsJsonAsync<CategoryTB>("Categoryapi", pro);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Create");
        }
        public ActionResult Edit(int id)
        {
            CategoryTB p = db.CategoryTBs.Find(id);
            client.BaseAddress = new Uri("http://localhost:55898/api/Categoryapi");
            var response = client.GetAsync("Categoryapi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<CategoryTB>();
                display.Wait();
                p = display.Result;
            }


            return View(p);


        }

        [HttpPost]
        public ActionResult Edit(CategoryTB p)
        {
            client.BaseAddress = new Uri("http://localhost:55898/api/Categoryapi");
            var response = client.PutAsJsonAsync<CategoryTB>("Categoryapi", p);
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
            CategoryTB p = db.CategoryTBs.Find(id);
            client.BaseAddress = new Uri("http://localhost:55898/api/Categoryapi");
            var response = client.GetAsync("CategoryTB?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<CategoryTB>();
                display.Wait();
                p = display.Result;
            }


            return View(p);



        }



        }
    }