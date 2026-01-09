using System.Linq;

[System.Serializable]
public class MonsterRegistry
{
    public TheEyesSO theEyesSO;
    public TheOffendedSO theOffendedSO;
    public TheJesterSO theJesterSO;

    // List of monsters
    public MonsterSO[] AllMonsters =>
        new MonsterSO[]
        {
            theEyesSO,
            theOffendedSO,
            theJesterSO
        };

    public void Initialize()
    {
        theEyesSO.Initialize();
        theOffendedSO.Initialize();
        theJesterSO.Initialize();
    }

    public MonsterSO GetByName(string monsterName)
    {
        return AllMonsters.FirstOrDefault(m => m.monsterName == monsterName);
    }
}

