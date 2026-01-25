using Microsoft.JSInterop;

namespace TailorManagementSystems.Infrastructure.Services.Sweetalert
{
    public class SweetAlertService
    {
        private readonly IJSRuntime _jsRuntime;
        public SweetAlertService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task ShowAlert(string title, string message, string icon)
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", new
            {
                title,
                text = message,
                icon
            });
        }
        public async Task Success(string title, string message)
        {
            await _jsRuntime.InvokeVoidAsync(
                "showSweetAlert",
                title,
                message,
                "success"
            );
        }

        public async Task Error(string title, string message)
        {
            await _jsRuntime.InvokeVoidAsync(
                "showSweetAlert",
                title,
                message,
                "error"
            );
        }

        public async Task Info(string title, string message)
        {
            await _jsRuntime.InvokeVoidAsync(
                "showSweetAlert",
                title,
                message,
                "info"
            );
        }

        public async Task<bool> Confirm(string title, string message)
        {
            return await _jsRuntime.InvokeAsync<bool>(
                "showConfirmAlert",
                title,
                message
            );
        }
    }
}
