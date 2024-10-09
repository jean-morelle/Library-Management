

//using Library_Management.Data;
using Library_Management.Repertory;
using Library_Management.Service;
using Microsoft.EntityFrameworkCore;
//using UtilisateurRepertory = Library_Management.Application.UtilisateurRepertory;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Library_Management.Data.ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped <IUtilisateurRepertory,Library_Management.Repertory.UtilisateurRepertory>();
builder.Services.AddScoped<IUtilisateurService,UtilisateurService>();
builder.Services.AddScoped<IEmpruntRepertory,Library_Management.Repertory.EmpruntRepertory>();
builder.Services.AddScoped<IEmpruntServices,EmpruntServices>();
builder.Services.AddScoped<ILivreRepertory, LivreRepertory>();
builder.Services.AddScoped<ILivreService,LivreService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
