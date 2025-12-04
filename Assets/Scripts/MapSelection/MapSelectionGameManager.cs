using UnityEngine;

public class MapSelectionGameManager : MonoBehaviour
{
    // Allow to call MapSelectionGameManager.Instance anywhere (singleton)
    public static MapSelectionGameManager Instance { get; private set; }

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

    // Called when the player clicks map one button
    public void OnMapOneButtonPressed()
    {
        GameManager.Instance.SelectMap(Map.MapOne);
    }

    // Called when the player clicks map two button
    public void OnMapTwoButtonPressed()
    {
        GameManager.Instance.SelectMap(Map.MapTwo);
    }

    // Called when the player clicks map three button
    public void OnMapThreeButtonPressed()
    {
        GameManager.Instance.SelectMap(Map.MapThree);
    }

    // Called when the player clicks inventory button
    public void OnInventoryButtonPressed()
    {
        GameManager.Instance.EnterInventory();
    }
}
