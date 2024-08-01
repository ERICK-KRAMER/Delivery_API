namespace Delivery.UseRoutes
{
    public static class User
    {
        public static void AppUserRoutes(this WebApplication app)
        {
            var UserRoutes = app.MapGroup("user");

            UserRoutes.MapGet("/test", () =>
            {
                return Results.Ok("Hello, World!");
            });
        }
    }
}
