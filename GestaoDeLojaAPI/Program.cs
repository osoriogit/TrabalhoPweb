using GestaoDeLojaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient; // Acrescentado -> Adicione esta linha para garantir a referência ao provider SQL Server
using Microsoft.EntityFrameworkCore.SqlServer;
using GestaoDeLojaAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens; // Acrescentado -> Adicione esta linha para garantir a referência ao provider SQL Server

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Acrescentado -> Configuração do DbContext com SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Acrecscentado -> Injeção de Dependência do Repositório Categoria
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

//Acrecscentado -> Injeção de Dependência do Repositório Produto
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

//Acrescentado 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

//Acrescentado 
builder.Services.AddAuthorization();

//Acrescentado
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

//Acrescentado : Mapear uma rota para o endpoint identity
app.MapGroup("/identity").MapIdentityApi<ApplicationUser>();

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