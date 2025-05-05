using SZOKITALALOAKASZTOFA_X6N2KU_RUTH.Data;
namespace SZOKITALALOAKASZTOFA_X6N2KU_RUTH

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IWordRepository, WordRepository>();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern:"{controller}/{action=Index}/{id?}"
                );
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.Run();
        }
    }
}
