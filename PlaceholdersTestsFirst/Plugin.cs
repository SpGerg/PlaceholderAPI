using Exiled.API.Features;
using PlaceholdersAPI.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholdersTestsFirst
{
    //This is first plugin for tests.
    public class Plugin : Plugin<Config>
    {
        public override void OnEnabled()
        {
            PLAPI.Register(new CoolPlaceholder()); //Register placeholder
            PLAPI.Register(new JustGoodPlaceholder());
            PLAPI.Register(new ColorPlaceholder());

            base.OnEnabled();
        }
    }
}
