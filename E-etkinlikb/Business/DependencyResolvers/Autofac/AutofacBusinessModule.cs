using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Abstract;
using DataAccess.Concrete.EntityFramework.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ActivityTypeManager>().As<IActivityTypeService>().SingleInstance();
            builder.RegisterType<EfActivityTypeDal>().As<IActivityTypeDal>().SingleInstance();
            builder.RegisterType<IsFreeManager>().As<IPriceType>().SingleInstance();
            builder.RegisterType<EfPriceTypeDal>().As<IIsFreeDal>().SingleInstance();
            builder.RegisterType<ActivityManager>().As<IActivityService>().SingleInstance();
            builder.RegisterType<EfActivityDal>().As<IActivityDal>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<JoinManager>().As<IJoinService>().SingleInstance();
            builder.RegisterType<EfJoinDal>().As<IJoinDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<ActivityImageManager>().As<IActivityImageService>().SingleInstance();
            builder.RegisterType<EfUserImageDal>().As<IActivityImageDal>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<EfUserOperationClaim>().As<IUserOperationClaimDal>().SingleInstance();
            builder.RegisterType<UserOperationClaimService>().As<IUserOperationService>().SingleInstance(); ;

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
