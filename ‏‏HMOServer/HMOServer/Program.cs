using HMO.Core.Repositories;
using HMO.Core.Services;
using HMO.Data.Repositories;
using HMO.Service;
using HMOServer;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt => opt.AddPolicy("myPolicy", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddSingleton<DataContext>();

builder.Services.AddScoped<IVaccinationRepository, VaccinationRepository>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
//builder.Services.AddScoped<IIllnessRepository, IllnessRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddScoped<IVaccinationService, VaccinationService>();
builder.Services.AddScoped<IProducerService, ProducerService>();
//builder.Services.AddScoped<IIllnessService, IllnessService>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("myPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
