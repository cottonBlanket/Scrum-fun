using System.Data.SqlTypes;
using Dal.Room;
using Logic.Managers.Base;
using Logic.Managers.Room.Interfaces;

namespace Logic.Managers.Room;

public class RoomManager: BaseManager<RoomDal, int>, IRoomManager
{
    public RoomManager(IRoomRepository repository) : base(repository)
    {
    }

     /*public int GeneratePassword()
     {
         var rnd = new Random();
         while (true)
         {
             var password = rnd.Next(1000, 9999);
             if (Repository.GetAll().Where(x => x.Password == password).ToList().Count == 0)
                 return password;
         }
    }*/
}