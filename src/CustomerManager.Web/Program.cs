
using CustomerManager.Infrastructure;
using CustomerManager.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataConnection(builder.Configuration);

builder.Services.AddDependences();

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.PropertyNamingPolicy = null; // Desabilita formato camelCase nos resultados em JSON
	});

var customerCorsPolityName = "_customerPolicyName";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: customerCorsPolityName,
                      policy =>
                      {
						  policy.AllowAnyOrigin();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors(customerCorsPolityName);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
