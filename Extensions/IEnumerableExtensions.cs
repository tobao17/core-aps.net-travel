using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDuLich.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("TenLoai"),
                       Value = item.GetPropertyValue("MaLoai"),
                       Selected= item.GetPropertyValue("MaLoai").Equals(selectedValue.ToString())
                   };
        }

        public static IEnumerable<SelectListItem> ToSelectListItem1<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Mota"),
                       Value = item.GetPropertyValue("MaKM"),
                       Selected = item.GetPropertyValue("MaKM").Equals(selectedValue.ToString())
                   };
        }

        public static IEnumerable<SelectListItem> ToSelectListItemTuyenDuong<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("TenTuyenDuong"),
                       Value = item.GetPropertyValue("MaTuyenDuong"),
                       Selected = item.GetPropertyValue("MaTuyenDuong").Equals(selectedValue.ToString())
                   };
        }
    }
}
