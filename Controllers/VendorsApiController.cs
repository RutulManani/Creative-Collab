using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftelleCMSbackend.Data;
using GiftelleCMSbackend.Models;
using GiftelleCMSbackend.DTOs;

namespace GiftelleCMSbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorDTO>>> GetVendors()
        {
            var vendors = await _context.Vendor
                .Select(v => new VendorDTO
                {
                    VendorId = v.VendorId,
                    Name = v.Name,
                    ContactEmail = v.ContactEmail
                }).ToListAsync();

            return Ok(vendors);
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorDTO>> GetVendor(int id)
        {
            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor == null) return NotFound();

            var dto = new VendorDTO
            {
                VendorId = vendor.VendorId,
                Name = vendor.Name,
                ContactEmail = vendor.ContactEmail
            };

            return Ok(dto);
        }

        // POST: api/Vendors
        [HttpPost]
        public async Task<ActionResult<VendorDTO>> CreateVendor(VendorDTO vendorDto)
        {
            var vendor = new Vendor
            {
                Name = vendorDto.Name,
                ContactEmail = vendorDto.ContactEmail
            };

            _context.Vendor.Add(vendor);
            await _context.SaveChangesAsync();

            vendorDto.VendorId = vendor.VendorId;

            return CreatedAtAction(nameof(GetVendor), new { id = vendor.VendorId }, vendorDto);
        }

        // PUT: api/Vendors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendor(int id, VendorDTO vendorDto)
        {
            if (id != vendorDto.VendorId) return BadRequest();

            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor == null) return NotFound();

            vendor.Name = vendorDto.Name;
            vendor.ContactEmail = vendorDto.ContactEmail;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor == null) return NotFound();

            _context.Vendor.Remove(vendor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorExists(int id)
        {
            return _context.Vendor.Any(e => e.VendorId == id);
        }
    }
}
