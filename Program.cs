using ApiGestaoProcessos.Data;
using Microsoft.EntityFrameworkCore;
using ApiGestaoProcessos.Profiles;
using ApiGestaoProcessos.Services;

var builder = WebApplication.CreateBuilder(args);

//Configuração do Entity Framework Core com MySql
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Swagger COnfig
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Api de Gestão de Processos",
        Version = "v1",
        Description = "Api desenvolvida em ASP.NET Core para gestão de processos",
    });
});

// registra o service para injeção de dependência
builder.Services.AddScoped<ProcessoService>();

// registra o automapper e carrega o profile
builder.Services.AddAutoMapper(config => 

config.AddProfile<ProcessoProfile>());


builder.Services.AddScoped<ClientesService>();

builder.Services.AddAutoMapper(config =>
config.AddProfile<ClientesProfile>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
