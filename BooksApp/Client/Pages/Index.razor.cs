using BooksApp.Client.Helpers;
using BooksApp.Services;
using BooksApp.Shared.Helpers;
using BooksApp.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace BooksApp.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        #region Parametros
        [Parameter]
        public int Id { get; set; }
        #endregion
        #region Depedencias
        [Inject]
        private IJSRuntime? JS { get; set; }
        [Inject]
        private IApiService? Servicio { get; set; }
        [Inject]
        protected NavigationManager? Nav { get; set; }
        #endregion
        #region Variables 
        public List<Book>? Lista { get; set; }
        public TipoOpcion Opcion { get; set; }
        public TableBooks? Tabla { get; set; }
        public Book? Book { get; set; }

        public string? Titulo { get; set; }

        #endregion
        #region Metodos

        protected override async Task OnInitializedAsync()
        {
            Book = new();
            Titulo = "Cargando...";
            Tabla = new();
            if (Id > 0)
            {
                Book = await Servicio.GetById(Id);
                if (Book != null)
                {
                    Titulo = "Ver Detalle del Libro " + Book.Title;
                    Opcion = TipoOpcion.Vista;
                    await Task.CompletedTask;
                }
                else
                    await CargarData();

            }
            else
                await CargarData();

        }
        private async Task CargarData()
        {
            Lista = new();

            Lista = await Servicio.Get();
            Titulo = "Prueba Técnica Remota, Lista de Libros";
            Opcion = TipoOpcion.Listado;
        }
        public async Task Modificar(object id)
        {
            Id = (int)id;
            Book = await Servicio.GetById(Id);
            if (Book.Id == 0)
            {
                await JS.ShowMessageToast("Error al Intentar Modificar.", JSExtention.Icono.error);
                Opcion = TipoOpcion.Listado;
            }
            Titulo = "Editar Books";
            Opcion = TipoOpcion.Modificar;
            await Task.CompletedTask;

        }
        public async Task Ver(object id)
        {
            Id = (int)id;
            Nav.NavigateTo($"/{Id}", true);
            StateHasChanged();
            await Task.CompletedTask;
        }
        public async Task Anular(object id)
        {
            try
            {
                if (await JS.ShowMessageConf($"¿Esta seguro de Anular el Libro {Lista.AsQueryable().Where(x => x.Id == (int)id).First().Title}?"))
                {

                    var result = await Servicio.Delete((int)id);
                    if (!result)
                    {
                        await JS.ShowMessageToast("Error al Intentar Anular.", JSExtention.Icono.error);
                    }
                    await Task.Delay(1000);
                    await JS.Refrescar();
                    StateHasChanged();
                    await Task.CompletedTask;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        #endregion
    }
}
