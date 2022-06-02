using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductAssignment.Models;

namespace ProductAssignment.Controllers
{
    public class UnitapiController : ApiController
    {
        ProductDBEntities3 db = new ProductDBEntities3();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetUnit()
        {
            List<UnitTB> list = db.UnitTBs.ToList();
            return Ok(list);
        }

        public IHttpActionResult UnitInsert(UnitTB p)
        {
            db.UnitTBs.Add(p);
            db.SaveChanges();
            return Ok();
        }

    }
}
