using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation_ConsoleApp.Dialogs;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<iFileService>(new FileService("users.json"));
serviceCollection.AddSingleton<iUserService, UserService>();
serviceCollection.AddSingleton<MenuDialogs>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var menuDialogs = serviceProvider.GetRequiredService<MenuDialogs>();

menuDialogs.MainMenu();


