﻿

using AutoMapper;
using DataBase.Entities;
using HendInRentApi;
using Web.Dtos;
using Web.HasingToken;
using Web.Models;

namespace Web.Helprers
{
    public static class AutoMapperConfig
    {

        public static IServiceCollection ConfigAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(ConfigeMapper);

            return services;
        }

        static void ConfigeMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserRegistrationModel, InputUserRegistrationDto>(); //model is validated, registration dto isn't.
            //It's just to pass UserService Reg method


            cfg.CreateMap<InputUserRegistrationDto, InputLoginUserRentInHendDto>();  //why is reg becoming login?
            //when users registrate here they login in RentInHend.

            cfg.CreateMap<OutputAuthTokenDto, Token>().ForMember(t => t.AccessTokenHash, cfg => cfg.Ignore());
            //token from api to db token

            cfg.CreateMap<InputUserRegistrationDto, User>().ForMember(t => t.Password, cfg => cfg.Ignore());
            //from dto model in UserService to user entity

            //cfg.CreateMap<User>

            cfg.CreateMap<UserLoginModel, InputLoginUserDto>();


            cfg.CreateMap<Token, OutputTokenDto>();

            cfg.CreateMap<User, OutputUserDto>();
        }

        

        
    }
}
