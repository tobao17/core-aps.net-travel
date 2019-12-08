using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDuLich.Models.DataModel
{
    public class Tour
    {
        [Key]
        public int MaTour { get; set; }      
        public string GiaTour { get; set; }
        public int SoNguoiToiDa { get; set; }
        public int SoNguoiMua { get; set; }
        public string NgayKhoiHanh { get; set; }
        public string NgayKetThuc { get; set; }
        public string GioDi { get; set; }


        public int MaTuyenDuong { get; set; }
     
        public virtual TuyenDuong TuyenDuong { get; set; }

        public virtual ICollection<ChiTietDatTour> ChiTietDatTours { get; set; }
        
        
  
    }
}
