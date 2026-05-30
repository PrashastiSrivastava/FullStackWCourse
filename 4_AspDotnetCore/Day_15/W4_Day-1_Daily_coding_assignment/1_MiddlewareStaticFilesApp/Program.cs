var builder = WebApplication.CreateBuilder(args);

// Enforce HTTPS
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443;
});

var app = builder.Build();

// Custom middleware order
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<SecurityHeadersMiddleware>();

// HTTPS enforcement
app.UseHttpsRedirection();

// Serve static files from wwwroot
app.UseStaticFiles();

// Default route
app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
});

app.Run();