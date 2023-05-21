using HimlayanEverestInsurance.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("dbconnection")));
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage();    
} 
    
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllerRoute("","{Controller=Home}/{Action=Index}/{id?}"));

app.Run();
