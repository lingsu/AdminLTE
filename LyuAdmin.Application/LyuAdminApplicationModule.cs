using System.Reflection;
using Abp.AutoMapper;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using AutoMapper;
using LyuAdmin.Users;
using LyuAdmin.Users.Dto;

namespace LyuAdmin
{
    [DependsOn(typeof(LyuAdminCoreModule), typeof(AbpAutoMapperModule))]
    public class LyuAdminApplicationModule : AbpModule
    {

       

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Mapper.CreateMap<User, UserQueryDto>()
            .ForMember(dest => dest.Roles, opt => opt.Ignore());
        }
    }
}
