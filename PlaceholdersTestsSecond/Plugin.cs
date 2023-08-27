using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholdersTestsSecond
{
    //This is second plugin for tests.
    public class Plugin : Plugin<Config>
    {
        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Jumping += Events.OnPlayerJump;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Jumping -= Events.OnPlayerJump;

            base.OnDisabled();
        }
    }
}
