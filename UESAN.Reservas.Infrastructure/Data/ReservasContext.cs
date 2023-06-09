﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Infrastructure.Data;

public partial class ReservasContext : DbContext
{
    public ReservasContext()
    {
    }

    public ReservasContext(DbContextOptions<ReservasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacion> Calificacion { get; set; }

    public virtual DbSet<DetalleReservas> DetalleReservas { get; set; }

    public virtual DbSet<DetalleServicios> DetalleServicios { get; set; }

    public virtual DbSet<Habitacion> Habitacion { get; set; }

    public virtual DbSet<IdEstadoReserva> IdEstadoReserva { get; set; }

    public virtual DbSet<Ofertas> Ofertas { get; set; }

    public virtual DbSet<Pago> Pago { get; set; }

    public virtual DbSet<Quejas> Quejas { get; set; }

    public virtual DbSet<ReservasOrder> ReservasOrder { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacion { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<TipoSalaEvento>TipoSalaEvento { get; set; }

    public virtual DbSet<SalaDeEventos>SalaDeEventos { get; set; }

    public virtual DbSet<DetalleSalaEventos>DetalleSalaEventos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JefersonSD\\SQLEXPRESS;DataBase=Reservas;TrustServerCertificate=True;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.HasKey(e => e.IdCalificacion).HasName("PK__Califica__6F6E6A401B350125");

            entity.Property(e => e.IdCalificacion).HasColumnName("Id_Calificacion");
            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.NumEstrellas).HasColumnName("Num_Estrellas");
            entity.Property(e => e.Recomendacion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Calificacion)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK_Calificacion.Id_Reserva");
        });

        modelBuilder.Entity<DetalleReservas>(entity =>
        {
            entity.HasKey(e => e.IdReserva);

            entity.ToTable("Detalle_Reservas");

            entity.Property(e => e.IdReserva)
                .ValueGeneratedNever()
                .HasColumnName("Id_Reserva");
            entity.Property(e => e.IdHabitacion).HasColumnName("Id_Habitacion");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.DetalleReservas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK_Detalle_Reservas.Id_Habitacion");

            entity.HasOne(d => d.IdReservaNavigation).WithOne(p => p.DetalleReservas)
                .HasForeignKey<DetalleReservas>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Reservas.Id_Reserva");
        });

        modelBuilder.Entity<DetalleServicios>(entity =>
        {
            entity.HasKey(e => e.IdReserva);

            entity.ToTable("Detalle_Servicios");

            entity.Property(e => e.IdReserva)
                .ValueGeneratedNever()
                .HasColumnName("Id_Reserva");
            entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithOne(p => p.DetalleServicios)
                .HasForeignKey<DetalleServicios>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Servicios.Id_Reserva");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK_Detalle_Servicios.Id_Servicio");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__6B8A72E20260C55B");

            entity.Property(e => e.IdHabitacion).HasColumnName("Id_Habitacion");
            entity.Property(e => e.CantCamas).HasColumnName("Cant_Camas");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdTipoHabi).HasColumnName("Id_TipoHabi");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdTipoHabiNavigation).WithMany(p => p.Habitacion)
                .HasForeignKey(d => d.IdTipoHabi)
                .HasConstraintName("FK_Habitacion.Id_TipoHabi");
        });

        modelBuilder.Entity<IdEstadoReserva>(entity =>
        {
            entity.HasKey(e => e.IdEstadoRes).HasName("PK__Id_Estad__9C2AF71D6D07D4FB");

            entity.ToTable("Id_Estado_Reserva");

            entity.Property(e => e.IdEstadoRes).HasColumnName("Id_EstadoRes");
            entity.Property(e => e.Motivo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ofertas>(entity =>
        {
            entity.HasKey(e => e.IdOfertas).HasName("PK__Ofertas__C41D869BF1933F8B");

            entity.Property(e => e.IdOfertas).HasColumnName("Id_Ofertas");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Descuento).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("Fecha_Fin");
            entity.Property(e => e.FechaIni)
                .HasColumnType("date")
                .HasColumnName("Fecha_Ini");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pago__3E79AD9A86301404");

            entity.Property(e => e.IdPago).HasColumnName("Id_Pago");
            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Pago)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK_Pago.Id_Reserva");
        });

        modelBuilder.Entity<Quejas>(entity =>
        {
            entity.HasKey(e => e.IdQuejas).HasName("PK__Quejas__F05DA0CD02BF5E42");

            entity.Property(e => e.IdQuejas).HasColumnName("Id_Quejas");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Quejas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Quejas.Id_Usuario");
        });

        modelBuilder.Entity<ReservasOrder>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reservas__9E953BE1A2574FD0");

            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.CantPersonas).HasColumnName("Cant_Personas");
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("Fecha_Fin");
            entity.Property(e => e.FechaIni)
                .HasColumnType("date")
                .HasColumnName("Fecha_Ini");
            entity.Property(e => e.IdEstadoRes).HasColumnName("Id_EstadoRes");
            entity.Property(e => e.IdOfertas).HasColumnName("Id_Ofertas");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdEstadoResNavigation).WithMany(p => p.ReservasOrder)
                .HasForeignKey(d => d.IdEstadoRes)
                .HasConstraintName("FK_Reservas.Id_EstadoRes");

            entity.HasOne(d => d.IdOfertasNavigation).WithMany(p => p.ReservasOrder)
                .HasForeignKey(d => d.IdOfertas)
                .HasConstraintName("FK_Reservas.Id_Ofertas");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ReservasOrder)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Reservas.Id_Usuario");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__5B1345F08E556BC5");

            entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
       
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabi).HasName("PK__Tipo_Hab__D1B601E8B94A5D6D");

            entity.ToTable("Tipo_Habitacion");

            entity.Property(e => e.IdTipoHabi).HasColumnName("Id_TipoHabi");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__Tipo_Usu__06416392B3611D77");

            entity.ToTable("Tipo_Usuario");

            entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__63C76BE2C21F3299");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK_Usuario.Id_Tipo");
        });

        modelBuilder.Entity<DetalleSalaEventos>(entity =>
        {
            entity.HasKey(e => e.IdReserva);

            entity.ToTable("Detalle_SalaEventos");

            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("Fecha_Fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("Fecha_Inicio");
            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.IdSalaEvento).HasColumnName("Id_SalaEvento");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithMany()
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_SalaEventos.Id_Reserva");

            entity.HasOne(d => d.IdSalaEventoNavigation).WithMany()
                .HasForeignKey(d => d.IdSalaEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_SalaEventos.Id_SalaEvento");
        });

        modelBuilder.Entity<SalaDeEventos>(entity =>
        {
            entity.HasKey(e => e.IdSalaEvento).HasName("PK__Sala de __94AF8D7ADF591966");

            entity.ToTable("Sala de eventos");

            entity.Property(e => e.IdSalaEvento).HasColumnName("Id_SalaEvento");
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.IdTipoEvento).HasColumnName("Id_Tipo_Evento");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdTipoEventoNavigation).WithMany(p => p.SalaDeEventos)
                .HasForeignKey(d => d.IdTipoEvento)
                .HasConstraintName("FK_Sala de eventos.Id_Tipo_Evento");
        });

        modelBuilder.Entity<TipoSalaEvento>(entity =>
        {
            entity.HasKey(e => e.IdTipoEvento).HasName("PK__Tipo_Sal__46C5D9A726986D0C");

            entity.ToTable("Tipo_Sala_Evento");

            entity.Property(e => e.IdTipoEvento).HasColumnName("Id_Tipo_Evento");
            entity.Property(e => e.Descripcion).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
