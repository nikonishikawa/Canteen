using CanteenClassLibrary.Entities;
using CanteenClassLibrary.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CanteenContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultCon")));

builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<INameService, NameService>();
builder.Services.AddScoped<ICredentialService, CredentialService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IGeneralAddressService, GeneralAddressService>();
builder.Services.AddScoped<IMembershipService, MembershipService>();
builder.Services.AddScoped<IUserStatusService, UserStatusService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IParcelInfoService, ParcelInfoService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IShippingStatusService, ShippingStatusService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICourierService, CourierService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ITrayItemService, TrayItemService>();
builder.Services.AddScoped<ITrayStatusService, TrayStatusService>();
builder.Services.AddScoped<ITrayService, TrayService>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IArchiveService, ArchiveService>();
builder.Services.AddScoped<IAdminService, AdminService>();


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
