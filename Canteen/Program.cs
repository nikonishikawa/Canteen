using Canteen.Auth;
using Canteen.AuthServices;
using CanteenClassLibrary.Entities;
using CanteenClassLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CanteenContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
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

builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IUserAuthenticationServices, UserAuthenticationServices>();
//identity
builder.Services.AddIdentity<ApplicationIdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
    options.SignIn.RequireConfirmedAccount = true;
}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationContext>()
.AddDefaultTokenProviders()
.AddTokenProvider("userIdentity", typeof(DataProtectorTokenProvider<ApplicationIdentityUser>));

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option => {

    option.SaveToken = false;

    option.RequireHttpsMetadata = false;

    option.TokenValidationParameters = new TokenValidationParameters()

    {

        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,

        ClockSkew = TimeSpan.Zero,

        ValidAudience = builder.Configuration["JWT:ValidAudience"],

        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]!))


    };

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseForwardedHeaders();
}

app.UseHsts();

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
