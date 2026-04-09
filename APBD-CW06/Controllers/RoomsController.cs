using APBD_CW06.Data;
using APBD_CW06.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW06.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomsController : ControllerBase
{
    private static List<Room> _rooms;
    [HttpGet]
    public IActionResult GetRooms()
    {
        return Ok(_rooms);
    }
    [HttpGet("/{id}")]
    public IActionResult GetRoom(int idRoom)
    {
        var room = DataBase.Rooms.FirstOrDefault(r => r.Id == idRoom);
        return Ok(room);
    }

    [HttpGet("/building/{buildingCode}")]
    public IActionResult GetRoomBuilding(int idRoom, string buildingCode)
    {
        var room = DataBase.Rooms
            .Where(x => x.BuildingCode == buildingCode)
            .ToList();
        return Ok(room);
    }

    [HttpGet]
    public IActionResult GetAll(int id,int minCapacity,bool? hasProjector, bool? activeOnly)
    {
        var rooms = DataBase.Rooms
            .Where(x => x.Capacity >= minCapacity && x.HasProjector == hasProjector && x.IsActive == activeOnly);
        return Ok(rooms);
    }

    [HttpPost]
    public IActionResult AddRoom([FromBody] Room room)
    {
        DataBase.Rooms.Add(room);
        return Ok();
    }

    [HttpPut("/{id}")]
    public IActionResult UpdateRoom(int id, [FromBody] Room room)
    {
        var exists = DataBase.Rooms.FirstOrDefault(r => r.Id == id);
        if(exists == null) return NotFound("Room doesn't exist");
        exists.Name = room.Name;
        exists.BuildingCode = room.BuildingCode;
        exists.Floor = room.Floor;
        exists.Capacity = room.Capacity;
        exists.HasProjector = room.HasProjector;
        exists.IsActive = room.IsActive;
        return Ok();
    }

    [HttpDelete("/{id}")]
    public IActionResult DeleteRoom(int id)
    {
        var room = DataBase.Rooms.FirstOrDefault(r => r.Id == id);
        if (room == null) return NotFound("Room doesn't exist");
        DataBase.Rooms.Remove(room);
        return Ok();
    }
}