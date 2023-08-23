namespace ReverseProxy_Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddReverseProxy()
                .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("https://localhost:7110/swagger");
                }
                else
                {
                    await next();
                }
            });

            app.MapReverseProxy();

            app.Run();
        }
    }
}