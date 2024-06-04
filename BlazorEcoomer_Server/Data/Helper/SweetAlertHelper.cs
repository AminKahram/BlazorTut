using Microsoft.JSInterop;

namespace BlazorEcoomer_Server.Data.Helper;

public static class SweetAlertHelper
{
    public static async ValueTask SetSuccessFulMessageSA (this IJSRuntime jSRuntime, string message, string title, short timeOut)
    {
        await jSRuntime.InvokeVoidAsync("ShowSwal","success",message,title,timeOut);
    }
    public static async ValueTask SetErrorFulMessageSA(this IJSRuntime jSRuntime, string message, string title, short timeOut)
    {
        await jSRuntime.InvokeVoidAsync("ShowSwal", "error", message, title, timeOut);
    }
    public static async Task<bool> SetConfirmSA(this IJSRuntime jSRuntime)
    {
        return await jSRuntime.InvokeAsync<bool>("ConfirmSwal");
    }
}
