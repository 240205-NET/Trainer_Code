using Microsoft.AspNetCore.DataProtection.Repositories;
using TheGarden.DL;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("TheGarden") ?? throw new ArgumentNullException(nameof(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository>(sp => new SqlRepository(connectionString, sp.GetRequiredService<ILogger<SqlRepository>>()));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allow_all_origins",
                      policy  =>
                      {
                          policy.WithOrigins("*");
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
app.UseCors("allow_all_origins");

app.UseAuthorization();

app.MapControllers();

app.Run();
