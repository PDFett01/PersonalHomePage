using PersonalHomePage.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var movieApiKey = builder.Configuration["Movies:ServiceApiKey"];

IConfiguration configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services, configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapGet("/hello", () => {
    return new List<string>() {
        "Hello World!",
        "Hello Galaxy!",
        "Hello Universe!"
    };
});

app.MapDefaultControllerRoute();

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration) 
{
    var dc = new DependencyConfigurer();
    dc.ConfigureDependencyInjection(services, configuration);
    services.AddSingleton<IDependencyConfigurer>(dc);

    services.AddHttpClient();
}