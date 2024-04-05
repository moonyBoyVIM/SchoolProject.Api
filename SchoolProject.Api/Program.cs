using SchoolProject.Api;
using SchoolProject.Api.Data;
using SchoolProject.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SchoolProject");
builder.Services.AddSqlite<SchoolProjectContext>(connectionString);

var app = builder.Build();

app.MapCategoriesStudentsEndpoints();
app.MapCategoriesTeachersEndpoints();
app.MapTeachersEndpoints();
app.MapStudentsEndpoints();

await app.MigrateDbAsync();

app.Run();