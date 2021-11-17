using BooksApp.Client.Helpers;
using BooksApp.Services;
using BooksApp.Shared.Helpers;
using BooksApp.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BooksApp.Client.Pages
{
    public class FormBookBase: ComponentBase
    {
        #region Parametros

        [Parameter]
        public Book? OBook{ get; set; }
        [Parameter]
        public TipoOpcion TipoOpcion { get; set; }
        [Parameter]
        public string? Titulo { get; set; }


        #endregion
        #region servicios
        [Inject]
        protected IApiService? Servicio { get; set; }
    
        [Inject]
        protected IJSRuntime? Js { get; set; }
        [Inject]
        protected NavigationManager Nav { get; set; }
        #endregion
        #region Variables
        public EditContext Context { get; set; }
        public bool SoloLectura { get; set; }
      
        #endregion
        #region Metodos 

        protected async override Task OnInitializedAsync()
        {

            
            Context = new(OBook);
            SoloLectura = (TipoOpcion == TipoOpcion.Vista);
          


        }
        public async Task Guardar()
        {
            try
            {
                if (OBook != null)
                    if (Context.Validate() && Context.IsModified())
                    {

                        bool Exito = false;
                        if (TipoOpcion == TipoOpcion.Crear)
                        {
                            Exito = await Servicio.Create(OBook);
                        }else if (TipoOpcion == TipoOpcion.Modificar)
                        {
                            Exito = await Servicio.Create(OBook);
                        }
                        if (Exito)
                        {
                            Nav.NavigateTo("", true);
                            await Js.ShowMessageToast("Exito");
                            StateHasChanged();

                        }
                        else
                        {
                            Nav.NavigateTo("", true);
                            await Js.ShowMessageToast($"Error al Interntar {(TipoOpcion == TipoOpcion.Crear?"Crear":"Modificar")}", JSExtention.Icono.error);

                            StateHasChanged();


                        }
                    }
                await Task.CompletedTask;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        

        public async Task Cancelar()
        {
            if (Context.IsModified())
            {
                if (await Js.ShowMessageConf("Si Cancela No Se Guardaran Los Cambios. \r\n ¿Esta Seguro de no Guardar?"))
                {
                    Nav.NavigateTo("", true);
                    StateHasChanged();
                }

            }
            else
            {
                Nav.NavigateTo("", true);
                StateHasChanged();
            }
            StateHasChanged();
        }


        #endregion
    }
}
