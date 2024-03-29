using RestAspNetStudio.Logic;
using RestAspNetStudio.Logic.Implementations;
using RestAspNetStudio.Data.Generic;
using RestAspNetStudio.Model.Context;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using EvolveDb;
using Serilog;
using RestAspNet8VStudio.Logic.Implementations;
using RestAspNet8VStudio.Logic;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection, 
    new MySqlServerVersion(new Version(8,0,36))));

if(builder.Environment.IsDevelopment())
{
    MigrateDataBase(connection);
}

builder.Services.AddApiVersioning();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserLogic, UserLogicImplementation>();
builder.Services.AddScoped<IHotelLogic, HotelLogicImplementation>();
builder.Services.AddScoped<IRoomLogic, RoomLogicImplementation>();
builder.Services.AddScoped<IPriceLogic, PriceLogicImplementation>();
builder.Services.AddScoped<IReservationLogic, ReservationLogicImplementation>();
builder.Services.AddScoped(typeof(IGenericData<>), typeof(GenericDataImplementation<>));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name : "MyPolicy",
        policy =>
        {
            policy
                .WithOrigins("http://127.0.0.1:5500") 
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void MigrateDataBase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection,
            msg => Log.Information(msg))
        {
            Locations = new List<string>() { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database Migration Failed", ex);
        throw;
    }
}


