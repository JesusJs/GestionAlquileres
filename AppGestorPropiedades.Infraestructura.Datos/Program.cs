using AppGestorPropiedades.Dominio.Entidades;
using AppGestorPropiedades.Dominio.Interfaces;
using AppGestorPropiedades.Dominio.Interfaces.Repositorios;
using AppGestorPropiedades.Infraestructura.Datos.Mappers;
using AppGestorPropiedades.Infraestructura.Datos.Repositorios;
using AppGrestorPropiedades.Application.Interfaces;
using AppGrestorPropiedades.Application.UseCase;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();

        // ... other service registrations (if any)
        services.AddScoped<MappingProfile>();
        services.AddScoped<IGestorPropiedadesUseCase, GestorPropiedadesUseCase>();
        services.AddScoped<IRepositorioBase<Propiedades>, PropiedadesRepositorio>();
        services.AddAutoMapper(typeof(MappingProfile));

        //services.AddSingleton<IMapper>(sp => sp.GetRequiredService<AutoMapper.IConfigurationProvider>().CreateMapper())
        services.AddScoped<AutoMapperFactory>();
        var serviceProvider = services.BuildServiceProvider();
    }
}