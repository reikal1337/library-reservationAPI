using library_reservation.Infrastructure.Extensions;
using library_reservation.Application;
using library_reservation.Infrastructure.Repositories;
using library_reservation.Infrastructure.Seeders;
using NET_core_api_tut.Filters;
using NET_core_api_tut.APIBehavior;

var builder = WebApplication.CreateBuilder(args);


//Infrastructure init.
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


builder.Services.AddControllers(option =>
    {
        option.Filters.Add(typeof(ParseBadRequest));
    }
).ConfigureApiBehaviorOptions(BadRequestsBahavior.Parse);


var app = builder.Build();


//Seeding db with some Book data.
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IBookSeeder>();
await seeder.Seed();





// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
