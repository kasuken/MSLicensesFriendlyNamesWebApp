var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ProductsService>(new ProductsService());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/products", async (ProductsService productsService) =>
{
    var products = await productsService.GetProducts();

    return products;
});

app.MapGet("/products/{id}", async (ProductsService productsService, string id) =>
{
    var products = await productsService.GetProducts();
    var product = products.FirstOrDefault(p => p.StringID == id);

    return product;
});

app.UseSwaggerUI();
app.Run();