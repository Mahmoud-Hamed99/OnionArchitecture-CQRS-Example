using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Products.Domain;
using Products.Infrastructure;
using Products.Service;
using System.Reflection;
using FluentValidation.AspNetCore;
using ProductContext = Products.Infrastructure.ProductContext;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


// inject the mediate r handler from the dll conatins "GetProductByIdQuery" or any class in this dll.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetProductByIdQuery)));


//Register Repos
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();



//Register DB Context
builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});


builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<ProductViewModel>, ProductValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
