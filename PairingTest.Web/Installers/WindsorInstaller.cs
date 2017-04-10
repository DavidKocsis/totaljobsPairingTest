using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using PairingTest.Web.Configs;
using PairingTest.Web.Proxies;

namespace PairingTest.Web.Installers
{
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());
            container.Register(Component.For<IQuestionnaireApiProxy>()
                .ImplementedBy<QuestionnaireApiProxy>());
            container.Register(Component.For<IQuestionnaireApiConfig>()
                .Instance(new QuestionnaireApiConfig
                {
                    BaseUrl = ConfigurationManager.AppSettings["QuestionnaireServiceUri"],
                    Endpoint = ConfigurationManager.AppSettings["QuestionnaireServiceEndpoint"]
                }));
            container.Register(Component.For<IHttpClientFactory>().ImplementedBy<HttpClientFactory>());
        }
    }
}