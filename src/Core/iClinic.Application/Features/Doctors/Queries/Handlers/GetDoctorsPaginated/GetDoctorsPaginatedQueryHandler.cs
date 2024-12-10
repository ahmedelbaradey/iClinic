using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Doctors.Queries.Response;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using iClinic.Application.Features.Doctors.Queries.Handlers.GetDoctorsPaginated;
using iClinic.Application.Abstracts.Logger;

namespace iClinic.Application.Features.Doctors.Queries.Handlers
{
    public class GetDoctorsPaginatedQueryHandler : BaseResponseHandler, IQueryHandler<GetDoctorsPaginatedQuery, PaginatedResult<GetDoctorsPaginatedResponse>>
    {
        #region Fileds
        private readonly IDoctorService _doctorService;
        private readonly ILoggerManager _logger;

        #endregion

        #region Constructor(s)
        public GetDoctorsPaginatedQueryHandler(IDoctorService doctorService,  ILoggerManager logger)
        {
            _logger = logger;
            _doctorService = doctorService;
        }
        #endregion

        #region Functions
        public async Task<PaginatedResult<GetDoctorsPaginatedResponse>> Handle(GetDoctorsPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Doctor, GetDoctorsPaginatedResponse>> expression =
                entity => new GetDoctorsPaginatedResponse(entity.DoctorId,
                                entity.FirstName, entity.LastName, entity.Email, entity.Phone, entity.IsActive);

                var filterResult = _doctorService.FilterDoctorPaginatedQuerable(request.Search);
                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber,
                    request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetDoctorsPaginatedQuery");
                throw;
            }
        }
        #endregion
    }
}
