using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirTicket.BL;
using AirTicket.DL;

namespace AirTicket.Container
{
    public class BusinessLogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFileReadService>().ImplementedBy<FileReadService>()); 
            container.Register(Component.For<IFileTransformService>().ImplementedBy<FileTransformService>()); 
            container.Register(Component.For<IFileWriteService>().ImplementedBy<FileWriteService>());
            container.Register(Component.For<IFileWriteRepository>().ImplementedBy<FileWriteRepository>());
            container.Register(Component.For<IFileReadRepository>().ImplementedBy<FileReadRepository>());
        }
    }
}