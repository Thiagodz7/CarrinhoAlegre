using CarrinhoAlegre.Core.Interfaces;
using CarrinhoAlegre.Core.Interfaces.Produtos;
using CarrinhoAlegre.Core.Models.Produtos;
using CarrinhoAlegre.Infra.Data;
using CarrinhoAlegre.Infra.ProdutoServices;
using CarrinhoAlegre.Infra.Repository;
using CarrinhoAlegre.Infra.Repository.Produtos;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaPoliticaDeCors", policy =>
    {
        policy.WithOrigins("http://localhost:4206", "http://localhost:4200") // Quem pode chamar?
              .AllowAnyHeader() // Quais headers? (Content-Type, Authorization...)
              .AllowAnyMethod(); // Quais verbos? (GET, POST, PUT...)
    });

    // Política 1: Aberta (Ex: Para o catálogo de produtos que qualquer site pode ler)
    options.AddPolicy("PoliticaPublica", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });

    // Política 2: Restrita (Ex: Para finalizar compra, só seu front-end pode chamar)
    options.AddPolicy("PoliticaRestrita", policy =>
    {
        policy.WithOrigins("https://meufrontend.com") // Só aceita desse site
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors("MinhaPoliticaDeCors"); //usa para todos os controllers -> podemos usar o [DisableCors] no controller para 
//desabilitar essa politica apenas para o controller com a tag

//app.UseCors();//usa a política definida no controller -> No controller -> [EnableCors("PoliticaPublica")], [EnableCors("PoliticaRestrita")],
//[EnableCors("MinhaPoliticaDeCors")]

app.UseAuthorization();

app.MapControllers();

app.Run();
