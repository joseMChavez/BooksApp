using BooksApp.Shared.Model;
using System.Text;
using System.Text.Json;

namespace BooksApp.Services
{
    public interface IApiService
    {
        /// <summary>
        /// Permite Hacer una peticion HTTP Post a https://fakerestapi.azurewebsites.net/api/v1/Books
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<bool> Create(Book book);
        /// <summary>
        /// Permite Hacer una peticion HTTP a Put a https://fakerestapi.azurewebsites.net/api/v1/Books
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<bool> Update(int id, Book book);
        /// <summary>
        /// Permite Hacer una peticion HTTP Delete a https://fakerestapi.azurewebsites.net/api/v1/Books
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(int id);
        /// <summary>
        /// Hace una Peticion HTTP Get a  https://fakerestapi.azurewebsites.net/api/v1/Books
        /// </summary>
        /// <returns></returns>
        Task<List<Book>> Get();
        /// <summary>
        /// Hace una Peticion HTTP Get a  https://fakerestapi.azurewebsites.net/api/v1/Books
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Book> GetById(int id);

    }
    public class ApiServices : IApiService
    {
        private readonly HttpClient client;

        private readonly string? URL;

        public ApiServices(HttpClient http, string url = "api/Books")
        {
            client = http;
            URL = url;
        }
        public async Task<bool> Create(Book book)
        {
            try
            {
                if (book == null)
                    return false;

                string json = JsonSerializer.Serialize(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URL, content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                if (id == 0) return false;
                var result = await client.DeleteAsync($"{URL}/{id}");
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<List<Book>> Get()
        {
            try
            {
                _ = new List<Book>();
                var result = await client.GetAsync(URL);
                if (result.IsSuccessStatusCode)
                {

                    var json = await result.Content.ReadAsStringAsync();
                    List<Book>? list = JsonSerializer.Deserialize<List<Book>>(json);

                    if (list != null)
                    {
                        return list;
                    }


                }

                return new List<Book>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Book>();
            }
        }

        public async Task<Book> GetById(int id)
        {
            try
            {
                if (id == 0) return new Book();
                var result = await client.GetAsync($"{URL}/{id}");
                if (result.IsSuccessStatusCode)
                {
                    _ = new Book();
                    var json = await result.Content.ReadAsStringAsync();

                    Book? book = JsonSerializer.Deserialize<Book>(json);
                    if (book != null)
                    {
                        return book;
                    }

                }

                return new Book();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Book();
            }
        }

        public async Task<bool> Update(int id, Book book)
        {
            try
            {
                if (book == null && id == 0) return false;

                string json = JsonSerializer.Serialize(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PutAsync($"{URL}/{id}", content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}