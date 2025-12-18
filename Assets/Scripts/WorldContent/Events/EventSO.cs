using UnityEngine;

public abstract class EventSO : ScriptableObject
{
    public string eventName;
    public EventLine[] eventLines;

    public abstract void Initialize();
}

[System.Serializable] // Needed for an intern class
public class EventLine
{
    public string text;
    public Sprite backgroundImage;

    // Constructor
    public EventLine(string text)
    {
        this.text = text;
    }
}