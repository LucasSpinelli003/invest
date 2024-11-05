using Microsoft.EntityFrameworkCore;
using InvestApi.Data;
using InvestApi.Services;

namespace InvestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona serviços ao contêiner de injeção de dependência
            builder.Services.AddControllers();

            // Adiciona o contexto do banco de dados com a conexão ao Oracle
            builder.Services.AddDbContext<InvestDbContext>(options =>
                options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Adiciona os serviços da aplicação
            builder.Services.AddScoped<IInvestorService, InvestorService>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IInvestmentService, InvestmentService>();
            builder.Services.AddScoped<AuthService>();

            // Adiciona o HttpClient, se necessário
            builder.Services.AddHttpClient<AuthService>();

            var app = builder.Build();

            // Configura o pipeline de requisições HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Middleware para redirecionamento de HTTP para HTTPS
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Autenticação e autorização (se necessário)
            // app.UseAuthentication();
            // app.UseAuthorization();

            // Mapeia os endpoints
            app.MapControllers();

            // Executa o aplicativo
            app.Run();
        }
    }
}
    