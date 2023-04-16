using Api.Controllers.Public.Pictures.mapping;
using Api.Controllers.Public.Room.Mapping;
using Api.Controllers.Public.Start.Mapping;
using Dal;
using Dal.Group.Repository;
using Dal.Group.Repository.Interface;
using Dal.Photo.Repository;
using Dal.Photo.Repository.Interface;
using Logic.Managers.Group;
using Logic.Managers.Group.Interface;
using Logic.Managers.Photo;
using Logic.Managers.Photo.Interface;
using Logic.Managers.Room;
using Logic.Managers.Room.Interfaces;
using Logic.Managers.User;
using Logic.Managers.User.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//конроллеры
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);;
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
//группа
builder.Services.AddScoped<IGroupManager, GroupManager>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
//фото
builder.Services.AddScoped<IPhotoManager, PhotoManager>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();

builder.Services.AddAutoMapper(typeof(SendPhotoProfile));
builder.Services.AddAutoMapper(typeof(CreateRoomProfile));
builder.Services.AddAutoMapper(typeof(UserResponseProfile));
//сваггер
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


var app = builder.Build();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();