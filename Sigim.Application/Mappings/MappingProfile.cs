using AutoMapper;
using Sigim.Application.Features.AuthFeature.commands.RegisterUser;
using Sigim.Application.Models;
using Sigim.Domain;
using Sigim.Application.Features.ExerciseFeature.Commands.CreateExercise;
using Sigim.Application.Features.ExerciseFeature.Commands.UpdateExercise;
using Sigim.Application.Features.RoutineFeature.Commands.CreateRoutine;
using Sigim.Application.Features.RoutineFeature.Commands.UpdateRoutine;
using Sigim.Application.Models.Request;
using Sigim.Application.Features.RoutineExerciseFeature.Commands.UpdateRoutineExercise;
using Sigim.Application.Features.IncomeFeature.Commands.CreateIncome;
using Sigim.Application.Features.UserRoutineFeature.Commands.CreateUserRoutine;
using Sigim.Application.Features.UserRoutineFeature.Commands.CreateUsersRoutines;
using Sigim.Application.Models.Identity;

namespace Sigim.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Auth
            CreateMap<User, AuthResponse>();

            CreateMap<RegisterUserCommand, User>()
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToUniversalTime()));

            CreateMap<History, HistoryResult>()
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha.ToUniversalTime()));
            
            CreateMap<CreateExerciseCommand, Exercise>();
            CreateMap<UpdateExerciseCommand, Exercise>();
            CreateMap<Exercise, ExerciseResult>();
            CreateMap<CreateRoutineCommand, Routine>();
            CreateMap<UpdateRoutineCommand, Routine>();
            CreateMap<Routine, RoutineResult>();
            CreateMap<RoutineExerciseRequest, RoutineExercise>();
            CreateMap<RoutineExercise, RoutineExerciseResult>();
            CreateMap<UpdateRoutineExerciseCommand, RoutineExercise>();
            CreateMap<CreateIncomeCommand, Income>();
            CreateMap<User, UserResult>();
            CreateMap<Rol, RolResult>();
            CreateMap<Income, IncomeResult>();

            //UserRoutine
            CreateMap<CreateUserRoutineCommand, UserRoutine>();
            CreateMap<UserRoutineRequest, UserRoutine>();
            CreateMap<UserRoutine, UserRoutineResult> ();
        }
    }
}
