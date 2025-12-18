using UnityEngine;

[CreateAssetMenu(menuName = "Event/End")]
public class EndSO : EventSO
{
    public override void Initialize()
    {
        this.eventName = "End";
        this.eventLines = new EventLine[]
        {
            new EventLine(text: "Days have passed… I have fished, fought, and survived."),
            new EventLine(text: "Each ingredient collected felt like a small victory… a step closer to freedom."),
            new EventLine(text: "At last… all the rare items are here."),
            new EventLine(text: "I prepare the potion with care, following the instructions in the recipe book."),
            new EventLine(text: "The air feels heavy… yet hope is stronger now."),
            new EventLine(text: "I drink the remedy. A warmth spreads through me, as if a great weight has been lifted."),
            new EventLine(text: "The curse… it’s gone."),
            new EventLine(text: "Nothing seems different. I look the same as before… and yet, I can feel it."),
            new EventLine(text: "After so long, I feel… normal. Free."),
            new EventLine(text: "No more monsters. No more noises. No more persecution."),
            new EventLine(text: "I look around at the lake, the water calm and still, the sun slowly rising…"),
            new EventLine(text: "I could go back to the city, back among people. I could reclaim the life I had before the curse."),
            new EventLine(text: "But I don’t want to."),
            new EventLine(text: "This is where I belong… where peace finally finds me."),
            new EventLine(text: "On my gently rocking boat, I lie down."),
            new EventLine(text: "Freed from everything, I fall asleep."),
            new EventLine(text: "It's the first time in ages.")
        };
    }
}
