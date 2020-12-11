using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Venta_Bicis_Scooters.ENTITY;
using Venta_Bicis_Scooters.Models;


namespace Venta_Bicis_Scooters.Controllers
{
    public class HomeController : Controller
    {
        ScooterCrudDao scooterdao = new ScooterCrudDao();
        MarcaDao marcadao = new MarcaDao();
        TrabajadorDao trabajadordao = new TrabajadorDao();
        BicicletaCrudDao bicicletadao = new BicicletaCrudDao();
        AccesorioCrudDao accesoriodao = new AccesorioCrudDao();
        PedidoCrudDao pedidodao = new PedidoCrudDao();
        BoletaCrudDao boletadao = new BoletaCrudDao();
        DetallePedidoDao detallepedidodao = new DetallePedidoDao();
        FacturaCrudDao facturadao = new FacturaCrudDao();
        BD_VENTAS_BICICLETA_SCOOTEREntities db = new BD_VENTAS_BICICLETA_SCOOTEREntities();
        ClienteCrudDao clientedao = new ClienteCrudDao();
        /*----------------------------------------------------------------------------------------------------------------*/

        //VISTA ADMINISTRADOR
        public ActionResult PrincipalAdmin()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }



        //VISTA DE LOGIN
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult IniciarSesion(string user, string pass)
        {
            Trabajador t = trabajadordao.BuscarTrabajador(user, pass);
            if (t != null)
            {
                Session["User"] = t.UsernameTrabajador.ToString();
                Session["FirstName"] = t.Nombre.ToString();
                Session["LastName"] = t.Apellido.ToString();
                return RedirectToAction("PrincipalAdmin", "Home");
            }
            else
            {
                TempData["Error"] = "Usuario y/o contraseña incorrecta";
                return RedirectToAction("Login");
            }
        }

        



        /*---------------------------------------SCOOTER-------------------------------*/

        public ActionResult ListarScooter()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(scooterdao.ListarScooter().ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        public ActionResult ConsultarScooter(int cod = 0, string descripcion = null)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                if (descripcion == null) descripcion = string.Empty;
                if (cod == 0) cod = 1;
                ViewBag.descripcion = descripcion;
                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                return View(scooterdao.ConsultaScooter(cod, descripcion));
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        //INSERT
        public ActionResult CreateScooter()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen");

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult CreateScooter(Scooter emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                        ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen");

                        emp.ID = emp.ID;
                        scooterdao.InsertScooter(emp);
                        return RedirectToAction("ListarScooter");
                    }
                    else
                    {
                        return RedirectToAction("ListarScooter");
                    }

                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        //UPDATE
        public ActionResult EditScooter(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];

                Scooter emp = scooterdao.BuscarScooter(id);

                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca", emp.codMarca);
                ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen", emp.codImagen);

                return View(scooterdao.BuscarScooter(id));
       
            }
            else
            {
                return RedirectToAction("Login");
            }


        }
        [HttpPost]
        public ActionResult EditScooter(Scooter emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca", emp.codMarca);
                        ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen", emp.codImagen);

              
                        scooterdao.UpdateScooter(emp);

                        return RedirectToAction("ListarScooter");
                    }
                    else
                    {
                        return RedirectToAction("ListarScooter");
                    }

                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login");
            }




        }


        //DETALLES
        public ActionResult DetailsScooter(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(scooterdao.BuscarScooter(id));
            }
            else
            {
                return RedirectToAction("Login");
            }


        }




        /*---------------------------------------BICICLETA-------------------------------*/

        public ActionResult ListarBicicleta()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(bicicletadao.ListarBicicleta().ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        //INSERT
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen");

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult Create(Bicicleta emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                        ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen");

                        emp.ID = emp.ID;
                        bicicletadao.InsertBicicleta(emp);
                        return RedirectToAction("ListarBicicleta");
                    }
                    else
                    {
                        return RedirectToAction("ListarBicicleta");
                    }

                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        //UPDATE
        public ActionResult Edit(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                Bicicleta emp = bicicletadao.BuscarBicicleta(id);

                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca", emp.codMarca);
                ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen", emp.codImg);

                return View(bicicletadao.BuscarBicicleta(id));
            }
            else
            {
                return RedirectToAction("Login");
            }


        }
        [HttpPost]
        public ActionResult Edit(Bicicleta emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca", emp.codMarca);
                        ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen", emp.codImg);

                        bicicletadao.UpdateBicicleta(emp);

                        return RedirectToAction("ListarBicicleta");
                    }
                    else
                    {
                        return RedirectToAction("ListarBicicleta");
                    }

                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login");
            }




        }


        //DETALLES
        public ActionResult Details(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(bicicletadao.BuscarBicicleta(id));
            }
            else
            {
                return RedirectToAction("Login");
            }


        }


        public ActionResult ConsultarBicicleta(int cod = 0, string descripcion = null)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                if (descripcion == null) descripcion = string.Empty;
                if (cod == 0) cod = 1;
                ViewBag.descripcion = descripcion;
                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                return View(bicicletadao.ConsultaBicicleta(cod, descripcion));


            }
            else
            {
                return RedirectToAction("Login");
            }


        }





        /*---------------------------------------ACCESORIO-------------------------------*/


        public ActionResult ListarAccesorio()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(accesoriodao.ListarAccesorio().ToList());
                
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        //INSERT
        public ActionResult CreateAccesorio()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen");

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult CreateAccesorio(Accesorio emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                        ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen");

                        emp.ID = emp.ID;
                        accesoriodao.InsertAccesorio(emp);
              
                        return RedirectToAction("ListarAccesorio");
                    }
                    else
                    {
                        return RedirectToAction("ListarAccesorio");
                    }

                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        //UPDATE
        public ActionResult EditAccesorio(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


             
                Accesorio emp = accesoriodao.BuscarAccesorio(id);

                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca", emp.codMarca);
                ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen", emp.codImagen);

                return View(accesoriodao.BuscarAccesorio(id));
            }
            else
            {
                return RedirectToAction("Login");
            }


        }
        [HttpPost]
        public ActionResult EditAccesorio(Accesorio emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca", emp.codMarca);
                        ViewBag.imagen = new SelectList(db.TB_IMAGENES.ToList(), "cod_imagen", "descrp_imagen", emp.codImagen);

                      
                        accesoriodao.UpdateAccesorio(emp);

                        return RedirectToAction("ListarAccesorio");
                    }
                    else
                    {
                        return RedirectToAction("ListarAccesorio");
                    }

                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login");
            }




        }



        //DETALLES
        public ActionResult DetailsAccesorio(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(accesoriodao.BuscarAccesorio(id));
            }
            else
            {
                return RedirectToAction("Login");
            }


        }





        public ActionResult ConsultarAccesorio(int cod = 0, string descripcion = null)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                if (descripcion == null) descripcion = string.Empty;
                if (cod == 0) cod = 1;
                ViewBag.descripcion = descripcion;
                ViewBag.marca = new SelectList(marcadao.ListarMarca(), "IdMarca", "descMarca");
                return View(accesoriodao.ConsultaAccesorio(cod,descripcion));


            }
            else
            {
                return RedirectToAction("Login");
            }


        }














        /*---------------------------------------IMAGENES-------------------------------*/

        /*LISTADO*/
        public ActionResult ListarImagenes()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(db.TB_IMAGENES.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        /*CREATE*/
        public ActionResult CreateImagen()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(new TB_IMAGENES());
            }
            else
            {
                return RedirectToAction("ListarImagenes");
            }

        }
        [HttpPost]
        public ActionResult CreateImagen(TB_IMAGENES obj)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                HttpPostedFileBase archivoBase = Request.Files[0];


                if (archivoBase.ContentLength == 0)
                {
                    ModelState.AddModelError("foto", "Es necesario seleccionar una Imagen.... ");
                    return View(obj);
                }
                else
                {
                    if (archivoBase.FileName.EndsWith(".jpg"))
                    {
                        WebImage image = new WebImage(archivoBase.InputStream);
                    }
                    else
                    {
                        ModelState.AddModelError("foto", "Solo se permite  imagenes con formato JPG.... ");
                        return View(obj);
                    }
                }


                db.TB_IMAGENES.Add(obj);
                db.SaveChanges();       //sincroniza 
                return RedirectToAction("ListarImagenes");

            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        /*METODO PARA EXTRAER Y CONVERTIR LA SECUENCIA DE BYTES EN IMAGEN*/
     /*   public ActionResult getImage(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                TB_IMAGENES persona = db.TB_IMAGENES.Find(id);
                byte[] byteImage = persona.url_imagen;

                //convertir
                MemoryStream memoryStream = new MemoryStream(byteImage);
                Image image = Image.FromStream(memoryStream);

                memoryStream = new MemoryStream();
                image.Save(memoryStream, ImageFormat.Jpeg);
                memoryStream.Position = 0;

                return File(memoryStream, "imagen/jpg");


            }
            else
            {
                return RedirectToAction("ListarImagenes");
            }

        }
        */


        /*EDIT*/
        public ActionResult EditImagen(int? id)
        {

            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];

                TB_IMAGENES persona = db.TB_IMAGENES.Find(id);
                return View(persona);
            }
            else
            {
                return RedirectToAction("Login");
            }




        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditImagen(TB_IMAGENES obj)
        {

            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];



                //byte[] imagenActual = null
                TB_IMAGENES _persona = new TB_IMAGENES();
                HttpPostedFileBase archivoBase = Request.Files[0];

                //me quedo con la imagen que tengo
                if (archivoBase.ContentLength == 0)
                {
                    _persona = db.TB_IMAGENES.Find(obj.cod_imagen);
                    obj.url_imagen = _persona.url_imagen;
                }
                else
                {
                    if (archivoBase.FileName.EndsWith(".jpg"))
                    {
                        WebImage image = new WebImage(archivoBase.InputStream);
                    }
                    else
                    {
                        ModelState.AddModelError("foto", "Solo se permite  imagenes con formato JPG.... ");
                        return View(db.TB_IMAGENES.Find(obj.cod_imagen));
                    }
                }

                if (ModelState.IsValid)
                {
                    db.Entry(_persona).State = System.Data.Entity.EntityState.Detached;
                    db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("ListarImagenes");

            }
            else
            {
                return RedirectToAction("Login");
            }



        }


        /*DETAILS*/
        public ActionResult DetailsImagen(int? id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];

                TB_IMAGENES persona = db.TB_IMAGENES.Find(id);
                return View(persona);
            }
            else
            {
                return RedirectToAction("ListarImagenes");
            }

        }











        /*---------------------------------------CLIENTE-------------------------------*/


        public ActionResult ConsultarCliente(string dni = null)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                if (dni == null) dni = string.Empty;
                ViewBag.dni = dni;

                return View(clientedao.ConsultarCliente(dni));
            }
            else
            {
                return RedirectToAction("Login");
            }


        }





        /*---------------------------------------PEDIDO-------------------------------*/
        /*LISTADO*/
        public ActionResult ListarPedidos()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return PartialView(pedidodao.ListarPedido().ToList());

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        /*LISTADO*/
        public ActionResult ListarDetallePedidos()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return PartialView(detallepedidodao.ListarDetallePedido().ToList());

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult VistaParcial()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View();

            }
            else
            {
                return RedirectToAction("Login");
            }
          
        }








        /*---------------------------------------BOLETA-------------------------------*/
        /*LISTADO*/

        public ActionResult ListarBoleta()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(boletadao.ListarBoleta().ToList());

            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        //INSERT
        public ActionResult CreateBoleta()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                ViewBag.pedido = new SelectList(pedidodao.ListarPedido(), "ID", "ID");
           

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult CreateBoleta(Boleta emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.pedido = new SelectList(pedidodao.ListarPedido(), "ID", "ID");

                        emp.ID = emp.ID;

                        boletadao.InsertBoleta(emp);
                        return RedirectToAction("ListarBoleta");
                    }
                    else
                    {
                        return RedirectToAction("ListarBoleta");
                    }

                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }






        /*---------------------------------------FACTURA-------------------------------*/
        /*LISTADO*/

        public ActionResult ListarFactura()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];
                return View(facturadao.ListarFactura().ToList());

            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        //INSERT
        public ActionResult CreateFactura()
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                ViewBag.pedido = new SelectList(pedidodao.ListarPedido(), "ID", "ID");


                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult CreateFactura(Factura emp)
        {
            if (Session["User"] != null)
            {
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.Apellido = Session["LastName"];


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.pedido = new SelectList(pedidodao.ListarPedido(), "ID", "ID");

                        emp.ID = emp.ID;

                        facturadao.InsertFactura(emp);
                        return RedirectToAction("ListarFactura");
                    }
                    else
                    {
                        return RedirectToAction("ListarFactura");
                    }

                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

















    }
}