using APBD_CW06.Data;
using APBD_CW06.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW06.Controllers;
[ApiController]
[Route("api/reservation")]
public class ReservationController : ControllerBase
{
    private static List<Reservation> reservations = new List<Reservation>();

    [HttpGet]
    public IActionResult getReservations()
    {
        return Ok(reservations);
    }

    [HttpGet("{id}")]
    public IActionResult getReservationsByRoom(int id)
    {
        return Ok(reservations.Where(r => r.RoomId == id));
    }
    
    [HttpGet]
    public IActionResult GetAll([FromQuery]DateTime date,[FromQuery] ReservationStatus? status, [FromQuery]int? roomId)
    {
        var reservation = DataBase.Reservations
            .Where(x => x.Date >= date && x.Status == status && x.Id == roomId);
        return Ok(reservation);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRoom(int id, [FromBody] Reservation reservation)
    {
        var exists = DataBase.Reservations.FirstOrDefault(r => r.Id == id);
        if(exists == null) return NotFound("Reservation not found");
        exists.RoomId = reservation.RoomId;
        exists.OrganizerName = reservation.OrganizerName;
        exists.Topic = reservation.Topic;
        exists.Date = reservation.Date;
        exists.StartTime = reservation.StartTime;
        exists.EndTime = reservation.EndTime;
        exists.Status = reservation.Status;
        exists.Room = reservation.Room;
        return Ok(exists);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReservation(int id)
    {
        var exists = DataBase.Reservations.FirstOrDefault(r => r.Id == id);
        if (exists == null) return NotFound("Reservation not found");
        DataBase.Reservations.Remove(exists);
        return Ok();
    }

}