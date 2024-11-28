using Agenda_Lieraria2._0.Repositorio.Livros;
using Agenda_Lieraria2._0.Repositorio.Sessao;
using Agenda_Lieraria2._0.Repositorio.Usuario;

namespace Agenda_Lieraria2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<ISessao, Sessao>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ILivros, Livros>();


            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;                 // Impede que o JavaScript acesse o cookie de sessão
                options.Cookie.IsEssential = true;              // Garante que o cookie de sessão seja transmitido mesmo que o usuário não consinta
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expiração da sessão
            });

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

            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
