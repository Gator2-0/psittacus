using Microsoft.ML;
using psittacus.Models;
using psittacus.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // React app's origin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add ML.NET and NLP service
var mlContext = new MLContext();
var model = ModelTrainer.TrainModel(mlContext, "./CSV/queries.csv"); // Adjust path if necessary
var predictionEngine = mlContext.Model.CreatePredictionEngine<UserQuery, QueryPrediction>(model);

builder.Services.AddSingleton(new NlpService(predictionEngine));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowSpecificOrigins"); // Apply CORS policy 

app.UseAuthorization();

app.MapControllers();

app.Run();
