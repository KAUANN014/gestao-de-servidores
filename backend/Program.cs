
using GerenciamentoServidores.Data;
using GerenciamentoServidores.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ?? Configurando MySQL ao invés de SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IServidorService, ServidorService>();
builder.Services.AddScoped<IOrgao, OrgaoService>();
builder.Services.AddScoped<ILotacao, LotacaoService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Permite apenas a origem http://localhost:4200
              .AllowAnyHeader() // Permite qualquer cabeçalho
              .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
              .AllowCredentials(); // Permite o envio de cookies e outras credenciais
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowLocalhost4200");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
