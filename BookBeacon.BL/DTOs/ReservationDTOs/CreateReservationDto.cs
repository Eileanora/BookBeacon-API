namespace BookBeacon.BL.DTOs.ReservationDTOs;

public class CreateReservationDto
{
    public string UserId { get; set; } = string.Empty;
    public int BookId { get; set; }
    public int Duration { get; set; }
    public string? Notes { get; set; }
}
