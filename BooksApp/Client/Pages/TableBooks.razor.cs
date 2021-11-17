using Microsoft.AspNetCore.Components;
using System.Collections;
using BooksApp.Shared.Helpers;
using static BooksApp.Shared.Helpers.Utility;
using Microsoft.JSInterop;

namespace BooksApp.Client.Pages
{
    public class TableBooksBase : ComponentBase, IDisposable
    {
        #region Parametros
        [Parameter]
        public string? IconoBtnPersonalizado { get; set; }
        [Parameter]
        public string? NombrebtnPersonalizado { get; set; }
        [Parameter]
        public string? TablaId { get; set; }
        [Parameter]
        public IList? ListaParameter { get; set; }
        [Parameter]
        public Type OType { get; set; }
        [Parameter]
        public EventCallback<object> OnEdit { get; set; }
        [Parameter]
        public EventCallback<object> OnDelete { get; set; }
        [Parameter]
        public EventCallback<object> OnView { get; set; }
        [Parameter]
        public EventCallback<object> OnBtnPersonalizado { get; set; }
        [Parameter]
        public bool OcultarBotones { get; set; } = false;
        [Parameter]
        public bool OcultarBotonVista { get; set; } = false;
        [Parameter]
        public bool OcultarBotonEditar { get; set; } = false;
        [Parameter]
        public bool OcultarBotonAnular { get; set; } = false;
        [Parameter]
        public bool OcultarBotonPersonalizado { get; set; } = true;
        #endregion
        #region Insersiones
        [Inject]
        public IJSRuntime? Js { get; set; }
        #endregion
        public List<CampoMostrar>? Lista { get; set; }
        public int ContadorCamposMostrar { get; set; }
        public int Index { get; set; } = 0;
        protected override void OnInitialized()
        {
            _ = new List<CampoMostrar>();
            Lista = OType.GetListaCampoMostrar();
            ContadorCamposMostrar = Lista.Count;
        }
        protected async Task GetVista(object id)
        {
            await OnView.InvokeAsync(id);
        }
        protected async Task GetEdit(object id)
        {
            await OnEdit.InvokeAsync(id);
        }

        protected async Task GetDelete(object id)
        {
            await OnDelete.InvokeAsync(id);
        }
        protected async Task GetMetPersonalizado(object id)
        {
            await OnBtnPersonalizado.InvokeAsync(id);
        }
        public async Task RefrescarTabla()
        {
            await Js.InvokeAsync<object>("DataTablesRemove", $"#{TablaId}");
            await Js.InvokeAsync<object>("DataTablesAdd", $"#{TablaId}");

        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            await Js.InvokeAsync<object>("DataTablesAdd", $"#{TablaId}");

        }
        public void Dispose()
        {
            Js.InvokeVoidAsync("DataTablesRemove", $"#{TablaId}");

        }
    }
}
