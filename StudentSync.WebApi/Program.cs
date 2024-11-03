using Microsoft.EntityFrameworkCore;
using StudentSync.Application;
using StudentSync.Data.Ef;
using StudentSync.Data.Ef.Common;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolDbContext>(
    options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("SchoolDb"));
    });

builder.Services.AddApplicatoinServices();
builder.Services.AddEFRepository();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
