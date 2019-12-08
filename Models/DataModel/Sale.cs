using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDuLich.Models.DataModel
{
    public class Sale
    {
        [Key]
        public int MaKM { get; set; }
        public string Mota { get; set; }
        public float NoiDung { get; set; }
        public virtual ICollection<TuyenDuong> TuyenDuongs { get; set; }

    }
}
