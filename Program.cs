var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var dictionary = new Dictionary<string, string>
{
    { "ev", "home" },
    { "araba", "car" },
    { "kitap", "book" },
    { "bilgisayar", "computer" },
    { "resim", "picture" },
    { "makale", "article" },
    { "software", "yazýlým" },
    { "doküman", "documant" },
    { "veritabaný", "database" },
    { "ekran", "screen" },
    { "kalem", "pencil" },
    { "silgi", "eraser" }
};

app.MapGet("/translate/{word}", (string word) =>
{
    if (dictionary.ContainsKey(word))
    {
        return Results.Ok(word + " kelimesinin Ýngilizce dilindeki karþýlýðý: " + dictionary[word]);
    }
    else
    {
        return Results.NotFound("Kelime bulunamadý.");
    }
});

app.Run();

