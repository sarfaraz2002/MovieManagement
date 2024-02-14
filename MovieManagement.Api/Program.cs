using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.DataContext;
using MovieManagement.DataAccess.Implementaions;
using MovieManagement.DataAccess.Service.ActorService;
using MovieManagement.DataAccess.Service.MovieService;
using MovieManagement.Domain.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddTransient<IActorService, ActorService>();
builder.Services.AddTransient<IMovieService,MovieService>();
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null));
builder.Services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<MovieManagementDbContext>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
