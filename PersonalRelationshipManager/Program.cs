using Microsoft.Extensions.Options;
using PersonalRelationshipManager.Relationships.Application;
using PersonalRelationshipManager.Relationships.Application.UseCases;
using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Domain.Repositories;
using PersonalRelationshipManager.Relationships.Infrastructure.Persistence;
using PersonalRelationshipManager.Relationships.Integration.Persistence;
using PersonalRelationshipManager.Shared;
using PersonalRelationshipManager.Shared.Infrastructure;
using PersonalRelationshipManager.Shared.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IUseCase<CreateRelationshipDto, Result<Relationship>>, CreateRelationshipUseCase>();
builder.Services.AddScoped<IRelationshipsRepository, PostgresRelationshipsesRepository>();
builder.Services.AddScoped<IMapper<Relationship, RelationshipData>, RelationshipMapper>();
builder.Services.AddScoped<IMigrationRunner, DbUpMigrationRunner>();
builder.Services.AddScoped<IGuidService, DefaultGuidService>();

var app = builder.Build();

// TODO: Find a better place/way to do this
var databaseSettings = app.Services.GetRequiredService<IOptions<DatabaseSettings>>();
RunMigration(databaseSettings);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

static void RunMigration(IOptions<DatabaseSettings> options)
{
    var dbUpMigrationRunner = new DbUpMigrationRunner(options);
    dbUpMigrationRunner.RunMigrations().Wait();
}

public partial class Program
{
}