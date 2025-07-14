using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Kiosk.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "No file uploaded." });

            // Only allow image files
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
                return BadRequest(new { message = "Invalid file type." });

            // Limit file size to 5MB
            if (file.Length > 5 * 1024 * 1024)
                return BadRequest(new { message = "File size exceeds 5MB." });

            var uniqueFileName = $"{DateTime.UtcNow.Ticks}_{Path.GetFileName(file.FileName)}";

            // First path: KioskCMS/public/uploads
            var uploadsDir1 = Path.Combine(Directory.GetCurrentDirectory(), "KioskCMS", "public", "uploads");
            if (!Directory.Exists(uploadsDir1))
                Directory.CreateDirectory(uploadsDir1);

            var filePath1 = Path.Combine(uploadsDir1, uniqueFileName);

            // Second path: KioskFrontend/public/uploads
            var uploadsDir2 = Path.Combine(Directory.GetCurrentDirectory(), "KioskFrontend", "public", "uploads");
            if (!Directory.Exists(uploadsDir2))
                Directory.CreateDirectory(uploadsDir2);

            var filePath2 = Path.Combine(uploadsDir2, uniqueFileName);

            // Save to the first location
            using (var stream = new FileStream(filePath1, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Copy to the second location
            System.IO.File.Copy(filePath1, filePath2, overwrite: true);

            // Return the relative path for frontend use
            var imagePath = $"/uploads/{uniqueFileName}";
            return Ok(new { imagePath });
        }
    }
}