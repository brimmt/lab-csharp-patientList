using patientAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});



// Add services
builder.Services.AddControllers();
builder.Services.AddScoped<PatientsService>();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "PatientAPI", Version = "v1"});
});

var app = builder.Build();
app.UseCors("AllowAll");

// Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientAPI v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();