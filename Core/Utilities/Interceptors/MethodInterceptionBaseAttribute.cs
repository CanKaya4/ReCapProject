using Castle.DynamicProxy;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utilities.Interceptors
{
    //AOP yapısını Autofac paketi sağlayacak.
    //Buradaki kodlar için Autofac gerekli, Autofac'de hali hazırda business clasında kurulu bir paket.
    //Solution üzerinden Manage nuget packges for soliton'a tıklayıp AutoFac,Autofac Dynmaic Proxy ve Autofac DependycInjection'u Core katmanına da ekliyoruz.

    //Bu Attribute'u classlara veya metotlara ekleyebilirsin, Birden fazla ekleyebilirsin ve Inherit edilen bir noktada bu attribute çalışsın demek
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //Priority : Öncelik demek, Hangi Attribute'ün önce çalışacağını sıralamak için.
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}


