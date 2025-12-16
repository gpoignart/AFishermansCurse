using System.Linq;

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

    // List of time of days
    public TimeOfDaySO[] AllTimesOfDay =>
        new TimeOfDaySO[]
        {
            daySO,
            nightSO
        };

    public TimeOfDaySO GetByName(string timeOfDayName)
    {
        return AllTimesOfDay.FirstOrDefault(t => t.timeOfDayName == timeOfDayName);
    }
}
