using UnityEngine;

[CreateAssetMenu(menuName = "Event/RecipeBookObtention")]
public class RecipeBookObtentionSO : EventSO
{
    public override void Initialize()
    {
        this.eventName = "RecipeBookObtention";
        this.eventLines = new EventLine[]
        {
            new EventLine(text: "I knew it was too good to be true."),
            new EventLine(text: "The curse followed me here… in the form of that monster in the water."),
            new EventLine(text: "And… I survived."),
            new EventLine(text: "I knew it. I knew I would never be free."),
            new EventLine(text: "Even here, it hunts me. Always trying to take my life… never quite succeeding. Just enough to keep me suffering."),
            new EventLine(text: "Suddenly, I noticed something."),
            new EventLine(text: "There, on the boat… the monster had dropped something. A book."),
            new EventLine(text: "I open it… and see recipes carefully written inside."),
            new EventLine(text: "Recipes that felt as if they had been written for me."),
            new EventLine(text: "Most of them are meant to improve my equipment... but this last one…"),
            new EventLine(text: "Could this place… really help me?"),
            new EventLine(text: "I have nothing left to lose… I have to try.")
        };
    }
}
