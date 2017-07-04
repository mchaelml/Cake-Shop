using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using M32COM.dto;
using M32COM.Models;

namespace M32COM.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id,opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MovieGenre, MovieGenreDto>();

            Mapper.CreateMap<Rental, NewRentalDto>();

            Mapper.CreateMap<CakeDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, CakeDto>();

        }
    }
}