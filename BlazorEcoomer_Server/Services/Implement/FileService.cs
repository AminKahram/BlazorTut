using Microsoft.AspNetCore.Components.Forms;

namespace BlazorEcoomer_Server.Services.Implement;  

public class FileService : IFileService
{
    private readonly IWebHostEnvironment WebHostEnvironment;
    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        this.WebHostEnvironment = webHostEnvironment;
    }
    public bool DeleteFile(string path)
    {
        if (File.Exists(WebHostEnvironment.WebRootPath+path))
        {
            File.Delete(WebHostEnvironment.WebRootPath+path);
            return true;
        }
        return false;
    }

    public async Task<string> UploadFile(IBrowserFile browserFile)
    {
        FileInfo fileInfo = new(browserFile.Name);
        var fileName = Guid.NewGuid().ToString()+ fileInfo.Extension;
        var fileDirectory = $"{WebHostEnvironment.WebRootPath}\\img\\Product";
        if(!Directory.Exists(fileDirectory))
        {
            Directory.CreateDirectory(fileDirectory);
        }
        var filePath = Path.Combine(fileDirectory, fileName);
        await using FileStream fs = new FileStream(filePath, FileMode.Create);
        await browserFile.OpenReadStream().CopyToAsync(fs);
        return $"img/Product/{fileName}";
    }
}
