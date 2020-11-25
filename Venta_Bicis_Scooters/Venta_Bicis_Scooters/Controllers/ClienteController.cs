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

            ViewBag.Apellido = Session["LastName"];
            ViewBag.Nombre = Session["FirstName"];
            ViewBag.logout = Session["logout"];
            return View();
        }



        //VISTA DE LOGIN
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult IniciarSesion(string user, string pass)
        {
            Cliente c = clientedao.BuscarCliente(user, pass);
            if (c != null)
            {
                Session["User"] = c.Correo.ToString();
                Session["LastName"] = "Hola!!";
                Session["FirstName"] = c.Nombre.ToString();
                Session["logout"] = "Cerrar Sesion";
                return RedirectToAction("PrincipalCliente", "Cliente");
            }
            else
            {
                TempData["Error"] = "Usuario y/o contraseña incorrecta";
                return RedirectToAction("Login");
            }
        }







        /*---------------------------------------CLIENTE-------------------------------*/


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente c)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    c.ID = c.ID;

                    clientedao.InsertCliente(c);
                    return RedirectToAction("Login");
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

        public ActionResult EditCliente(int id,string user,string pass)
        {
            Cliente c = clientedao.BuscarCliente(user, pass);
            if (c != null)
            {
                Cliente cli = clientedao.FindCliente(id);
                return View(clientedao.FindCliente(id));
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult EditCliente(Cliente cli)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clientedao.UpdateCliente(cli);
                    return RedirectToAction("EditCliente");
                }
                return RedirectToAction("EditCliente");
            }
            catch
            {
                return View();
            }
        }


       





    }
}