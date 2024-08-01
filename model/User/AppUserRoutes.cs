using Delivery.Models.User.Request;
using Delivery.Data;
using Delivery.Models.Users;

namespace Delivery.UserRoutes;

public static class UserRoutes
{
    public static void AppUserRoutes(this WebApplication app)
    {
        var UserRoutes = app.MapGroup("user");

        UserRoutes.MapGet("/test", () =>
        {
            return Results.Ok("Hello, World!");
        });

        UserRoutes.MapGet("/Create", async (AddUserRequest request, AppDbContext context) =>
        {
            var user = new User(request.name, request.email, request.password);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

        });
    }
}

