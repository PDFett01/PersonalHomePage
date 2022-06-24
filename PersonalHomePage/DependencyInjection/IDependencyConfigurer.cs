namespace PersonalHomePage.DependencyInjection;

public interface IDependencyConfigurer 
{
    void ConfigureDependencyInjection(IServiceCollection services, IConfiguration configuration);
}
