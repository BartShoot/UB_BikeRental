namespace UB_BikeRental
{
    public class Program
    {
        /*
        Stwórz Klasy stanowiące model danych dla potrzebnego systemu
        Zdefiniuj typy określające model danych a docelowo tabele w bazie danych
        Typ Pojazdu
        Pojazd,
        PunktyWypozyczen
        Rezerwacje (pojazdów)

        Jako dane użytkowników będą wykorzystywane tabele uzyskane przez odpowiednie stworzenie DBContextu
        Zdefiniuj DbContext (można wykorzystać wygenerowaną klasę ApliactionDbContext) zawierający odpowiednie tabele. (Wywodząc DbContext od IdentityDbContex można uzyskać obsługę użytkowników).
        Zdefiniuj Serwis Implementujący wzorzec Repository służący do wykonania podstawowych operacji CRUD na wybranej tabeli
        Skonfiguruj aplikację by Kontekst Bazodanowy był połączony z testową baza w Pamięci. (InMemory, options.UseInMemory ....) 
        Skonfiguruj mechanizm wstrzykiwania dla stworzonego wzorca Repository.
        Stwórz  Kontroler służący do Wprowadzania Danych Pojazdów (implementujący CRUD). (Można wykorzystać scaffolding.).
        Kontroler Docelowo powinien wykorzystywać wstrzykiwane repozytorium.
        Wygeneruj widoki dla akacji w kontrolerze.
        Stwórz  Kontroler służący do Wprowadzania Punktów Wypożyczeń (implementujący CRUD). (Można wykorzystać scaffolding.).
        Kontroler Docelowo powinien wykorzystywać wstrzykiwane repozytorium.
        Wygeneruj widoki dla akacji w kontrolerze.
        W wyświetlaniu korzystaj z ViewModeli pojazdów zdefiniowanych w ramach Laboratorium 01. (Jeśli trzeba - rozbuduj View Modele o rzeczy związane z typem).
        Zbuduj ViewModele dla Punktów Wypozyczeń i zastosuje je w odpowiednich widokach
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