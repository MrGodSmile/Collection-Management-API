using CollectionManagementAPI.DataAccess;
using CollectionManagementAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBusiness();
builder.Services.AddDatabase(builder.Configuration);

/*builder.Services.AddDbContext<CollectionManagementDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("CollectionsDB")));*/

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();