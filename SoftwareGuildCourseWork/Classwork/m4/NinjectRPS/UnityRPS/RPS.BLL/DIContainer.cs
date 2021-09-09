using Microsoft.Practices.Unity;
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
        // the container is the master factory
        public static UnityContainer Container = new UnityContainer();

        // constructor, to configure the bindings
        static DIContainer()
        {
            string chooserType = ConfigurationManager.AppSettings["Chooser"].ToString();

            // Tell Unity that IChoiceGetter should resolve to RandomChoice
            if (chooserType == "Random")
            {
                Container.RegisterType<IChoiceGetter, RandomChoice>();

                InjectionProperty injectionProperty = 
                    new InjectionProperty("ChoiceBehavior", new RandomChoice());
                Container.RegisterType<GameManager2>(injectionProperty);

                InjectionMethod injectionMethod = 
                    new InjectionMethod("SetChoiceBehavior", new RandomChoice());
                Container.RegisterType<GameManager3>(injectionMethod);
            }
                

            // Tell Unity that IChoiceGetter should resolve to PrefersRockChoice
            else if (chooserType == "PrefersRock")
            {
                Container.RegisterType<IChoiceGetter, PrefersRockChoice>();

                InjectionProperty injectionProperty = 
                    new InjectionProperty("ChoiceBehavior", new PrefersRockChoice());
                Container.RegisterType<GameManager2>(injectionProperty);

                InjectionMethod injectionMethod = 
                    new InjectionMethod("SetChoiceBehavior", new PrefersRockChoice());
                Container.RegisterType<GameManager3>(injectionMethod);

            }
                
            else
                throw new Exception("Chooser key in app.config not set properly!");
        }
    }
}
