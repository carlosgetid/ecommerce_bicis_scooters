﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Venta_Bicis_Scooters.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD_VENTAS_BICICLETA_SCOOTEREntities : DbContext
    {
        public BD_VENTAS_BICICLETA_SCOOTEREntities()
            : base("name=BD_VENTAS_BICICLETA_SCOOTEREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_IMAGENES> TB_IMAGENES { get; set; }
    }
}