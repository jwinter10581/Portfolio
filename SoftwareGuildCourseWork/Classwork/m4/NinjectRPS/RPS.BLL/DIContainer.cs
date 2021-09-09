using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.BLL
{
    // static, because we only need one container
    public static class DIContainer
    {
        // the kernel is the master factory
        public static IKernel Kernel = new StandardKernel();

        // constructor, to configure the bindings
        static DIContainer()
        {
            string chooserType = ConfigurationManager.AppSettings["Chooser"].ToString();

            // Tell ninject that IChoiceGetter should resolve to RandomChoice
            if (chooserType == "Random")
                Kernel.Bind<IChoiceGetter>().To<RandomChoice>();
            // Tell ninject that IChoiceGetter should resolve to PrefersRockChoice
            else if (chooserType == "PrefersRock")
                Kernel.Bind<IChoiceGetter>().To<PrefersRockChoice>();
            else
                throw new Exception("Chooser key in app.config not set properly!");
        }
    }
}
