using Exiled.Events.EventArgs.Player;
using MEC;
using PlaceholdersAPI;

namespace PlaceholdersTestsSecond
{
    public class Events 
    {
        public static void OnPlayerJump(JumpingEventArgs ev)
        {
            ev.Player.Broadcast(2, PLAPI.SetPlaceholders(ev.Player, "Placeholder: {cool_placeholder}")); //Using placeholder example! You can using placeholder from other plugins! Cool!

            Timing.CallDelayed(3f, () =>
            {
                ev.Player.Broadcast(2, PLAPI.SetPlaceholders(ev.Player, "Placeholder: {just-good_placeholder2}"));
            });
        }
    }
}
