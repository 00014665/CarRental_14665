using CarRental_14665.Data.Models;
using CarRental_14665.Data.Repositories;
using CarRental_14665.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container. 

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle 
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddDbContext<GeneralDbContext>(
            o => o.UseSqlServer(
                builder.Configuration.GetConnectionString("CarRentalDbContextConnectionString")));

        builder.Services.AddScoped<IRepository<Rentals>, RentalRepository>();
        builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();

        //// Configure JSON serialization 
        //builder.Services.AddControllers().AddJsonOptions(options => 
        //{ 
        //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve; 
        //}); 



        var app = builder.Build();

        // Configure the HTTP request pipeline. 
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();



        app.Run();
    }
}