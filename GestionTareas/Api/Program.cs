using GestionTareas.Application;
using GestionTareas.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Registrar Capas de Clean Architecture
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilitar CORS para Angular 22
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", b =>
        b.WithOrigins("http://localhost:4200") // Puerto estándar de desarrollo Angular
         .AllowAnyMethod()
         .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
