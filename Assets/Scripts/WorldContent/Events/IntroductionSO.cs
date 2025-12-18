using UnityEngine;

[CreateAssetMenu(menuName = "Event/Introduction")]
public class IntroductionSO : EventSO
{
    public override void Initialize()
    {
        this.eventName = "Introduction";
        this.eventLines = new EventLine[]
        {
            new EventLine(text: "I've been cursed all my life."),
            new EventLine(text: "Evil and misfortune followed me through every city, every crowd, every deafening street."),
            new EventLine(text: "I ran… always running, hoping to escape it."),
            new EventLine(text: "Eventually, I found a place where I might finally find peace."),
            new EventLine(text: "A lake… quiet, isolated, where I can fish and live alone."),
            new EventLine(text: "Fishing is simple, quiet, honest… a rhythm I can follow without fear."),
            new EventLine(text: "Only me, my boat, my fishing rod, and my flashlight."),
            new EventLine(text: "And even if sleep abandoned me long ago… another gift of the curse..."),
            new EventLine(text: "I get by, fishing day and night… waiting… hoping that the tide will ease my burden.")
        };
    }
}
