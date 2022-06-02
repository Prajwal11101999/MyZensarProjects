using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductAssignment.Models;

namespace ProductAssignment.Controllers
{
    public class CategoryapiController : ApiController
    {
        ProductDBEntities3 db = new ProductDBEntities3();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCategory()
        {
            List<CategoryTB> list = db.CategoryTBs.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var pro = db.CategoryTBs.Where(model => model.CategoryID == id).FirstOrDefault();

            return Ok(pro);

        }


        public IHttpActionResult CatInsert(CategoryTB p)
        {
            db.CategoryTBs.Add(p);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult ProUpdate(CategoryTB p)
        {
            var cat = db.CategoryTBs.Where(model => model.CategoryID == p.CategoryID).FirstOrDefault();
            if (cat != null)
            {
                // p.ID = p.ID;
                cat.CategoryID = p.CategoryID;
                cat.CategoryName = p.CategoryName;


                db.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult ProDelete(int id)
        {
            var emp = db.CategoryTBs.Where(model => model.CategoryID == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }



    }
}

