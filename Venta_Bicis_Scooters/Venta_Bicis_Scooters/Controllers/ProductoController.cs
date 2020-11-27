using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Venta_Bicis_Scooters.ENTITY;
using Venta_Bicis_Scooters.Models;

namespace Venta_Bicis_Scooters.Controllers
{
    public class ProductoController : Controller
    {
        ScooterCrudDao scooterdao = new ScooterCrudDao();
        BicicletaCrudDao bicicletadao = new BicicletaCrudDao();
        AccesorioCrudDao accesoriodao = new AccesorioCrudDao();


        /*------------------------CARRITO DE COMPRAS-------------------------------------------------*/
        
        //CAPTURAR POSICION
        public int getIndex(int id)
        {
            //contenido de la session pasa a la lista
            List<CarritoItem> compras = (List<CarritoItem>)Session["Carrito"];

                      
                 /*           for (int i = 0; i < compras.Count; i++)
                            {
                                    if (compras[i].Bicicleta.ID == id &&  id<=100)
                                    {
                                        return i;
                                    }
                                    else if (compras[i].Scooter.ID == id && id <= 200)
                                    {
                                        return i;
                                    }
                                    else if (compras[i].Accesorio.ID == id && id <= 300)
                                     {
                                             return i;
                                     }
                            }
                   */
                   

            if(id <= 100)
            {
                for (int i = 0; i < compras.Count; i++)
                {
                    if (compras[i].Bicicleta.ID == id)
                    {
                        return i;
                    }
                }
            }
            else if (id <= 200)
            {
                for (int i = 0; i < compras.Count; i++)
                {
                  
                        if (compras[i].Scooter.ID == id)
                        {
                            return i;
                        }
                  
                    
                }
            }
            else
            {
                for (int i = 0; i < compras.Count; i++)
                {
                    if (compras[i].Accesorio.ID == id)
                    {
                        return i;
                    }
                }
            }

             return -1;
              
        }





        //AGREGAMOS UN PRODUCTO AL CARRITO 
        public ActionResult AgregarCarritoBicicleta(int id)
        {

            //SI EL CARRITO ESTA VACIO: CREAR COLECCION Y AGREGAR LOS PRODUCTOS
            if (Session["Carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                
                if(id <= 100)
                {
                    compras.Add(new CarritoItem(bicicletadao.BuscarBicicleta(id), scooterdao.BuscarScooter(id), accesoriodao.BuscarAccesorio(id), 1));
                }
                else if (id <= 200)
                {
                    compras.Add(new CarritoItem(bicicletadao.BuscarBicicleta(id), scooterdao.BuscarScooter(id), accesoriodao.BuscarAccesorio(id), 1));
                }
                else if (id <= 300)
                {
                    compras.Add(new CarritoItem(bicicletadao.BuscarBicicleta(id), scooterdao.BuscarScooter(id), accesoriodao.BuscarAccesorio(id), 1));
                }

                ViewBag.codigo = id;

                Session["Carrito"] = compras;
            }

            else
            {   //AGREGAR EL PRODUCTO ENCONTRADO , AUMENTA LA CANTIDAD 

                List<CarritoItem> compras = (List<CarritoItem>)Session["Carrito"];
                int posicion = getIndex(id);
                if (posicion == -1) //no lo encontro
                {
                    if (id <= 100)
                    {
                        compras.Add(new CarritoItem(bicicletadao.BuscarBicicleta(id), scooterdao.BuscarScooter(id), accesoriodao.BuscarAccesorio(id), 1));
                    }
                    else if (id <= 200)
                    {
                        compras.Add(new CarritoItem(bicicletadao.BuscarBicicleta(id), scooterdao.BuscarScooter(id), accesoriodao.BuscarAccesorio(id), 1));
                    }
                    else if (id <= 300)
                    {
                        compras.Add(new CarritoItem(bicicletadao.BuscarBicicleta(id), scooterdao.BuscarScooter(id), accesoriodao.BuscarAccesorio(id), 1));
                    }

                    ViewBag.codigo = id;

                }
                else
                {
                    compras[posicion].Cantidad++;
                }

                Session["Carrito"] = compras;
            }

            return View();
        }







        //ELIMINAR DEL CARRITO
        public ActionResult Delete(int id)
        {
            List<CarritoItem> comprasB = (List<CarritoItem>)Session["Carrito"];
            comprasB.RemoveAt(getIndex(id));

            return View("AgregarCarritoBicicleta");

     
        }








        /*----------------------------------PRODUCTOS---------------------------------------------*/




        /*--BICICLETAS--*/
        public ActionResult TodasBicicletas()
        {
            if (Session["User"] != null)
            {
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.logout = Session["logout"];
                ViewBag.perfil = Session["perfil"];
                return View(bicicletadao.ListarBicicleta().ToList());
            }
            else
            {
                ViewBag.iniciar = "Iniciar Session";
                return View(bicicletadao.ListarBicicleta().ToList());
            }
           
        }

        public ActionResult DetallesBicicletas(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.logout = Session["logout"];
                ViewBag.perfil = Session["perfil"];
                return View(bicicletadao.BuscarBicicleta(id));
            }
            else
            {
                ViewBag.iniciar = "Iniciar Session";
                return View(bicicletadao.BuscarBicicleta(id));
            }

         
        }



        /*--SCOOTER--*/
        public ActionResult TodosScooter()
        {
            if (Session["User"] != null)
            {
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.logout = Session["logout"];
                ViewBag.perfil = Session["perfil"];
                return View(scooterdao.ListarScooter().ToList());
            }
            else
            {
                ViewBag.iniciar = "Iniciar Session";
                return View(scooterdao.ListarScooter().ToList());
            }

     
        }

        public ActionResult DetallesScooter(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.logout = Session["logout"];
                ViewBag.perfil = Session["perfil"];
                return View(scooterdao.BuscarScooter(id));
            }
            else
            {
                ViewBag.iniciar = "Iniciar Session";
                return View(scooterdao.BuscarScooter(id));
            }
             
        }




        /*--ACCESORIOS--*/
        public ActionResult TodosAccesorios()
        {
            if (Session["User"] != null)
            {
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.logout = Session["logout"];
                ViewBag.perfil = Session["perfil"];
                return View(accesoriodao.ListarAccesorio().ToList());
            }
            else
            {
                ViewBag.iniciar = "Iniciar Session";
                return View(accesoriodao.ListarAccesorio().ToList());
            }

     
        }

        public ActionResult DetallesAccesorios(int id)
        {
            if (Session["User"] != null)
            {
                ViewBag.Apellido = Session["LastName"];
                ViewBag.Nombre = Session["FirstName"];
                ViewBag.logout = Session["logout"];
                ViewBag.perfil = Session["perfil"];
                return View(accesoriodao.BuscarAccesorio(id));
            }
            else
            {
                ViewBag.iniciar = "Iniciar Session";
                return View(accesoriodao.BuscarAccesorio(id));
            } 
        }













    }
}