using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDuLich.Models.DataModel;

namespace WebDuLich.Models.ViewModel
{
    public class TuyenDuongViewModel
    {
        public TuyenDuong TuyenDuong { get; set; }
        public IEnumerable<LoaiTour> LoaiTours { get; set; }
        public IEnumerable<Sale> Sales { get; set; }

    }
}
