using Autofac.Extensions.DependencyInjection;
using Autofac;
using SeasonPass.Module.Postgres;
using SeasonPass.Module.Postgres.Data;
using SeasonPass.Module.SkiResorts;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        container.RegisterAssemblyModules(typeof(Program).Assembly);
        container.RegisterAssemblyModules(typeof(SkiResortsModule).Assembly);
        container.RegisterAssemblyModules(typeof(PostgresModule).Assembly);
    });
builder.Services.AddFastEndpoints(o => o.Assemblies =
    [
        typeof(SkiResortsModule).Assembly,
    ]);
builder.Services.SwaggerDocument(
       o =>
       {
           o.DocumentSettings = s =>
           {
               s.Title = "Season Pass API";
               s.Version = "v0";
           };
       });

builder.Services.AddDbContext<SeasonPassDbContext>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
});

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.Run();
