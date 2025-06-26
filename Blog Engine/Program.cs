using BlogEngine.Application.Interfaces;
using BlogEngine.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();


builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();


