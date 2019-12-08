using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebDuLich.Models;
using WebDuLich.Models.DataModel;

namespace WebDuLich.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ADMIN> ADMINs { get; set; }
        public DbSet<BinhLuan> BinhLuans { get; set; }
        public DbSet<ChiTietDatTour> ChiTietDatTours { get; set; }
        public DbSet<DatTour> DatTours { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LoaiTour> LoaiTours { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TuyenDuong> TuyenDuongs { get; set; }
    }
}
