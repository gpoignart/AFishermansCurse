using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishingUIManager : MonoBehaviour
{
    // Allows to call FishingUIManager.Instance anywhere (singleton)
    public static FishingUIManager Instance { get; private set; }

    // Global UI elements
    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private GameObject hookButton;

    [SerializeField]
    private GameObject dragBar;

    [SerializeField]
    private GameObject loot;

    [SerializeField]
    private Image lootImage;

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

    // Initialize the UI (called when the game start)
    void Start()
    {
        hookButton.SetActive(false);
        dragBar.SetActive(false);
    }

    // Update the timer display
    public void UpdateTimerUI(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    // Show the loot
    public void ShowLoot(IngredientSO ingredient)
    {
        loot.SetActive(true);
        lootImage.sprite = ingredient.sprite;
        lootImage.color = ingredient.color;
    }

    // Hide the loot
    public void HideLoot()
    {
        loot.SetActive(false);
    }

    // Display the UI for the hooking state
    public void ShowHookingStateUI()
    {
        hookButton.SetActive(true);
    }

    // Hide the UI for the hooking state
    public void HideHookingStateUI()
    {
        hookButton.SetActive(false);
    }

    // Display the UI for the fishing state
    public void ShowFishingStateUI()
    {
        dragBar.SetActive(true);
    }

    // Hide the UI for the fishing state
    public void HideFishingStateUI()
    {
        dragBar.SetActive(false);
    }
}
