using ECommerceApp.Data;
using ECommerceApp.Services;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                // This will use the property names as defined in the C# model
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure EF Core with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreDBConnection")));

            // Registering the CustomerService
            builder.Services.AddScoped<CustomerService>();
            // Registering the AddressService
            builder.Services.AddScoped<AddressService>();
            // Registering the CategoryService
            builder.Services.AddScoped<CategoryService>();
            // Registreing the ProductService
            builder.Services.AddScoped<ProductService>();
            // Registreing the ShoppingCartService
            builder.Services.AddScoped<ShoppingCartService>();
            // Registreing the OrderService
            builder.Services.AddScoped<OrderService>();
            // Registering the PaymentService
            builder.Services.AddScoped<PaymentService>();
            // Registering the EmailService
            builder.Services.AddScoped<EmailService>();
            // Registering the CancellationService
            builder.Services.AddScoped<CancellationService>();
            // Register Background Service
            builder.Services.AddHostedService<PendingPaymentService>();

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
        }
    }
}