using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Shared;
using MudBlazor;
using MudBlazor.Services;

namespace OE.Theme.LHB.Services
{
    public class MudService : IServerStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMudServices();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //no op
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            //no op
        }


    }
}