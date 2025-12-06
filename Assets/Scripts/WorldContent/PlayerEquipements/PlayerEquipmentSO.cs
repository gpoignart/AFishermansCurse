using UnityEngine;

public abstract class PlayerEquipmentSO : ScriptableObject
{
    public string equipmentName;
    public int level;
    public abstract void Initialize();
}
