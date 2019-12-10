using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MilenioRadartonaAPI.Areas.Identity.Data;
using MilenioRadartonaAPI.Models;

[assembly: HostingStartup(typeof(MilenioRadartonaAPI.Areas.Identity.IdentityHostingStartup))]
namespace MilenioRadartonaAPI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<MilenioRadartonaAPIContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("postgres")));



                //services.AddDefaultIdentity<MilenioRadartonaAPIUser>()
                //    .AddEntityFrameworkStores<MilenioRadartonaAPIContext>();
            });

        }
    }
}