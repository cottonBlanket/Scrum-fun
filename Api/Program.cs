using Api.Controllers.Public.Room.Mapping;
using Api.Controllers.Public.Start.Mapping;
using Dal;
using Logic.Managers.Room;
using Logic.Managers.Room.Interfaces;
using Logic.Managers.User;
using Logic.Managers.User.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//конроллеры
builder.Services.AddControllers();
// подключение к бд
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//юзер
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();
//комната
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomManager, RoomManager>();
builder.Services.AddAutoMapper(typeof(CreateRoomProfile));
builder.Services.AddAutoMapper(typeof(UserResponseProfile));
//сваггер
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();