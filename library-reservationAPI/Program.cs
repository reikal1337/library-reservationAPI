using library_reservation.Infrastructure.Extensions;
using library_reservation.Infrastructure.Repositories;
using library_reservation.Infrastructure.Seeders;
using NET_core_api_tut.Filters;
using NET_core_api_tut.APIBehavior;
using library_reservation.Application;

var builder = WebApplication.CreateBuilder(args);


//Infrastructure init.
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddControllers(option =>
    {
        option.Filters.Add(typeof(ParseBadRequest));
    }
).ConfigureApiBehaviorOptions(BadRequestsBahavior.Parse);


//CORS config
builder.Services.AddCors(options =>
{
    var frontendUrl = builder.Configuration.GetValue<string>("FrontendUrl");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendUrl).AllowAnyMethod().AllowAnyHeader();
    });
});



var app = builder.Build();


//Seeding db with some Book data.
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IBookSeeder>();
await seeder.Seed();





// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
