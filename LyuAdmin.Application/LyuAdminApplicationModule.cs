using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace LyuAdmin
{
    [DependsOn(typeof(LyuAdminCoreModule), typeof(AbpAutoMapperModule))]
    public class LyuAdminApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
