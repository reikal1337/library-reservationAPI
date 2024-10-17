
using library_reservationAPI.Db;
using library_reservationAPI.Entities;

namespace library_reservation.Infrastructure.Seeders
{
    internal class BookSeeder(AppDbContext context) : IBookSeeder
    {
        public async Task Seed()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Books.Any())
                {
                    var books = GetBooks();
                    context.Books.AddRange(books);
                    await context.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Book> GetBooks()
        {
            List<Book> books = [

                new Book { Id = 1, Name = "The Great Gatsby", ImageSrc = "https://images.thegreatestbooks.org/mett28u51a92h6yh90le1pbn8aai", Year = 1925, Type = new[] { "book" } },
                new Book { Id = 2, Name = "Ulysses", ImageSrc = "https://images.thegreatestbooks.org/sbd37b2dsyuw15cv63l87biw63kv", Year = 1922, Type = new[] { "book", "audiobook" } },
                new Book { Id = 3, Name = "In Search of Lost", ImageSrc = "https://images.thegreatestbooks.org/myvbhitdua7h1etye2hvfjej2p4j", Year = 1913, Type = new[] { "book" } },
                new Book { Id = 4, Name = "One Hundred Years of Solitude", ImageSrc = "https://images.thegreatestbooks.org/fzce7ac1jcmx6fi8ppnea65ct3u9", Year = 1967, Type = new[] { "book" } },
                new Book { Id = 5, Name = "The Catcher in the Rye", ImageSrc = "https://images.thegreatestbooks.org/azrr7j37ttxak2wmpmdoczhvd36t", Year = 1951, Type = new[] { "book" } }
            ];

            return books;
        }
    }
}
