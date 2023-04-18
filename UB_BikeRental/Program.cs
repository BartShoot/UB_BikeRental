using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using UB_BikeRental.InMemoryDB;
using UB_BikeRental.Interfaces;
using UB_BikeRental.Mappings;
using UB_BikeRental.Models;
using UB_BikeRental.Services;
using UB_BikeRental.Validators;
using UB_BikeRental.ViewModel;

namespace UB_BikeRental
{
    public class Program
    {
        /*

        W Kontrolerach zmodyfikuj kod by wykorzystywać Automapper do przesyłania danych do i z Widoków.

        Zmodyfikuj ViewModele o parametry Walidujące

        Uruchomić i zweryfikować działanie walidacji po stronie klienta i serwera

        Stosując FluentValidation lub Własny Walidator zabezpieczyć datę Rezerwacji tak by Data Początkowa nie mogła być większa od Daty zakończenia rezerwacji
        */
        public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
            //var connectionString = builder.Configuration.GetConnectionString("RentalServiceDBConnection") ?? throw new InvalidOperationException("Connection string 'RentalServiceDBConnection' not found.");

            builder.Services.AddDbContext<RentalServiceDB>(x => x.UseInMemoryDatabase("Rental"));


            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IValidator<VehicleDetailsViewModel>, VehicleDetailsViewModelValidator>();
            builder.Services.AddScoped<IValidator<RentalPointDetailsViewModel>, RentalPointDetailsViewModelValidator>();
            builder.Services.AddScoped<IValidator<ReservationsDetailsViewModel>, ReservationDetailsViewModelValidator>();


			builder.Services.AddScoped<InMemoryRepository<Vehicle>>(sp =>
			{
				var dbContext = sp.GetRequiredService<RentalServiceDB>();
				return new InMemoryRepository<Vehicle>(dbContext);
			});

			builder.Services.AddScoped<IRepositoryService<Vehicle>, InMemoryRepository<Vehicle>>();
			builder.Services.AddScoped<InMemoryRepository<RentalPoint>>(sp =>
			{
				var dbContext = sp.GetRequiredService<RentalServiceDB>();
				return new InMemoryRepository<RentalPoint>(dbContext);
			});
			builder.Services.AddScoped<IRepositoryService<RentalPoint>, InMemoryRepository<RentalPoint>>();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<RentalServiceDB>();



            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            
            var dbContext = app.Services.CreateScope()
                .ServiceProvider.GetRequiredService<RentalServiceDB>();
            InitialData.Initialize(dbContext);
            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}