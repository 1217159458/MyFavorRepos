using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavorRepos.Common
{
    public class MyFavorReposAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = ReflectionHelper.GetAllAssembliesCoreWeb();
            // 要先注册拦截器
            builder.RegisterType<ServiceInterceptor>();

            //注册仓储
            builder.RegisterAssemblyTypes(assemblies)
                .Where(cc => cc.Name.EndsWith("Repository") || cc.Name.EndsWith("Service"))
                .PublicOnly()//只要public访问权限的
                .Where(cc => cc.IsClass)//只要class型（主要为了排除值和interface类型）
                .AsImplementedInterfaces()//自动以其实现的所有接口类型暴露（包括IDisposable接口）
                .EnableInterfaceInterceptors();//允许使用拦截器
        }
    }
}
