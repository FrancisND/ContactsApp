namespace ContactsApp;
using CommunityToolkit.Maui;
using ContactsApp.UseCases.Interfaces;
using ContactsApp.UseCases;
using ContactsApp.Plugins.DataStore.InMemory;
using ContactsApp.Views;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
		builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();
        builder.Services.AddSingleton<IViewContactUseCase, ViewContactUseCase>();
        builder.Services.AddTransient<IEditContactUseCase, EditContactUseCase>();
        builder.Services.AddTransient<IAddContactUseCase, AddContactUseCase>();

        builder.Services.AddSingleton<ContactsPage>();
        builder.Services.AddSingleton<EditContactPage>();
        builder.Services.AddSingleton<AddContactPage>();


		return builder.Build();
	}
}
