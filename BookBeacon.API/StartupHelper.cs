using System.Text.Json.Serialization;
using BookBeacon.DAL;

namespace BookBeacon.API;

public static class StartupHelper
{
    public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
    {
        #region Formatters options

        builder.Services.AddControllers();
        #endregion
        
        builder.Services.AddDalServices(builder.Configuration);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAuthorization();
// builder.Services.AddAuthentication("Bearer")
//     .AddJwtBearer("Bearer", options =>
//     {
//         options.Authority = "https://localhost:5001";
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateAudience = false
//         };
//     });
//
// builder.Services.AddIdentityCore<User>();
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
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers(); 
         
        return app; 
    }
    
}