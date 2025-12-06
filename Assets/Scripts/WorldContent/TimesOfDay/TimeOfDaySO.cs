using UnityEngine;

public abstract class TimeOfDaySO : ScriptableObject
{
    public string timeOfDayName;
    public float duration;
    public abstract void Initialize();
}
