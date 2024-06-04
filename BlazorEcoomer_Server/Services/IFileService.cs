using Microsoft.AspNetCore.Components.Forms;
using System.Net;

namespace BlazorEcoomer_Server.Services;

public interface IFileService
{
   Task<string> UploadFile(IBrowserFile browserFile);
    bool DeleteFile(string path);
}
