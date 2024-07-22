using RestAspNetStudio.Logic;
using RestAspNetStudio.Logic.Implementations;
using RestAspNetStudio.Data.Generic;
using RestAspNetStudio.Model.Context;
using Microsoft.EntityFrameworkCore;
using EvolveDb;
using Serilog;
using Npgsql;
using RestAspNet8VStudio.Logic.Implementations;
using RestAspNet8VStudio.Logic;
using Microsoft.OpenApi.Models;
using RestAspNetStudio.Model.Mappings;
using Dapper.FluentMap;
using RestAspNet8VStudio.Model.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("PostgreSQLConnectionString");
builder.Services.AddSingleton<DapperContext>();

if (builder.Environment.IsDevelopment())
{
    MigrateDataBase(connection);
}

builder.Services.AddApiVersioning();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
                 new OpenApiInfo
                 {
                     Title = "REST API",
                     Version = "v1",
                     Description = "API developer by Adriel Alexander at XPE",
                     Contact = new OpenApiContact
                     {
                         Url = new Uri("https://adriel.streamlit.app/")
                     }
                 });
});

builder.Services.AddScoped<IUserLogic, UserLogicImplementation>();
builder.Services.AddScoped<IHotelLogic, HotelLogicImplementation>();
builder.Services.AddScoped<IRoomLogic, RoomLogicImplementation>();
builder.Services.AddScoped<IPriceLogic, PriceLogicImplementation>();
builder.Services.AddScoped<IReservationLogic, ReservationLogicImplementation>();
builder.Services.AddScoped(typeof(IGenericData<>), typeof(GenericDataImplementation<>));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy
                .WithOrigins("http://127.0.0.1:5500")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

FluentMapper.Initialize(config =>
{
    config.AddMap(new UserMap());
    config.AddMap(new HotelMap());
    config.AddMap(new PriceMap());
    config.AddMap(new ReservationMap());
    config.AddMap(new RoomMap());
});

var app = builder.Build();

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
                      "API developer by Adriel Alexander at XPE");
});

app.UseAuthorization();

app.MapControllers();

app.Run();

void MigrateDataBase(string connection)
{
    try
    {
        var evolveConnection = new NpgsqlConnection(connection);
        var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
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
