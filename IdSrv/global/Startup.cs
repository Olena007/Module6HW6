namespace global
{
    public class Startup
    {
        //public IConfiguration configRoot { get; }
        //public Startup(IConfiguration configuration)
        //{
        //    configRoot = configuration;
        //}
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddIdentityServer()
                .AddInMemoryClients(Config.Clients)
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiResources(Config.ApiResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddTestUsers(Config.Users)
                .AddDeveloperSigningCredential();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            //app.UseAuthorization();

             
            //app.MapRazorPages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            //app.Run();
        }
    }
}
