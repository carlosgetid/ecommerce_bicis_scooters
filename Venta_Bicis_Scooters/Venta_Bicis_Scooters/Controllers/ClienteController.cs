using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Venta_Bicis_Scooters.DATABASE;
using Venta_Bicis_Scooters.ENTITY;
using Venta_Bicis_Scooters.Models;

namespace Venta_Bicis_Scooters.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente

        ClienteCrudDao clientedao = new ClienteCrudDao();


        //VISTA PRINCIPAL DE LA PAGINA
        public ActionResult PrincipalCliente()
        {
            return View();
        }



        //VISTA DE LOGIN
        public ActionResult Login()
        {
            return View();
        }

        /*---------------------------------------CLIENTE-------------------------------*/






        public ActionResult Create()
        {
            //LLENAR COMBO 
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //LLENAR COMBO 
                    c.ID = c.ID;

                    clientedao.InsertCliente(c);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }

        public ActionResult TodasBicicletas()
        {
            return View();
        }


        public ActionResult TodosScooter()
        {
            return View();
        }

        public ActionResult TodosAccesorios()
        {
            return View();
        }

    }
}