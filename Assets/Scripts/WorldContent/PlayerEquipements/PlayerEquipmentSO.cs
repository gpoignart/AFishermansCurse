using UnityEngine;

public abstract class PlayerEquipmentSO : ScriptableObject
{
    public string playerEquipmentName;
    public int level;
    public string[] detailsPerLevel;
    public abstract void Initialize();
    public abstract void UpgradeTo(int level);
}
