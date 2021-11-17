using Microsoft.JSInterop;

namespace BooksApp.Client.Helpers
{
    public static class JSExtention
    {
        /// <summary>
        /// Mostrar mensaje de confirmacion 
        /// </summary>
        /// <param name="js"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static async ValueTask<bool> ShowMessageConf(this IJSRuntime js, string mensaje)
        {

            var retorno = await js.InvokeAsync<object>("ShowMessageConfirmation", mensaje);
            await Task.CompletedTask;
            
            return !$"{retorno}".ToLower().Contains("cancel");
        }
        /// <summary>
        /// Mostrar mensaje
        /// </summary>
        /// <param name="js"></param>
        /// <param name="mensaje"></param>
        /// <param name="icono"></param>
        /// <returns></returns>
        public static async ValueTask ShowMessage(this IJSRuntime js, string mensaje, Icono icono = Icono.success)
        {
            await js.InvokeVoidAsync("ShowMessage", $"{icono}", mensaje);
            await Task.CompletedTask;
        }
        /// <summary>
        /// Mostrar mensaje Toast
        /// </summary>
        /// <param name="js"></param>
        /// <param name="mensaje"></param>
        /// <param name="icono"></param>
        /// <returns></returns>
        public static async ValueTask ShowMessageToast(this IJSRuntime js, string mensaje, Icono icono = Icono.success)
        {
            await js.InvokeVoidAsync("ShowMessageToast", $"{icono}", mensaje);
            await Task.CompletedTask;
        }
        public static async ValueTask Refrescar(this IJSRuntime js)
        {
            await js.InvokeVoidAsync("Refresh");
            await Task.CompletedTask;
        }
        public enum Icono
        {
            success,
            error,
            warning,
            info,
            question
        }
    }
}
