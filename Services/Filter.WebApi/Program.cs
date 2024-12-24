using Elastic.Clients.Elasticsearch;
using Filter.WebApi.Services;
using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var uri = configuration["Elasticsearch:Uri"];
    var defaultIndex = configuration["Elasticsearch:Index"];

    var settings = new ElasticsearchClientSettings(new Uri(uri))
        .DefaultIndex(defaultIndex);

    return new ElasticsearchClient(settings);
});



builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddMassTransit(options =>
{
    options.AddConsumer<ProductCreatedConsumer>();

    options.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(false));

    options.UsingRabbitMq((context, config) =>
    {
        config.Host(builder.Configuration["RabbitMQ"], "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        config.ReceiveEndpoint("filter-product", endpoint =>
        {
            endpoint.ConfigureConsumer<ProductCreatedConsumer>(context);
        });
    });


});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

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
