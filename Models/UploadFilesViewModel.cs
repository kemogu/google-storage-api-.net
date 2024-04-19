namespace googlestorageapi.webui.Models;


public class UploadFilesViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public List<IFormFile> Files { get; set; }
}