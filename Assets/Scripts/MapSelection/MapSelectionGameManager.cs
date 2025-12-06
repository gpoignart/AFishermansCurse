using UnityEngine;

public class MapSelectionGameManager : MonoBehaviour
{
    // Allow to call MapSelectionGameManager.Instance anywhere (singleton)
    public static MapSelectionGameManager Instance { get; private set; }

    // Internal reference
    MapSO[] maps = GameManager.Instance.MapRegistry.AllMaps;

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

    private void Start()
    {
        UpdateUI();
    }

    // Called when the player clicks map button 1
    public void OnMapButton1Pressed()
    {
        GameManager.Instance.SelectMap(maps[0]);
    }

    // Called when the player clicks map button 2
    public void OnMapButton2Pressed()
    {
        GameManager.Instance.SelectMap(maps[1]);
    }

    // Called when the player clicks map button 3
    public void OnMapButton3Pressed()
    {
        GameManager.Instance.SelectMap(maps[2]);
    }

    // Called when the player clicks inventory button
    public void OnInventoryButtonPressed()
    {
        GameManager.Instance.EnterInventory();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < maps.Length; i++)
        {
            MapSelectionUIManager.Instance.UpdateMapButtonText(i, maps[i]);
        }
        MapSelectionUIManager.Instance.UpdateDayAndNightCounterText();
    }
}
