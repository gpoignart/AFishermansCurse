using UnityEngine;

public class InventoryViewGameManager : MonoBehaviour
{
    // Allow to call InventoryViewGameManager.Instance anywhere (singleton)
    public static InventoryViewGameManager Instance { get; private set; }

    // Make this class a singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
