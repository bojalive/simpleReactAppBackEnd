using Microsoft.EntityFrameworkCore;
using ReactApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<AppDBContext>(
//    op => op.UseSqlServer
//    (@"Data Source=SLB-BZVF7G3\SQLEXPRESS2012;Initial Catalog=App;Trusted_Connection=True;Connection Timeout=60;")
//    );
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORSPolicy",
                      policy =>
                      {
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                          policy.WithOrigins("http://localhost:3000",
                                              "http://localhost:3001");
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");
app.MapGet("/get-all-posts", async () => await PostsRepository.GetPostData());
app.MapGet("/get-post-id", async (int id) =>
{
    Post postToReturn = await PostsRepository.GetPostById(id);
    var x = (postToReturn != null) ? Results.Ok(postToReturn) : Results.BadRequest();
    return x;
});
app.MapPost("/create-post", async (Post postToCreate) =>
{
    return await PostsRepository.CreatePostByID(postToCreate);
});

app.MapDelete("/post-delete", async (int id) =>
{
    return await PostsRepository.DeletePostById(id);
});
app.Run();

