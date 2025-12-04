using UnityEngine;

public class InventoryViewUIManager : MonoBehaviour
{
    // Allow to call InventoryViewUIManager.Instance anywhere (singleton)
    public static InventoryViewUIManager Instance { get; private set; }

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
