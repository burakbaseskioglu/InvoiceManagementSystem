using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Business.Concrete;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IApartmentRepository, ApartmentRepository>();
builder.Services.AddSingleton<IApartmentBusiness, ApartmentBusiness>();

builder.Services.AddSingleton<ISuiteRepository, SuiteRepository>();
builder.Services.AddSingleton<ISuiteBusiness, SuiteBusiness>();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserBusiness, UserBusiness>();

builder.Services.AddSingleton<IDuesRepository, DuesRepository>();
builder.Services.AddSingleton<IDuesBusiness, DuesBusiness>();

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
