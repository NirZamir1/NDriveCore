using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace NDriveCore;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.ConfigureS3ServicesDevelopment(builder.Configuration);
        builder.Services.ConfigureDb(builder.Configuration);
        
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        var client = app.Services.GetService<IAmazonS3>();
        if (client == null)
        {
            throw new InvalidOperationException("Cannot find the IAmazonS3 instance");
        }
        ListBucketsResponse response = await client.ListBucketsAsync();
        foreach (var responseBucket in response.Buckets)
        {
            Console.WriteLine(responseBucket.BucketName);
        }
    }

    private static void ConfigureS3ServicesDevelopment(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetAWSOptions("AWS:Garage");
        options.Credentials = new BasicAWSCredentials(configuration["AWS:Garage:AccessID"], configuration["AWS:Garage:AccessKeySecret"]);
        services.AddDefaultAWSOptions(options);
        services.AddAWSService<IAmazonS3>();
    }

    private static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres"), b => b.MigrationsAssembly("Repository"))
        );
    }
}