﻿using AutoMapper;

namespace iClinic.Application.Mapping.StatusHistories
{
    public partial class StatusHistoryProfile : Profile
    {
        public StatusHistoryProfile()
        {
            AddStatusHistoryMapping();
            EditStatusHistoryMapping();
            GetStatusHistoryListMapping();
            GetStatusHistoryByIdMapping();
        }
    }
}
