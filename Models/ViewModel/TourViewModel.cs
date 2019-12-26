using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDuLich.Models.DataModel;

namespace WebDuLich.Models.ViewModel
{
    public class TourViewModel
    {
        public Tour Tour { get; set; }
        public IEnumerable<TuyenDuong> TuyenDuongs { get; set; }
    }
}
