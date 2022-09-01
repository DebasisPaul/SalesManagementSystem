using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Data;
using SalesManagementApp.Services;
using SalesManagementApp.Services.Contracts;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SalesManagementDbConnection")
                        ?? throw new InvalidOperationException("Connection 'SalesManagementDbConnection' not found");

builder.Services.AddDbContext<SalesManagementDbContext>(
        options => options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSyncfusionBlazor();

builder.Services.AddScoped<IEmployeeManagementService, EmployeeManagementService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISalesOrderReportService, SalesOrderReportService>();
builder.Services.AddScoped<IOrganisationService, OrganisationService>();





var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHJqVVhjWlpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF9jQXxQdk1hWHtbdHFXRA==;Mgo+DSMBPh8sVXJ0S0R+XE9HcFRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3xTfkdgWXdccXBQQmZZUw==;ORg4AjUWIQA/Gnt2VVhiQlFadVlJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdk1hWn9WcnVRQ2RbVkY=;NzAyNDE2QDMyMzAyZTMyMmUzMGQ5aDUyR1BROTFRRTFkWUxGRkZWWWRKZC9ldkdjaUJ0Smp1ZlJNQ2pZMEE9;NzAyNDE3QDMyMzAyZTMyMmUzMFlTdjV1ZmFuakxXaU9QNXhETXR4QUZTM2xGVVFjK0ZScXQ1cDRnR0xQWjg9;NRAiBiAaIQQuGjN/V0Z+Xk9EaFxEVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdEVrW3xeeHZUQmVZVUJ0;NzAyNDE5QDMyMzAyZTMyMmUzMElUK1EzUk1WbmVoUkNKOTNBWnN0dnc4Um5nRkQ4N2FxNENSeFZpdG42OFE9;NzAyNDIwQDMyMzAyZTMyMmUzMG8ybVFyVjhiMkcyU0xiMGFYRU9pcnZXRmNlNTNPb2U1cnRtT0pla3A1MWs9;Mgo+DSMBMAY9C3t2VVhiQlFadVlJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdk1hWn9WcnVRQ2ZdU0Y=;NzAyNDIyQDMyMzAyZTMyMmUzME1BVUg5citlV3VHNkhBSjJZbmNWYjdmTklMaWcrZ1dUeXhYRGdjVTBsYUU9;NzAyNDIzQDMyMzAyZTMyMmUzMGJrT1czWStUL25LRkM5TWg3YW54eWtOSkR2eU5Xa3VXdnJndWVLOU5tYVk9;NzAyNDI0QDMyMzAyZTMyMmUzMElUK1EzUk1WbmVoUkNKOTNBWnN0dnc4Um5nRkQ4N2FxNENSeFZpdG42OFE9");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
