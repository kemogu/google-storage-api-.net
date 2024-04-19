using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using googlestorageapi.webui.Models;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace googlestorageapi.webui.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UploadFile(UploadFilesViewModel model)
    {
        if (ModelState.IsValid)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf", ".doc", ".docx", ".rtf" };
            var googleCredential = GoogleCredential.FromFile("your-json-file");
            var storageClient = StorageClient.Create(googleCredential);
            var bucketName = "your-bucket-name";

            foreach (var file in model.Files) // extension control
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError(nameof(file.FileName), "Invalid file extension.");
                    return View("Index", model);
                }
            }

            foreach (var file in model.Files) // file upload
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var fileObj = await storageClient.UploadObjectAsync(bucketName, $"{model.Email}/{file.FileName}", file.ContentType, memoryStream);
                }
            }
        }
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
