using Couchbase.Extensions.DependencyInjection;
using Couchbase.Linq;
using InvoiceManagementSystemPaymentApi.Business.Abstract;
using InvoiceManagementSystemPaymentApi.Business.Concrete;
using InvoiceManagementSystemPaymentApi.Repository.Abstract;
using InvoiceManagementSystemPaymentApi.Repository.Concrete;
using InvoiceManagementSystemPaymentApi.Subscriber;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCouchbase(opt =>
{
    builder.Configuration.GetSection("Couchbase").Bind(opt);
    opt.AddLinq();
});


builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();
builder.Services.AddSingleton<IPaymentBusiness, PaymentBusiness>();

builder.Services.AddSingleton<IMessageSubscriber, MessageSubscriber>();

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
