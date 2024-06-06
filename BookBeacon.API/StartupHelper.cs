using System.Text;
using System.Text.Json.Serialization;
using Asp.Versioning;
using BookBeacon.API.Helpers;
using BookBeacon.BL;
using BookBeacon.DAL;
using BookBeacon.DAL.Context;
using BookBeacon.Models.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BookBeacon.API;

public static class StartupHelper
{
    public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        
        #region Formatters options
        builder.Services.AddControllers(options =>
            {
                options.InputFormatters.Insert(0, JsonPatchInputFormatter.GetJsonPatchInputFormatter());
                // options.ReturnHttpNotAcceptable = true;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions
                        .NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals |
                                          JsonNumberHandling.AllowReadingFromString;
            });
        #endregion
        
        #region Register layers services
        builder.Services.AddDalServices(builder.Configuration);
        builder.Services.AddBlServices();
        builder.Services.AddApiServices();
        #endregion
        
        #region API Versioning
        builder.Services.AddApiVersioning(setupAction =>
        {
            setupAction.AssumeDefaultVersionWhenUnspecified = true; // this line assumes the default api version when the client doesn't specify the api version
            setupAction.DefaultApiVersion = new ApiVersion(1, 0); // this line sets the default api version
            setupAction.ReportApiVersions = true; // this line adds the api version to the response header
        }).AddMvc();
        #endregion
        
        #region Swagger
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        #endregion
        
        
        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<BookBeaconContext>();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, Options =>
            {
                Options.SaveToken = true;

                Options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,  
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateAudience = true,    
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateLifetime = true , 
                    ValidateIssuerSigningKey = true ,   
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                };
            }); 

        builder.Services.AddAuthorization(options =>
        {
            //
            // options.AddPolicy("AdminOnly", policy =>
            //     policy.RequireRole("Admin"));
            //
            // options.AddPolicy("UserOnly", policy =>
            //     policy.RequireRole("User"));
        });
        
        
        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseExceptionHandler();
        // if (app.Environment.IsDevelopment())
        // {
        //     app.UseDeveloperExceptionPage();
        // }
        // else
        // {
        //     app.UseExceptionHandler(appBuilder =>
        //     {
        //         appBuilder.Run(async context =>
        //         {
        //             context.Response.StatusCode = 500;
        //             await context.Response.WriteAsync(
        //                 "An unexpected fault happened. Try again later.");
        //         });
        //     });
        // }
        return app; 
    }
    
    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetService<BookBeaconContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // //var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                // logger.LogError(ex, "An error occurred while migrating the database.");
            }
        } 
    }
}
