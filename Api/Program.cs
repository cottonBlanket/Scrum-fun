using Dal;
using Logic.Managers.Exercise;
using Logic.Managers.Exercise.Interfaces;
using Logic.Managers.Mode;
using Logic.Managers.Mode.Interfaces;
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
//режим
builder.Services.AddScoped<IModeRepository, ModeRepository>();
builder.Services.AddScoped<IModeManager, ModeManager>();
//задание
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseManager, ExerciseManager>();

//сваггер
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();