using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApp.Server.Services;
using System.Net.Http;
using BooksApp.Shared.Model;
using Microsoft.Extensions.Configuration;

namespace TestBooksServices
{
    [TestClass]
    public class TestBooks
    {
        readonly HttpClient http = new();
        readonly Book book = new()
        {
            Id = 900000,
            Title = "Book 900000",
            Description = "Prueba",
            Excerpt = "Kasd consequat sit ut amet erat justo lorem rebum duis sanctus elitr.Ea ut stet erat dolor ut sit dolore lorem at kasd est autem dolores et sit stet vero.Et rebum ut sanctus eu veniam ipsum ut dolores sea wisi feugiat eirmod.Ut quis lorem ut blandit ipsum eos diam dolore dolores.Vero justo eum nibh amet vero blandit diam illum eirmod sed aliquyam amet ipsum duo.Gubergren kasd labore.In eos mazim at.Stet aliquyam dolore dignissim.Sadipscing tempor justo magna sanctus autem sea duis takimata aliquyam sit.Et sadipscing sit magna no duo ipsum assum stet dolores sea et consequat.Iriure nonumy velit takimata stet eos lobortis justo amet at.Ipsum sadipscing eirmod sed et ipsum dolor tempor est blandit et erat id kasd augue et et soluta sed.Invidunt ea duo amet amet nonumy.\nEos luptatum ipsum ipsum est et elit nulla delenit vel zzril stet et amet aliquyam invidunt sit kasd erat.Sit zzril dolor dolor justo sit at lorem vero eirmod nonumy nonummy.Eos ea assum amet labore vero vero magna est.Lorem tempor sit clita diam justo illum.Nibh dolor duo dolores at sadipscing duo eu at autem magna dolore.Sea eirmod consetetur minim magna sed odio clita tempor.Amet sit justo lorem nihil dolor labore vel stet minim dolor diam dolore vel ullamcorper exerci et illum tincidunt.Augue erat est et erat lorem.Justo gubergren sed eros gubergren accusam velit lorem accusam nam diam nonumy tempor sed et justo diam sed vero.Nulla sanctus facer sed takimata eirmod accusam et et at duis voluptua vel hendrerit lorem ullamcorper ut.Euismod voluptua sea amet illum dolor.Elitr ipsum sea.Ex ea erat.Dolor clita stet assum dolores velit et duo ipsum aliquyam dolor et veniam.\nElitr sit commodo in sit justo sed no nonumy molestie lorem.Et quis diam amet gubergren dignissim no justo sed lobortis et dolores duo lorem exerci stet kasd assum magna.Illum et consequat tempor ipsum id ad dolores ea ipsum eos.Aliquyam ipsum vel nonumy.Est clita dolor ipsum iusto in ut sed elit est aliquyam kasd ea ipsum sit tation eirmod et amet.Amet consectetuer labore sed sadipscing lorem no adipiscing et eirmod magna ut ea ipsum accusam dolor erat dolor diam.Consetetur no lorem diam labore est amet accusam eos kasd.Invidunt ipsum at at est.Gubergren tincidunt blandit nibh at takimata eum ut eu te stet hendrerit praesent feugiat suscipit assum amet et dolor.\nSed eirmod lorem iusto no.Erat consetetur amet kasd consetetur invidunt dolore.Qui gubergren et justo dolor dolore et est augue tempor stet ut dolore duo et ea.Tempor ipsum sadipscing et vero duis sea adipiscing rebum dolor stet erat ex sit euismod invidunt sed.Erat aliquyam amet accusam.Dolore ut ullamcorper et gubergren ut kasd diam duis eu lorem eos elit nonumy lorem no diam stet et.Et lorem vero rebum ut eirmod eirmod facilisi dolor tempor esse takimata aliquyam dolore ut labore ea.Ipsum rebum invidunt at dolores delenit doming enim sed sit diam tation.Duo aliquyam duo sit takimata.Imperdiet magna est autem est stet no no ipsum diam clita iriure et commodo sit ea nonumy.\nInvidunt dolor ipsum dolor dolor et delenit.Invidunt ut voluptua vel et feugait vero eirmod aliquip.Dolores ipsum dolore facilisis dignissim eum eirmod quis.Clita clita est tempor.",
            PublishDate = DateTime.Now,
            PageCount = 100
        };
        [TestMethod]
        public async Task TestGetBook()
        {

            _ = new List<Book>();

            IBookService servic = new BookService(http);
            List<Book>? list = await servic.Get();
            Assert.AreEqual(list.Count > 0, true);
        }
        [TestMethod]
        public async Task TestGetByIdBook()
        {
            var http = new HttpClient();
            _ = new Book();

            IBookService servic = new BookService(http);
            Book? book = await servic.GetById(1);
            Assert.AreEqual(book.Id > 0, true);
        }
        [TestMethod]
        public async Task TestCreateBook()
        {
            IBookService servic = new BookService(http);
            bool result = await servic.Create(book);
            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public async Task TestUpdateBook()
        {


            IBookService servic = new BookService(http);
            bool result = await servic.Update(900000, book);
            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public async Task TestDeleteBook()
        {
            var http = new HttpClient();
            _ = new Book();

            IBookService servic = new BookService(http);
            bool? result = await servic.Delete(900000);
            Assert.AreEqual(result, true);
        }
    }
}
