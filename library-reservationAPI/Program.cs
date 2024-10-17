using library_reservation.Infrastructure.Extensions;
using library_reservation.Application;
using library_reservation.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DbConnection"))
//    );



builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


builder.Services.AddControllers();


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//    // Ensures db data population.
//    context.Database.EnsureCreated();
//}






// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
