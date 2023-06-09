﻿using Dal.Base.Interface;
using Dal.Photo;
using Dal.Room;

namespace Logic.Managers.Room.Interfaces;

public interface IRoomManager: IBaseRepository<RoomDal, string>
{
    public Task SplitUsers(RoomDal room);

    public void SplitUserWords(RoomDal room);
}