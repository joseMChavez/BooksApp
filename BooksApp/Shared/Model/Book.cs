
using System.ComponentModel.DataAnnotations;

using System.Text.Json.Serialization;


namespace BooksApp.Shared.Model
{

    public class Book
    {
        [Required]
        [JsonPropertyName("id")]
     
        public int Id { get; set; }
        [JsonPropertyName("title")]
        [Required]
        [DataType(DataType.Text)]
        public string? Title { get; set; }
        [JsonPropertyName("pageCount")]
        [Required]
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
        public DateTime PublishDate { get; set; }


    }

}