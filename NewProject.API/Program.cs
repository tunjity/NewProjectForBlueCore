using Microsoft.EntityFrameworkCore;
using NewProject.Domain;
using NewProject.Repository;
using NewProject.Repository.Services;
using NewProject.Utility;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NPDbContext>(opt => opt.UseSqlServer(conn));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICompanyService,CompanyService>();
//builder.Services.AddScoped(typeof(ICompanyService), typeof(CompanyService));
//builder.Services.AddScoped(typeof(ICompanyService), typeof(CompanyService));
//builder.Services.AddScoped(typeof(ICompanyService), typeof(CompanyService));
//builder.Services.AddScoped(typeof(ICompanyService), typeof(CompanyService));
//builder.Services.AddScoped(CompanyService, ICompanyService);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(Program));
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

//ransaction/get-receipt-details-bynumberorVehN