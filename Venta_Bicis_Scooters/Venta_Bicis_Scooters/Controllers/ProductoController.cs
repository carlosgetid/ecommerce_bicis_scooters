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
        BD_VENTAS_BICICLETA_SCOOTEREntities db = new BD_VENTAS_BICICLETA_SCOOTEREntities();

        /*------------------------CARRITO DE COMPRAS-------------------------------------------------*/
        
        //CAPTURAR POSICION
        public int getIndex(int id)
        {
                //contenido de la session pasa a la lista
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];

                for(int i = 0; i< compras.Count; i++)
                {
                    if(compras[i].Bicicleta.ID == id )
                    {
                        return i;
                    }
                }
                return -1;
           
  

        }


        //AGREGAMOS UN PRODUCTO AL CARRITO 
        public ActionResult AgregarCarritoBicicleta(int id)
        {
           
            //SI EL CARRITO ESTA VACIO: CREAR COLECCION Y AGREGAR LOS PRODUCTOS
            if (Session["carrito"] == null)
            {
                     List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(bicicletadao.BuscarBicicleta(id), 1));
                    Session["carrito"] = compras;

            }

            else
            {

                    //AGREGAR EL PRODUCTO ENCONTRADO , AUMENTA LA CANTIDAD 
                    List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"] ;
                        int posicion = getIndex(id);
                        if (posicion == -1 ) //no lo encontro
                        {
                            compras.Add(new CarritoItem(bicicletadao.BuscarBicicleta(id), 1));
                           
                        }
                        else
                        {
                           compras[posicion].Cantidad++;

                        }
                ViewBag.id = posicion;
                Session["carrito"] = compras;
  
            }

            return View();

        }




        //ELIMINAR DEL CARRITO
        public ActionResult Delete(int id)
        {
            List<CarritoItem> comprasB = (List<CarritoItem>)Session["carrito"];
            comprasB.RemoveAt(getIndex(id));

            return View("AgregarCarritoBicicleta");

     
        }


        public ActionResult FinalizarCompra()
        {
            if (Session["logeo"].Equals(false))
            {
                RedirectToAction("IniciarSesion", "Cliente");
            }
            else
            {

            

                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"] ;
                if (compras != null && compras.Count > 0)
                {

                    TB_PEDIDO nuevoPedido = new TB_PEDIDO();
                  //  nuevoPedido.cod_cliente = nuevoPedido.TB_CLIENTE.cod_cliente;
                    nuevoPedido.fecha_pedido = DateTime.Now;
                    nuevoPedido.sub_total = Convert.ToDecimal(compras.Sum(x => x.Bicicleta.Precio * x.Cantidad));
                    nuevoPedido.igv_pedido = nuevoPedido.sub_total * Convert.ToDecimal(0.16);
                    nuevoPedido.total_pedido = nuevoPedido.sub_total + nuevoPedido.igv_pedido;


                    nuevoPedido.TB_DETALLE_PEDIDOS = (from pedido in compras
                                                      select new TB_DETALLE_PEDIDOS
                                                      {
                                                          cod_bicicleta = pedido.Bicicleta.ID,
                                                          cantidad = pedido.Cantidad,
                                                          total = Convert.ToDecimal(pedido.Cantidad * pedido.Bicicleta.Precio)



                                                      }).ToList();
                    db.TB_PEDIDO.Add(nuevoPedido);
                    db.SaveChanges();
                    Session["carrito"] = new List<CarritoItem>();

                }


            }
            return View();
            
        }



        public ActionResult Fin()
        {

            return View();
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