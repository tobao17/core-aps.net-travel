using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDuLich.Models.DataModel;

namespace WebDuLich.Models.ViewModel
{
    public class DatTourViewModel
    {
        public DatTour DatTour { get; set; }
        public IEnumerable<KhachHang> KhachHangs { get; set; }
    }
}
