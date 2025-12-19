using UnityEngine;

public abstract class MonsterSO : ScriptableObject
{
    public string monsterName;
    public GameObject monsterPrefab;

    public abstract void Initialize();
}
