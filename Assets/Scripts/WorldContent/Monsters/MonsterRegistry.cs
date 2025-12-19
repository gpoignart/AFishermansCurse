[System.Serializable]
public class MonsterRegistry
{
    public TheEyesSO theEyesSO;

    public void Initialize()
    {
        theEyesSO.Initialize();
    }

    // List of monsters
    public MonsterSO[] AllMonsters =>
        new MonsterSO[]
        {
            theEyesSO
        };
}

