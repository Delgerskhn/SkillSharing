using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApi.Helpers;
using WebApi.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using WebApi.Auth;
using Microsoft.AspNetCore.Http;
using WebApi.Models;
using WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using WebApi.Extensions;
using System.Security.Claims;

namespace WebApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // use sql server db in production and sqlite db in development
            string connectionStr = _env.IsProduction() ? "ProdDb" : "DevDb";
            services.AddDbContext<ApplicationDbContext>(builder=> {
                builder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")
                    //,b => b.MigrationsAssembly("AngularASPNETCore2WebApiAuth")
                    );
            });

            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            // configure strongly typed settings objects
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var jwtAppSettingOptions = _configuration.GetSection(nameof(JwtIssuerOptions));
            var appSettings = appSettingsSection.Get<AppSettings>();
            var _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret)); ;

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });


            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
               options.AddPolicy("ApiUser", policy => policy.RequireClaim(
                   Constants.Strings.JwtClaimIdentifiers.Rol, 
                   Constants.Strings.JwtClaims.ApiAccess, 
                   ClaimTypes.Role));
            });

            // add identity
            var builder = services.AddIdentityCore<AppUser>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            
            builder.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

           

           

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkillShareApi v1"));
            }

            app.UseExceptionHandler(
               builder =>
               {
                   builder.Run(
                                async context =>
                           {
                               context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                               context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                               var error = context.Features.Get<IExceptionHandlerFeature>();
                               if (error != null)
                               {
                                   context.Response.AddApplicationError(error.Error.Message);
                                   await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                               }
                           });
               });

            app.UseHttpsRedirection();
            // migrate any database changes on startup (includes initial db creation)
            dataContext.Database.Migrate();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
