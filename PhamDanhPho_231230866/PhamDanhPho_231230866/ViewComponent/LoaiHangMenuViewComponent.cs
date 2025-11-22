using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhamDanhPho_231230866.Models;

namespace PhamDanhPho_231230866.ViewComponent
{
    public class LoaiHangMenuViewComponent : ViewComponent
    {
        private readonly PDPDbContext _db;

        public LoaiHangMenuViewComponent(PDPDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dsLoaiHang = await _db.LoaiHangs
                                     .OrderBy(lh => lh.TenLoai)
                                     .ToListAsync();

            return View(dsLoaiHang); // ✔ trả về View
        }
    }
}
