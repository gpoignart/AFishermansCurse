[System.Serializable]
public class TransitionRegistry
{
    public EndDaySO endDaySO;
    public EndNightSO endNightSO;
    public FirstDeathAgainstMonsterSO firstDeathAgainstMonsterSO;
    public DeathAgainstMonsterSO deathAgainstMonsterSO;
    public EndRecipeBookEventSO endRecipeBookEventSO;

    public void Initialize()
    {
        endDaySO.Initialize();
        endNightSO.Initialize();
        firstDeathAgainstMonsterSO.Initialize();
        deathAgainstMonsterSO.Initialize();
        endRecipeBookEventSO.Initialize();
    }
}
