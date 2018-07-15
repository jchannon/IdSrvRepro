using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IdSrvRepro
{
  class Program
  {
    static async Task Main(string[] args)
    {
      using (var host = new WebHostBuilder()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseKestrel()
                        .ConfigureServices(services =>
                        {
                          services.AddMvc();

                          services.AddAuthorization();

                          services.AddIdentityServer()
                                  .AddDeveloperSigningCredential()
                                  .AddInMemoryClients(Clients.Get())
                                  .AddInMemoryApiResources(Scopes.GetApiScopes())
                            ;

                          services.AddAuthentication("Bearer")
                                  .AddIdentityServerAuthentication(x =>
                                  {
                                    x.Authority = "http://localhost:5000";
                                    x.ApiName = "myapi";
                                    x.RequireHttpsMetadata = false;
                                  });
                        })
                        .Configure(app => app
                                          .UseStaticFiles()
                                          .UseIdentityServer()
                                          .UseAuthentication()
                                          .UseMvcWithDefaultRoute()
                        )
                        .ConfigureLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Trace))
                        .Build())
      {
        await host.RunAsync();
      }
    }
  }
}
