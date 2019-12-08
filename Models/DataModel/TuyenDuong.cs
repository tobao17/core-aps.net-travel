using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDuLich.Models.DataModel
{
    public class TuyenDuong
    {
        [Key]
        public int MaTuyenDuong { get; set; }
        public string TenTuyenDuong { get; set; }
        public string NoiDung { get; set; }
        public string Anh { get; set; }
        public int? SoNgay { get; set; }
        public string DiaDiemKhoiHanh { get; set; }

        //[Display(Name = "LoaiTour")]
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public virtual LoaiTour LoaiTour { get; set; }

        [Display(Name ="KhuyenMai")]
        public int MaKM { get; set; }

        [ForeignKey("MaKM")]
        public  virtual Sale Sale { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
        
    }
}
