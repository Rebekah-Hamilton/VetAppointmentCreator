using DogDescriptionApi.Models;
using DogDescriptionApi.Processors;
using System.Text.Json.Serialization;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});
//HttpConfiguration
//     .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
//     .EnableSwaggerUi(c =>
//     {
//         c.CustomAsset("index", yourAssembly, "YourWebApiProject.SwaggerExtensions.index.html");
//     });
builder.Services.AddTransient<DogBreeds>();
builder.Services.AddTransient<ProcessModel>();
builder.Services.AddTransient<AppointmentRequest>();
builder.Services.AddTransient<RequestHelper>();
builder.Services.AddTransient<VisitReasons>();

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
