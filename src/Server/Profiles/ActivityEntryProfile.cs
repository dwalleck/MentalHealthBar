using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentalHealthBar.Shared.Models;
using MentalHealthBar.Server.Entities;

namespace MentalHealthBar.Server.Profiles
{
    public class ActivityEntryProfile : Profile
    {
        public ActivityEntryProfile()
        {
            CreateMap<ActivityEntry, ActivityEntryDto>();
            CreateMap<ActivityEntryForCreationDto, ActivityEntry>();
            CreateMap<ActivityEntryForUpdateDto, ActivityEntry>();
        }
    }
}
