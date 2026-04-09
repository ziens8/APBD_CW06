using APBD_CW06.Models;
namespace APBD_CW06.Data;

public class DataBase
{
    public static List<Room> Rooms { get; } = new List<Room>
        {
            new Room { Id = 1, Name = "Alfa", BuildingCode = "A", Floor = 1, Capacity = 20, HasProjector = true, IsActive = true },
            new Room { Id = 2, Name = "Beta", BuildingCode = "A", Floor = 2, Capacity = 10, HasProjector = false, IsActive = true },
            new Room { Id = 3, Name = "Gamma", BuildingCode = "B", Floor = 0, Capacity = 50, HasProjector = true, IsActive = true },
            new Room { Id = 4, Name = "Delta", BuildingCode = "B", Floor = 1, Capacity = 15, HasProjector = true, IsActive = false },
            new Room { Id = 5, Name = "Epsilon", BuildingCode = "C", Floor = 3, Capacity = 8, HasProjector = false, IsActive = true }
        };
 
        public static List<Reservation> Reservations { get; } = new List<Reservation>
        {
            new Reservation { Id = 1, RoomId = 1, OrganizerName = "Jan Kowalski", Topic = "Szkolenie C#", Date = new DateTime(2026, 5, 10), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(11, 0, 0), Status = ReservationStatus.Confirmed },
            new Reservation { Id = 2, RoomId = 1, OrganizerName = "Anna Nowak", Topic = "Warsztaty Agile", Date = new DateTime(2026, 5, 10), StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(15, 0, 0), Status = ReservationStatus.Planned },
            new Reservation { Id = 3, RoomId = 3, OrganizerName = "Piotr Wiśniewski", Topic = "Konferencja IT", Date = new DateTime(2026, 5, 12), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(16, 0, 0), Status = ReservationStatus.Confirmed },
            new Reservation { Id = 4, RoomId = 2, OrganizerName = "Maria Zielińska", Topic = "Konsultacje projektowe", Date = new DateTime(2026, 5, 11), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(9, 30, 0), Status = ReservationStatus.Planned },
            new Reservation { Id = 5, RoomId = 5, OrganizerName = "Jan Kowalski", Topic = "Retrospektywa", Date = new DateTime(2026, 5, 13), StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(15, 0, 0), Status = ReservationStatus.Cancelled },
            new Reservation { Id = 6, RoomId = 4, OrganizerName = "Ewa Kaczmarek", Topic = "Prezentacja kwartalna", Date = new DateTime(2026, 5, 14), StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(12, 30, 0), Status = ReservationStatus.Confirmed }
        };
 
        private static int _nextRoomId = 6;
        private static int _nextReservationId = 7;
 
        public static int NextRoomId() => _nextRoomId++;
        public static int NextReservationId() => _nextReservationId++;
    }