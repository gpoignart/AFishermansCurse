using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryViewUIManager : MonoBehaviour
{
    // Allow to call InventoryViewUIManager.Instance anywhere (singleton)
    public static InventoryViewUIManager Instance { get; private set; }

    // Global UI elements
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject recipeBookPanel;

    [SerializeField] private TextMeshProUGUI pageText;

    [SerializeField] private Button changeStateButton;
    [SerializeField] private TextMeshProUGUI changeStateButtonText;
    [SerializeField] private Sprite recipeBookButtonLockedSprite;
    [SerializeField] private Sprite recipeBookButtonUnlockedSprite;
    [SerializeField] private Sprite inventoryButtonSprite;

    [SerializeField] private TextMeshProUGUI fishingRodLevelText;
    [SerializeField] private TextMeshProUGUI boatLevelText;
    [SerializeField] private TextMeshProUGUI flashinglightLevelText;

    [SerializeField] private TextMeshProUGUI fishingRodDetailsText;
    [SerializeField] private TextMeshProUGUI boatDetailsText;
    [SerializeField] private TextMeshProUGUI flashinglightDetailsText;

    [SerializeField] private Image[] ingredientImages;
    [SerializeField] private TextMeshProUGUI[] ingredientTexts;

    // Internal references
    [SerializeField] private string[] fishingRodDetails =
    {
        "No special effect",
        "Green zone width increased",
        "Fish are caught more quickly"
    };
    [SerializeField] private string[] boatDetails =
    {
        "No special effect",
        "Boat speed increased",
        "Higher chances of rare fish appearing"
    };
    [SerializeField] private string[] flashlightDetails =
    {
        "No special effect",
        "...",
        "..."
    };

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

    // Update the fishing rod UI
    public void UpdateFishingRodUI(int level)
    {
        fishingRodLevelText.text = "Level " + level;
        fishingRodDetailsText.text = fishingRodDetails[level - 1];
    }

    // Update the boat UI
    public void UpdateBoatUI(int level)
    {
        boatLevelText.text = "Level " + level;
        boatDetailsText.text = boatDetails[level - 1];
    }

    // Update the flashlight UI
    public void UpdateFlashlightUI(int level)
    {
        flashinglightLevelText.text = "Level " + level;
        flashinglightDetailsText.text = flashlightDetails[level - 1];
    }

    // Update the ingredients UI
    public void UpdateIngredientUI(int index, IngredientSO ingredient)
    {
        ingredientTexts[index].text = "x " + ingredient.playerQuantityPossessed;
        ingredientImages[index].sprite = ingredient.sprite;
        ingredientImages[index].color = ingredient.color;
    }

    // Display the UI for the Inventory state
    public void ShowInventoryStateUI()
    {
        inventoryPanel.SetActive(true);
        pageText.enabled = true;
        pageText.text = "Inventory";
        changeStateButton.enabled = true;
        if (GameManager.Instance.IsRecipeBookUnlocked)
        {
            changeStateButton.interactable = true;
            changeStateButtonText.text = "Recipe Book";
            changeStateButton.GetComponent<Image>().sprite = recipeBookButtonUnlockedSprite;
        }
        else
        {
            changeStateButton.interactable = false;
            changeStateButtonText.text = "?";
            changeStateButton.GetComponent<Image>().sprite = recipeBookButtonLockedSprite;
        }
    }

    // Display the UI for the Recipe Book state
    public void ShowRecipeBookStateUI()
    {
        recipeBookPanel.SetActive(true);
        pageText.enabled = true;
        pageText.text = "Recipe Book";
        changeStateButton.enabled = true;
        changeStateButton.interactable = true;
        changeStateButtonText.text = "Inventory";
        changeStateButton.GetComponent<Image>().sprite = inventoryButtonSprite;
    }

    // Hide the UI for the Inventory state
    public void HideInventoryStateUI()
    {
        inventoryPanel.SetActive(false);
        pageText.enabled = false;
        changeStateButton.enabled = false;
    }

    // Hide the UI for the Recipe Book state
    public void HideRecipeBookStateUI()
    {
        recipeBookPanel.SetActive(false);
        pageText.enabled = false;
        changeStateButton.enabled = false;
    }
}
