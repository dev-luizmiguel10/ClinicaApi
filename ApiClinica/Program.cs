
using ApiClinica.Application.DI;
using ApiClinica.Converter;
using ApiClinica.FiltroException;
using ApiClininca.Infraestrutura.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(s=>s.JsonSerializerOptions.Converters.Add(new StringConverter()));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.InjecaoDependenciaApp();

builder.Services.AddMvc(s => s.Filters.Add(new FiltroException()));


builder.Services.InjecaoDepedencia(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
