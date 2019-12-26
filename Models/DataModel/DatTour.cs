using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDuLich.Models.DataModel
{
    public class DatTour
    {
        [Key]
        public int MaDat { get; set; }
        public string NgayDat { get; set; }
        public string TinhTrang { get; set; }
        public int MaKH { get; set; }
        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }
        public virtual ICollection<ChiTietDatTour> ChiTietDatTours { get; set; }
       

    }
}
