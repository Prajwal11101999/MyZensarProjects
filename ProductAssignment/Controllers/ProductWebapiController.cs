using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductAssignment.Models;

namespace ProductAssignment.Controllers
{
    public class ProductWebapiController : ApiController
    {

        ProductDBEntities3 db = new ProductDBEntities3();

        [HttpGet]
        //[System.Web.Http.HttpGet]
        public IHttpActionResult GetProduct()
        {
            List<ProductTB> list = db.ProductTBs.ToList();
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult GetProductId(int ID)
        {
            var pro = db.ProductTBs.Where(model => model.ID == ID).FirstOrDefault();

            return Ok(pro);

        }

        [HttpPost]
       // [System.Web.Http.HttpPost]
        public IHttpActionResult proInsert(ProductTB p)
        {
            db.ProductTBs.Add(p);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
       // [System.Web.Http.HttpPut]
        public IHttpActionResult ProUpdate(ProductTB p)
        {
            var pro = db.ProductTBs.Where(model => model.ID == p.ID).FirstOrDefault();
            if (pro != null)
            {
                pro.ID = p.ID;
                pro.ProductName = p.ProductName;
                pro.CategoryID = p.CategoryID;
                pro.UnitID = p.UnitID;
                pro.Price = p.Price;


                db.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
       // [System.Web.Http.HttpDelete]
        public IHttpActionResult ProDelete(int id)
        {
            var emp = db.ProductTBs.Where(model => model.ID == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }




    }
}
