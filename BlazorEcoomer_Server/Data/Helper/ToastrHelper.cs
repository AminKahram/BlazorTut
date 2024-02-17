using Microsoft.JSInterop;

namespace BlazorEcoomer_Server.Data.Helper;

public static class ToastrHelper
{
    public static async ValueTask SetSuccessFulMessageToastr (this IJSRuntime jSRuntime,string message, string title, short timeOut)
    {
        await jSRuntime.InvokeVoidAsync("ShowToastr", "success", message, title, timeOut);
    }
    public static async ValueTask SetErrorFulMessage (this IJSRuntime jSRuntime, string message, string title, short timeOut)
    {
        await jSRuntime.InvokeVoidAsync("ShowToastr","error", message, title, timeOut);
    }
}
