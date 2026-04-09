namespace APBD_CW06.Models;

public enum ReservationStatus
{
    Planned,
    Confirmed,
    Cancelled
}

public class Reservation
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string OrganizerName { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Planned;

    public Room Room { get; set; } = null!;
}
