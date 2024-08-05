using PersonalRelationshipManager.Relationships.Application;
using PersonalRelationshipManager.Relationships.Application.UseCases;
using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IUseCase<CreateRelationshipDto, Result<Relationship>>, CreateRelationshipUseCase>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public partial class Program
{
}