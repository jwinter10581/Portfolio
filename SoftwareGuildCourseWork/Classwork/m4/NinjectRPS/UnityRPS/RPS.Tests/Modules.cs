using Ninject.Modules;
using RPS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Tests
{
    public class AlwaysPaperModule : NinjectModule
    {
        public override void Load()
        {
            // we could bind many interface-implementations in this method
            Bind<IChoiceGetter>().To<AlwaysPaper>();
        }
    }
}
