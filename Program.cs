using Microsoft.EntityFrameworkCore;
using movies_api.data;
using movies_api.repositories;
using movies_api.contracts;
using movies_api.services;
using movies_api.mappers;
using SQLitePCL;
using System.Reflection;

Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<SessaoService>();
builder.Services.AddScoped<ISessaoRepository, SessaoRepository>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<SalaService>();
builder.Services.AddScoped<ISalaRepository, SalaRepository>();
builder.Services.AddScoped<AssentoService>();
builder.Services.AddScoped<IAssentoRepository, AssentoRepository>();

builder.Services.AddScoped<SalaMapper>();

builder.Services.AddOpenApi();
builder.Services.AddControllers(); // add mapamento de controllers
builder.Services.AddDbContext<MoviesContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Movies API",
        Version = "v1"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();