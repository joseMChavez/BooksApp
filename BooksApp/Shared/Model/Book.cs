
using System.ComponentModel.DataAnnotations;

using System.Text.Json.Serialization;
using static BooksApp.Shared.Helpers.Utility;

namespace BooksApp.Shared.Model
{

    public class Book
    {
        [Required]
        [JsonPropertyName("id")]
        [Identidad]
        public int Id { get; set; }
        
        [JsonPropertyName("title")]
        [Required]
        [DataType(DataType.Text)]
        [CampoMostrar(0,Helpers.TipoDato._string,"Titulo")]
        public string? Title { get; set; }
        [JsonPropertyName("pageCount")]
        [Required]
        [CampoMostrar(1, Helpers.TipoDato._string, "Conteo")]
        public int PageCount { get; set; }
        [JsonPropertyName("description")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [JsonPropertyName("excerpt")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string? Excerpt { get; set; }
        [JsonPropertyName("publishDate")]
        [Required]
        [DataType(DataType.DateTime)]
        [CampoMostrar(2, Helpers.TipoDato._DateTime, "Fecha Publicacion")]
        public DateTime PublishDate { get; set; }


    }

}