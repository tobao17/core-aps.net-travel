using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDuLich.Models.DataModel
{
    public class ChiTietDatTour
    {
        [Key]
        public int CTTourID { get; set; }    
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string Notes { get; set; }

        public int? SoNguoiDiTour { get; set; }
        public string TongTien { get; set; }

        public int MaDat { get; set; }
        [ForeignKey("MaDat")]
        public virtual DatTour DatTour { get; set; }

        public int MaTour { get; set; }
        [ForeignKey("MaTour")]
        public virtual Tour Tour { get; set; }

    }
}
