using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SalmonCookiesAPI.Data;
using SalmonCookiesAPI.Models.Interfaces;
using SalmonCookiesAPI.Models.Services;


namespace SalmonCookiesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.
            builder.Services.AddDbContext<CookieStandDBContext>(options =>
            {
                options.UseSqlServer(connString);
            });

            builder.Services.AddTransient<ICookieStand, CookieStandService>();



            builder.Services.AddControllers().AddNewtonsoftJson(options =>
 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    }
                    );
            });


            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

         

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}