using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDuLich.Models.DataModel
{
    public class LoaiTour
    {
        [Key]
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public virtual ICollection<TuyenDuong> TuyenDuongs { get; set; }
    }
}
