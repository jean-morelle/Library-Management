

//using Library_Management.Data;
using Librairi_Management.Domain.Interface;
using Library_Management.Application.Service;
using Library_Management.Infrastructure.Repertory;
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
builder.Services.AddScoped<ILivreRepertory,LivreRepertory>();
builder.Services.AddScoped<ILivreService,LivreServices>();
builder.Services.AddScoped<IEmpruntRepertory, LivreEmpruntRepertory>();
builder.Services.AddScoped<IEmpruntServices, LivreEmpruntersServices>();
builder.Services.AddScoped<IClientRepertory,ClientRepertory>();
builder.Services.AddScoped<IClientServices,ClientServices>();
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
