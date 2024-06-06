using BookBeacon.BL.DTOs.ReservationDTOs;
using BookBeacon.BL.ResourceParameters;
using BookBeacon.Models.Models;

namespace BookBeacon.BL.Helpers.Mappers;

public static class ReservationMapper
{
    private static ReservationDto ToListDto(this Reservation reservation)
    {
        return new ReservationDto
        {
            Id = reservation.Id,
            StartDate = reservation.StartDate,
            EndDate = reservation.EndDate,
            IsReturned = reservation.IsReturned,
            IsDue = reservation.EndDate < DateTime.Now,
            Notes = reservation.Notes,
            CopyId = reservation.CopyId,
        };
    }

    public static PagedList<ReservationDto> ToListDto(this PagedList<Reservation> reservations)
    {
        var count = reservations.TotalCount;
        var pageNumber = reservations.CurrentPage;
        var pageSize = reservations.PageSize;
        var totalPages = reservations.TotalPages;
        return new PagedList<ReservationDto>(
            reservations.Select(s => s.ToListDto()).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
    
    public static ReservationDto ToDto(this Reservation reservation)
    {
        int daysLeft = (int)(reservation.EndDate - DateTime.Now).TotalDays;
        return new ReservationDto
        {
            Id = reservation.Id,
            StartDate = reservation.StartDate,
            EndDate = reservation.EndDate,
            Notes = reservation.Notes,
            CopyId = reservation.CopyId,
            DaysLeft = daysLeft > 0 ? daysLeft : 0,
            IsDue = reservation.EndDate < DateTime.Now,
            IsReturned = reservation.IsReturned
        };
    }
    
    public static Reservation ToCreateEntity(this ReservationDto reservationDto, string userId)
    {
        return new Reservation
        {
            UserId = userId,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(14),
            // CopyId = reservationDto.CopyId,
            Notes = reservationDto.Notes
        };
    }
    
    public static Reservation ToEntity(this CreateReservationDto reservationDto)
    {
        return new Reservation
        {
            UserId = reservationDto.UserId,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(reservationDto.Duration),
            Notes = reservationDto.Notes,
            IsReturned = false,
        };
    }

}
