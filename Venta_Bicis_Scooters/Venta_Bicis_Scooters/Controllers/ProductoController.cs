using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Venta_Bicis_Scooters.Models;

namespace Venta_Bicis_Scooters.Controllers
{
    public class ProductoController : Controller
    {
        ScooterCrudDao scooterdao = new ScooterCrudDao();
        BicicletaCrudDao bicicletadao = new BicicletaCrudDao();
        AccesorioCrudDao accesoriodao = new AccesorioCrudDao();


        /*------------------------PRODUCTOS----------------------------*/
        

        /*--BICICLETAS--*/
        public ActionResult TodasBicicletas()
        {
            ViewBag.Apellido = Session["LastName"];
            ViewBag.Nombre = Session["FirstName"];
            ViewBag.logout = Session["logout"];
            return View(bicicletadao.ListarBicicleta().ToList());
        }

        public ActionResult DetallesBicicletas(int id)
        {
            return View(bicicletadao.BuscarBicicleta(id));
        }


        /*--SCOOTER--*/
        public ActionResult TodosScooter()
        {
            ViewBag.Apellido = Session["LastName"];
            ViewBag.Nombre = Session["FirstName"];
            ViewBag.logout = Session["logout"];
            return View(scooterdao.ListarScooter().ToList());
        }

        public ActionResult DetallesScooter(int id)
        {
            return View(scooterdao.BuscarScooter(id));
        }




        /*--ACCESORIOS--*/
        public ActionResult TodosAccesorios()
        {
            ViewBag.Apellido = Session["LastName"];
            ViewBag.Nombre = Session["FirstName"];
            ViewBag.logout = Session["logout"];
            return View(accesoriodao.ListarAccesorio().ToList());
        }

        public ActionResult DetallesAccesorios(int id)
        {
            return View(accesoriodao.BuscarAccesorio(id));
        }






    }
}