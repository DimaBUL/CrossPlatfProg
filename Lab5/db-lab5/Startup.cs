using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Okta.AspNetCore;

namespace db_lab5
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.HttpOnly = true;
				options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
			})
			.AddAuthentication(options =>
			{
				options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

			})
			.AddCookie()
			.AddOktaMvc(new OktaMvcOptions
			{
				OktaDomain = "https://dev-26974945.okta.com/",
				AuthorizationServerId = "default",
				ClientId = "0oa7i6hlsaXb4lhN05d7",
				ClientSecret = "KRntj1rWkGtMjUCAg-TnoJ0K9fjDfgEv3J_JpMdW",
				Scope = new List<string> { "openid", "profile", "email", "phone" },

			});
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
