using UnityEngine;

public abstract class MapSO : ScriptableObject
{
    public string mapName;

    public abstract void Initialize();
}

