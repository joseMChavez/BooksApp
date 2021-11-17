
using System.ComponentModel.DataAnnotations;

using System.Text.Json.Serialization;
using static BooksApp.Shared.Helpers.Utility;

namespace BooksApp.Shared.Model
{

    public class Book
    {
        
        [JsonPropertyName("id")]
        [Identidad]
        [CampoMostrar(0, Helpers.TipoDato._int, "ID")]
        public int Id { get; set; }
        
        [JsonPropertyName("title")]
        [Required(ErrorMessage = "Introduzca el Titulo")]

        [DataType(DataType.Text)]
        [CampoMostrar(1,Helpers.TipoDato._string,"Titulo")]
        public string? Title { get; set; }
        [JsonPropertyName("pageCount")]
        [Required]
        [Range(1, 1000000, ErrorMessage = "Introduzca la cantidad de paginas")]
        [CampoMostrar(2, Helpers.TipoDato._string, "Conteo")]
        public int PageCount { get; set; }
        [JsonPropertyName("description")]
        [Required(ErrorMessage ="Introduzca la Descripción")]
        [DataType(DataType.MultilineText)]
       
        [CampoMostrar(4, Helpers.TipoDato._string, "Descripción")]
        public string? Description { get; set; }
        [JsonPropertyName("excerpt")]
        [Required(ErrorMessage ="Introduzca el Extracto")]
        [DataType(DataType.MultilineText)]
        public string? Excerpt { get; set; }
        [JsonPropertyName("publishDate")]
        [Required(ErrorMessage ="Introduzca la Fecha de Publicación")]
        [DataType(DataType.DateTime)]
        [CampoMostrar(3, Helpers.TipoDato._DateTime, "Fecha Publicacion")]
        public DateTime? PublishDate { get; set; }


    }

}