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
        public static void OnPlayerHurting(HurtingEventArgs ev)
        {
            ev.Player.Broadcast(2, PLAPI.SetPlaceholders(ev.Player, "Im need {color_red} placeholder! and {color_weotghjwet}. And i can using other placeholders {cool_placeholder}!"));
        }
    }
}
