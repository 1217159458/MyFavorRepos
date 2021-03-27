using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFavorRepos.Common
{
    public class ServiceInterceptor: IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            string msg = $"你正在调用方法是{invocation.TargetType.FullName}中的{invocation.Method.Name}  参数是 {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())}";
            Log4NetUtil.LogInfo(msg);
            invocation.Proceed();
            msg = $"方法执行完毕，返回结果：{invocation.ReturnValue}";
            Log4NetUtil.LogInfo(msg);
        }
    }
}
