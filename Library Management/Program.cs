using Librairi_Management.Domain.Interface;
using Librairi_Management.Domain.Models;
using Library_Management.Application.Service;
using Library_Management.Data;
using Library_Management.Infrastructure.Repertory;
using Library_Management.Repertory;
using Library_Management.Service;
using Microsoft.EntityFrameworkCore;

const string FrontendCorsPolicy = "Frontend";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ILivreRepertory,LivreRepertory>();
builder.Services.AddScoped<ILivreService,LivreServices>();
builder.Services.AddScoped<IEmpruntRepertory, LivreEmpruntRepertory>();
builder.Services.AddScoped<IEmpruntServices, LivreEmpruntersServices>();
builder.Services.AddScoped<IClientRepertory,ClientRepertory>();
builder.Services.AddScoped<IClientServices,ClientServices>();

var originesAutorisees = configuration.GetSection("Cors:Origins").Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
    options.AddPolicy(FrontendCorsPolicy, policy =>
        policy.WithOrigins(originesAutorisees).AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Crée / met à jour la base au démarrage
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Traduit les exceptions métier en réponses HTTP lisibles par le front
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (RegleMetierException ex)
    {
        await Results.Problem(detail: ex.Message, statusCode: StatusCodes.Status400BadRequest).ExecuteAsync(context);
    }
    catch (KeyNotFoundException ex)
    {
        await Results.Problem(detail: ex.Message, statusCode: StatusCodes.Status404NotFound).ExecuteAsync(context);
    }
});

// En développement le front passe par le proxy Vite en HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseCors(FrontendCorsPolicy);
app.UseAuthorization();
app.MapControllers();

app.Run();
