using Microsoft.JSInterop;

namespace DevelopmentTimer.UI.Services
{
    public class LocalStorageService
    {
        private readonly IJSRuntime js;

        public LocalStorageService(IJSRuntime js)
        {
            this.js = js;
        }

        public ValueTask SetItemAsync(string key, string value) => js.InvokeVoidAsync("localStorage.setItem", key, value);
        public ValueTask<string> GetItemAsync(string key) => js.InvokeAsync<string>("localStorage.getItem", key);
        public ValueTask RemoveItemAsync(string key) => js.InvokeVoidAsync("localStorage.removeItem", key);
    }
}