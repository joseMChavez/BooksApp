using System.Reflection;

namespace BooksApp.Shared.Helpers
{
    public enum TipoDato
    {
        _int = 1,
        _string = 2,
        _float = 3,
        _double = 4,
        _DateTime = 5,
        _Long = 6,
        _boolean = 7
    }
    public enum TipoOpcion
    {
        Crear = 1,
        Modificar = 2,
        Listado = 3,
        Vista = 4
    }
    public static class Utility
    {
        public class Identidad : Attribute { }
        public class CampoMostrar : Attribute
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Mostrar { get; set; }
            public TipoDato DataType { get; set; }
            public CampoMostrar()
            {
                this.Index = 0;
                Name = string.Empty;
                DataType = TipoDato._string;
                Mostrar = String.Empty;
            }
            public CampoMostrar(int index, TipoDato tipo = TipoDato._int, string mostrar = "")
            {
                this.Index = index;
                Name = string.Empty;
                DataType = tipo;
                Mostrar = mostrar;
            }


        }

        /// <summary>
        /// Genera una lista de Campos ordenados por indice
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static List<CampoMostrar> GetListaCampoMostrar(this Type objeto)
        {

            IQueryable<PropertyInfo> attrs = objeto.GetProperties().AsQueryable().
                Where(x => ((CampoMostrar?)x.GetCustomAttribute(typeof(CampoMostrar), true)) != null);
            List<CampoMostrar> retorno = new();
            _ = new CampoMostrar();
            foreach (var x in attrs)
            {
                CampoMostrar? valor = (CampoMostrar?)x.GetCustomAttribute(typeof(CampoMostrar), true);
                valor.Name = x.Name;
                retorno.Add(valor);
            }


            return retorno.OrderBy(x => x.Index).ToList();
        }
    }
}
