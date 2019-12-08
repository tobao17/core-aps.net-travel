using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDuLich.Models.DataModel
{
    public class BinhLuan
    {
        [Key]
        public int MaBL { get; set; }        
        public string NoiDung { get; set; }
        public int vote { get; set; }

        public int MaKH { get; set; }
        [ForeignKey("MaKH")]
        public virtual  KhachHang KhachHang { get; set; }

        public int MaTuyenDuong { get; set; }
        [ForeignKey("MaTuyenDuong")]
        public virtual TuyenDuong TuyenDuong { get; set; }

    }
}
