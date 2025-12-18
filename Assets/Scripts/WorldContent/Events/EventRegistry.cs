using System.Linq;

[System.Serializable]
public class EventRegistry
{
    public IntroductionSO introductionSO;
    public RecipeBookObtentionSO recipeBookObtentionSO;
    public EndSO endSO;
    
    // List of events
    public EventSO[] AllEvents =>
        new EventSO[]
        {
            introductionSO,
            recipeBookObtentionSO,
            endSO
        };

    public void Initialize()
    {
        introductionSO.Initialize();
        recipeBookObtentionSO.Initialize();
        endSO.Initialize();
    }

    public EventSO GetByName(string eventName)
    {
        return AllEvents.FirstOrDefault(e => e.eventName == eventName);
    }
}
