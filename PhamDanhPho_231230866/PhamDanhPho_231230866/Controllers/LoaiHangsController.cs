using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhamDanhPho_231230866.Models;

namespace PhamDanhPho_231230866.Controllers
{
    public class LoaiHangsController : Controller
    {
        private readonly PDPDbContext _context;

        public LoaiHangsController(PDPDbContext context)
        {
            _context = context;
        }

        // GET: LoaiHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiHangs.ToListAsync());
        }

        // GET: LoaiHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiHang = await _context.LoaiHangs
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loaiHang == null)
            {
                return NotFound();
            }

            return View(loaiHang);
        }

        // GET: LoaiHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiHang);
        }

        // GET: LoaiHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiHang = await _context.LoaiHangs.FindAsync(id);
            if (loaiHang == null)
            {
                return NotFound();
            }
            return View(loaiHang);
        }

        // POST: LoaiHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoai,TenLoai")] LoaiHang loaiHang)
        {
            if (id != loaiHang.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiHangExists(loaiHang.MaLoai))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(loaiHang);
        }

        // GET: LoaiHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiHang = await _context.LoaiHangs
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loaiHang == null)
            {
                return NotFound();
            }

            return View(loaiHang);
        }

        // POST: LoaiHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiHang = await _context.LoaiHangs.FindAsync(id);
            if (loaiHang != null)
            {
                _context.LoaiHangs.Remove(loaiHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiHangExists(int id)
        {
            return _context.LoaiHangs.Any(e => e.MaLoai == id);
        }
    }
}
