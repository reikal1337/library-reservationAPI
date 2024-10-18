
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

                new Book { Id = 1, Name = "The Great Gatsby", ImageSrc = "https://images.thegreatestbooks.org/mett28u51a92h6yh90le1pbn8aai", Year = 1925, Types = new List<string>() { "book" } },
                new Book { Id = 2, Name = "Ulysses", ImageSrc = "https://images.thegreatestbooks.org/sbd37b2dsyuw15cv63l87biw63kv", Year = 1922, Types = new List<string>() { "book", "audiobook" } },
                new Book { Id = 3, Name = "In Search of Lost", ImageSrc = "https://images.thegreatestbooks.org/myvbhitdua7h1etye2hvfjej2p4j", Year = 1913, Types = new List<string>() { "book" } },
                new Book { Id = 4, Name = "One Hundred Years of Solitude", ImageSrc = "https://images.thegreatestbooks.org/fzce7ac1jcmx6fi8ppnea65ct3u9", Year = 1967, Types = new List<string>() { "book", "audiobook" } },
                new Book { Id = 5, Name = "The Catcher in the Rye", ImageSrc = "https://images.thegreatestbooks.org/azrr7j37ttxak2wmpmdoczhvd36t", Year = 1951, Types = new List<string>() { "book", "audiobook" } },
                new Book { Id = 6, Name = "Lolita", ImageSrc = "https://images.thegreatestbooks.org/t9epsngv7thxsjalsswqzgtnzlpu", Year = 1955, Types = new List<string>() { "book" } },
                new Book { Id = 7, Name = "Nineteen Eighty Four", ImageSrc = "https://images.thegreatestbooks.org/oka7y4u1r23osldhnx42q9lvxtpz", Year = 1949, Types = new List<string>() { "book" } },
                new Book { Id = 8, Name = "Anna Karenina", ImageSrc = "https://images.thegreatestbooks.org/m8kb7ah2lhy960dbp473zna11wb4", Year = 1877, Types = new List<string>() { "book" } },
                new Book { Id = 9, Name = "Moby-Dick", ImageSrc = "https://images.thegreatestbooks.org/4zdrnqgrbobtunihoxvad8kxotot", Year = 1851, Types = new List<string>() { "audiobook" } },
                new Book { Id = 10, Name = "Wuthering Heights", ImageSrc = "https://images.thegreatestbooks.org/8lg4exp38r6236mjmp8nkx4k3k2j", Year = 1847, Types = new List<string>() { "book" } },
                new Book { Id = 11, Name = "Pride and Prejudice", ImageSrc = "https://images.thegreatestbooks.org/hfiptkzo82hkprq8p4yfxoxb8pns", Year = 1813, Types = new List<string>() { "book" } },

            ];

            return books;
        }
    }
}
