using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Business.Concrete;
using InvoiceManagementSystem.DataAccess;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.DataAccess.Concrete.EntityFramework;
using InvoiceManagementSystem.Entity.Entities.Concrete.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();
builder.Services.AddScoped<IApartmentBusiness, ApartmentBusiness>();

builder.Services.AddScoped<ISuiteRepository, SuiteRepository>();
builder.Services.AddScoped<ISuiteBusiness, SuiteBusiness>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();

builder.Services.AddScoped<IDuesRepository, DuesRepository>();
builder.Services.AddScoped<IDuesBusiness, DuesBusiness>();

builder.Services.AddScoped<IUserAssignRepository, UserAssignRepository>();
builder.Services.AddScoped<IUserAssignBusiness, UserAssignBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
