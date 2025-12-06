[System.Serializable]
public class TimeOfDayRegistry
{
    public DaySO daySO;
    public NightSO nightSO;

    public void Initialize()
    {
        daySO.Initialize();
        nightSO.Initialize();
    }
}
