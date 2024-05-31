using System.Text.Json.Serialization;
using Asp.Versioning;
using BookBeacon.API.Helpers;
using BookBeacon.BL;
using BookBeacon.DAL;

namespace BookBeacon.API;

public static class StartupHelper
{
    public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
    {
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
        
        app.UseHttpsRedirection();
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
    
}