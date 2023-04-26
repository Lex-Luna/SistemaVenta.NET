using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaVenta.Entity;

public partial class DbventaContext : DbContext
{
    public DbventaContext()
    {
    }

    public DbventaContext(DbContextOptions<DbventaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<Detalleventum> Detalleventa { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Negocio> Negocios { get; set; }

    public virtual DbSet<Numerocorrelativo> Numerocorrelativos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Rolmenu> Rolmenus { get; set; }

    public virtual DbSet<Tipodocumentoventum> Tipodocumentoventa { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=dbventa;uid=root;pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .HasColumnName("propiedad");
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .HasColumnName("recurso");
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Detalleventum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PRIMARY");

            entity.ToTable("detalleventa");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CategoriaProducto)
                .HasMaxLength(100)
                .HasColumnName("categoriaProducto");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(100)
                .HasColumnName("descripcionProducto");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.MarcaProducto)
                .HasMaxLength(100)
                .HasColumnName("marcaProducto");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PRIMARY");

            entity.ToTable("menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Controlador)
                .HasMaxLength(30)
                .HasColumnName("controlador");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .HasColumnName("icono");
            entity.Property(e => e.IdMenuPadre).HasColumnName("idMenuPadre");
            entity.Property(e => e.PaginaAccion)
                .HasMaxLength(30)
                .HasColumnName("paginaAccion");
        });

        modelBuilder.Entity<Negocio>(entity =>
        {
            entity.HasKey(e => e.IdNegocio).HasName("PRIMARY");

            entity.ToTable("negocio");

            entity.Property(e => e.IdNegocio)
                .ValueGeneratedNever()
                .HasColumnName("idNegocio");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreLogo)
                .HasMaxLength(100)
                .HasColumnName("nombreLogo");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.PorcentajeImpuesto)
                .HasPrecision(10, 2)
                .HasColumnName("porcentajeImpuesto");
            entity.Property(e => e.SimboloMoneda)
                .HasMaxLength(5)
                .HasColumnName("simboloMoneda");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
            entity.Property(e => e.UrlLogo)
                .HasMaxLength(500)
                .HasColumnName("urlLogo");
        });

        modelBuilder.Entity<Numerocorrelativo>(entity =>
        {
            entity.HasKey(e => e.IdNumeroCorrelativo).HasName("PRIMARY");

            entity.ToTable("numerocorrelativo");

            entity.Property(e => e.IdNumeroCorrelativo).HasColumnName("idNumeroCorrelativo");
            entity.Property(e => e.CantidadDigitos).HasColumnName("cantidadDigitos");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.Gestion)
                .HasMaxLength(100)
                .HasColumnName("gestion");
            entity.Property(e => e.UltimoNumero).HasColumnName("ultimoNumero");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(50)
                .HasColumnName("codigoBarra");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .HasColumnName("marca");
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .HasColumnName("nombreImagen");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(500)
                .HasColumnName("urlImagen");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<Rolmenu>(entity =>
        {
            entity.HasKey(e => e.IdRolMenu).HasName("PRIMARY");

            entity.ToTable("rolmenu");

            entity.Property(e => e.IdRolMenu).HasColumnName("idRolMenu");
            entity.Property(e => e.EsActivo)
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
        });

        modelBuilder.Entity<Tipodocumentoventum>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumentoVenta).HasName("PRIMARY");

            entity.ToTable("tipodocumentoventa");

            entity.Property(e => e.IdTipoDocumentoVenta).HasColumnName("idTipoDocumentoVenta");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo)
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo)
                .HasColumnType("bit(1)")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreFoto)
                .HasMaxLength(100)
                .HasColumnName("nombreFoto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(500)
                .HasColumnName("urlFoto");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PRIMARY");

            entity.ToTable("venta");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.DocumentoCliente)
                .HasMaxLength(10)
                .HasColumnName("documentoCliente");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdTipoDocumentoVenta).HasColumnName("idTipoDocumentoVenta");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.ImpuestoTotal)
                .HasPrecision(10, 2)
                .HasColumnName("impuestoTotal");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(20)
                .HasColumnName("nombreCliente");
            entity.Property(e => e.NumeroVenta)
                .HasMaxLength(6)
                .HasColumnName("numeroVenta");
            entity.Property(e => e.SubTotal)
                .HasPrecision(10, 2)
                .HasColumnName("subTotal");
            entity.Property(e => e.Total).HasPrecision(10, 2);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
