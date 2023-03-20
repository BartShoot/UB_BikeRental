namespace UB_BikeRental
{
    public class Program
    {
        /*
        Utworzyć projekt, który będzie stopniowo rozbudowywany
        -Wykonać modyfikację layoutu
            -Wprowadzić nagłówek portalu (ATH Bike Rental System)
            -Stworzyć stopkę z informacjami kontaktowymi
        -Przygotować widok domyślny z informacjami o portalu
            -Z wyeksponowaną nazwą
            -Opisem działania
            -Przykładowymi zdjęciami
        -Przygotować ViewModele do Obsługi Listy Pojazdów
            VehicleDetailViewModel – do prezentacji szczegółów pojedynczego pojazdu
            VehicleItemViewModel – do prezentacji pozycji na liście pojazdów
        -Przygotować Controller Vehicles i Widoki do prezentacji listy Pojazdów i Danych dla wybranego Pojazdu
        -Zaprezentować Widoki dla danych testowych
        */
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}