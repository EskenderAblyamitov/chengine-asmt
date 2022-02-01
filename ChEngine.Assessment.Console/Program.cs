using ChEngine.Assessment.Composition;
using ChEngine.Assessment.Console;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Add and build configuration (to support config files)
var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

// Add services to the container and build service provider
var serviceProvider = new ServiceCollection()
                .RegisterTypes()
                .AddSingleton<IConfiguration>(configBuilder)
                .BuildServiceProvider();

// Execute business logic
var businessLogic = new BusinessLogic(serviceProvider);
await businessLogic.Run();

Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();