using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Venta_Bicis_Scooters.Models;

namespace Venta_Bicis_Scooters
{
    public partial class ReporteViewerPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BD_VENTAS_BICICLETA_SCOOTEREntities db = new BD_VENTAS_BICICLETA_SCOOTEREntities();
                List<usp_Pedido_Listar_Result> lista = db.usp_Pedido_Listar().ToList();
                ReportDataSource rptds = new ReportDataSource("DataSet1", lista);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rptds);


            }
        }
    }
}