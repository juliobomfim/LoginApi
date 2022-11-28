using LoginApiJCBomfim.Business.Services;
using LoginApiJCBomfim.Domain.Contracts.Repositories;
using LoginApiJCBomfim.Domain.Contracts.Services;
using LoginApiJCBomfim.Domain.Contracts.Uow;
using LoginApiJCBomfim.Infra.Contexts;
using LoginApiJCBomfim.Infra.Repository;
using LoginApiJCBomfim.Infra.Uow;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SqliteDbContext>(opts =>
               opts.UseSqlite("Data Source=Api.db", sqlite =>
                   sqlite.MigrationsAssembly("LoginApiJCBomfim.Infra")));

builder.Services.AddMvcCore((opts) => { opts.EnableEndpointRouting = false; });

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUow, UnityOfWork>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors((e) =>
                e.AddPolicy("Dev", op => op
                .AllowAnyOrigin()
                .AllowAnyMethod()));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseCors("Dev");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
