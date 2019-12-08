using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDuLich.Models.DataModel
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string HoTen { get; set; }
        public string Email { get; set; }
        [Required]
        public string SDT { get; set; }
        public virtual ICollection<DatTour> DatTours { get; set; }

    }
}
