using Castle.MicroKernel.Registration;
using HippoBilling.Service.Accounts;
using HippoBilling.Service.Accounts.Impl;
using HippoBilling.Service.Addresses;
using HippoBilling.Service.Addresses.Impl;
using HippoBilling.Service.Insurances;
using HippoBilling.Service.Insurances.Impl;
using HippoBilling.Service.Patients;
using HippoBilling.Service.Patients.Impl;
using HippoBilling.Service.Practices;
using HippoBilling.Service.Practices.Impl;
using HippoBilling.Service.Authorizations;
using HippoBilling.Service.Authorizations.Impl;

namespace HippoBilling.Service
{
    public class Installer : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container,
            Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component.For<IAuthenticationService>().ImplementedBy<AuthenticationService>().LifestylePerWebRequest(),
                Component.For<ISpecialityService>().ImplementedBy<SpecialityService>().LifestylePerWebRequest(),
                Component.For<IStateService>().ImplementedBy<StateService>().LifestylePerWebRequest(),
                Component.For<IPracticeService>().ImplementedBy<PracticeService>().LifestylePerWebRequest(),
                Component.For<IUserService>().ImplementedBy<UserService>().LifestylePerWebRequest(),
                Component.For<IServicePlaceService>().ImplementedBy<ServicePlaceService>().LifestylePerWebRequest(),
                Component.For<INPIService>().ImplementedBy<NPIService>().LifestylePerWebRequest(),
                Component.For<IPatientService>().ImplementedBy<PatientService>().LifestylePerWebRequest(),
                Component.For<IPayerService>().ImplementedBy<PayerService>().LifestylePerWebRequest(),
                Component.For<IInsuranceService>().ImplementedBy<InsuranceService>().LifestylePerWebRequest(),
                Component.For<IAuthorizationService>().ImplementedBy<AuthorizationService>().LifestylePerWebRequest()
                );
        }
    }
}