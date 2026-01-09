using UnityEngine;

public abstract class MonsterSO : ScriptableObject
{
    public GameObject monsterPrefab;
    public string monsterName;
    public float loseTime;
    public bool isApparitionReversed; // Appear at the opposite of the warning
    public bool isWarningFake; // Show a warning slightly different from the usual
    public bool hasBeenEncountered;

    public abstract void Initialize();
    
    public void HasBeenEncountered()
    {
        hasBeenEncountered = true;
    }
}
