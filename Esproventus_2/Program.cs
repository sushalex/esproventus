using Esproventus_2.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Esproventus_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
      DateTime startTime = DateTime.Now;
      DateTime endTime = DateTime.Now.AddSeconds(301);


      double sec = endTime.Subtract(startTime).TotalSeconds;

      var aasd = Format2(startTime, endTime);


      app.Run();
        }
         

    public static string Format2(DateTime date, DateTime current)
    {
      if (date == DateTime.MinValue || current == DateTime.MinValue)
      {
        throw new System.Exception("Date could not have min value.");
      }

      double sec = 0;
      if (current > date)
      {
        sec = current.Subtract(date).TotalSeconds;
      }

      if (current < date)
      {
        sec = date.Subtract(current).TotalSeconds;
      }

      if (sec < 60)
      {
        return $"{sec} seconds(s) ago";
      }

      if (sec >= 60 && sec < 3600)
      {
        int minutes = (int)sec / 60;
        return $"{minutes} minutes(s) ago";
      }
      if (sec >= 3600 && sec < 86400)
      {
        int hours = (int)sec / 3600;
        return $"{hours} hours(s) ago";
      }

      if (sec >= 86400)
      {
        int days = (int)sec / 86400;
        return $"{days} days(s) ago";
      }

      return "";
    }


  }
}