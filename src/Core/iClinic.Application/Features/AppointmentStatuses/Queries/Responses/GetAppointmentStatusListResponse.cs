namespace iClinic.Application.Features.AppointmentStatuses.Queries.Responses
{
    public record GetAppointmentStatusListResponse
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
    }
}
