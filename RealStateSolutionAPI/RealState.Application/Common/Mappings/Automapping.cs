using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using RealState.Application.Common.Models;
using RealState.Domain.Entities;

namespace RealState.Application.Common.Mappings
{
    public class Automapping :Profile
    {
        public Automapping()
        {
            //CreateMap<Answer, AnswerDto>()
            //    .ForMember(dest => dest.IdForm, opt => opt.MapFrom(src => src.FormIdForm));
            
        }
    }
}
