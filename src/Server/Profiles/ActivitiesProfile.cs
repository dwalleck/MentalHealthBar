using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentalHealthBar.Shared.Models;
using MentalHealthBar.Server.Entities;

namespace MentalHealthBar.Server.Profiles
{
    public class ActivitiesProfile : Profile
    {
        public ActivitiesProfile()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<ActivityForCreationDto, Activity>();
            CreateMap<ActivityForUpdateDto, Activity>();
        }
    }
}
