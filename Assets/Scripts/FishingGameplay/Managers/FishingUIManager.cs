using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FishingUIManager : MonoBehaviour
{
    // Allows to call FishingUIManager.Instance anywhere (singleton)
    public static FishingUIManager Instance { get; private set; }

    // Global UI elements
    [SerializeField]
    private SpriteRenderer skySpriteRenderer;

    [SerializeField]
    private SpriteRenderer underwaterSpriteRenderer;

    [SerializeField]
    private SpriteRenderer lakeFloorSpriteRenderer;

    [SerializeField]
    private GameObject inventoryButton;

    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private GameObject hookButton;

    [SerializeField]
    private GameObject dragBar;

    [SerializeField]
    private GameObject commandsPanel;

    [SerializeField]
    private GameObject extendCommandsButton;

    [SerializeField]
    private GameObject collapseCommandsButton;

    [SerializeField]
    private GameObject extendedCommands;

    [SerializeField]
    private GameObject loot;

    [SerializeField]
    private GameObject loseFishText;

    [SerializeField]
    private Image lootImage;

    [SerializeField]
    private GameObject tutorialPanel;

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
        if (!GameManager.Instance.IsFishingTutorialEnabled)
        {
            HideTutorialPanel();
        }
        InitializeCommandsPanel();
        hookButton.SetActive(false);
        dragBar.SetActive(false);
        loot.SetActive(false);
        loseFishText.SetActive(false);

        // Initialize backgrounds sprites
        if (GameManager.Instance.CurrentTimeOfDay == GameManager.Instance.TimeOfDayRegistry.daySO)
        {
            skySpriteRenderer.sprite = GameManager.Instance.CurrentMap.skyDaySprite;
            skySpriteRenderer.color = GameManager.Instance.CurrentMap.skyDayColor;
            underwaterSpriteRenderer.sprite = GameManager.Instance.CurrentMap.underwaterDaySprite;
            underwaterSpriteRenderer.color = GameManager.Instance.CurrentMap.underwaterDayColor;
            lakeFloorSpriteRenderer.sprite = GameManager.Instance.CurrentMap.lakeFloorDaySprite;
            lakeFloorSpriteRenderer.color = GameManager.Instance.CurrentMap.lakeFloorDayColor;
        }
        else
        {
            skySpriteRenderer.sprite = GameManager.Instance.CurrentMap.skyNightSprite;
            skySpriteRenderer.color = GameManager.Instance.CurrentMap.skyNightColor;
            underwaterSpriteRenderer.sprite = GameManager.Instance.CurrentMap.underwaterNightSprite;
            underwaterSpriteRenderer.color = GameManager.Instance.CurrentMap.underwaterNightColor;
            lakeFloorSpriteRenderer.sprite = GameManager.Instance.CurrentMap.lakeFloorNightSprite;
            lakeFloorSpriteRenderer.color = GameManager.Instance.CurrentMap.lakeFloorNightColor;
        }
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

    // Update the timer display
    public void UpdateTimerUI(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    // Show the loot for duration seconds
    public IEnumerator ShowLootForSeconds(IngredientSO ingredient, float duration)
    {
        loot.SetActive(true);
        lootImage.sprite = ingredient.sprite;
        lootImage.color = ingredient.color;

        yield return new WaitForSeconds(duration);

        loot.SetActive(false);
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

    // Show the loseFishText for duration seconds
    public IEnumerator ShowLoseFishTextForSeconds(float duration)
    {
        loseFishText.SetActive(true);

        yield return new WaitForSeconds(duration);

        loseFishText.SetActive(false);
    }

    // Hide the UI for the fishing state
    public void HideFishingStateUI()
    {
        dragBar.SetActive(false);
    }

    // Tutorial panel
    public void ShowTutorialPanel()
    {
        tutorialPanel.SetActive(true);
    }

    public void HideTutorialPanel()
    {
        tutorialPanel.SetActive(false);
    }

    // Inventory button
    public void ShowInventoryButton()
    {
        inventoryButton.SetActive(true);
    }

    public void HideInventoryButton()
    {
        inventoryButton.SetActive(false);
    }

    // Timer
    public void ShowTimer()
    {
        timer.SetActive(true);
    }

    public void HideTimer()
    {
        timer.SetActive(false);
    }

    // Commands Panel
    public void ShowCommandsPanel()
    {
        commandsPanel.SetActive(true);
    }

    public void InitializeCommandsPanel()
    {
        HideCollapseCommandsButton();
        HideExtendedCommands();
        ShowExtendCommandsButton();
    }

    public void HideCommandsPanel()
    {
        commandsPanel.SetActive(false);
    }

    // Extend Commands Button
    public void ShowExtendCommandsButton()
    {
        extendCommandsButton.SetActive(true);
    }

    public void HideExtendCommandsButton()
    {
        extendCommandsButton.SetActive(false);
    }

    // Collapse Commands Button
    public void ShowCollapseCommandsButton()
    {
        collapseCommandsButton.SetActive(true);
    }

    public void HideCollapseCommandsButton()
    {
        collapseCommandsButton.SetActive(false);
    }

    // Extended Commands
    public void ShowExtendedCommands()
    {
        extendedCommands.SetActive(true);
    }

    public void HideExtendedCommands()
    {
        extendedCommands.SetActive(false);
    }
}
