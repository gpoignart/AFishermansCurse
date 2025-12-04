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

    [SerializeField] private TextMeshProUGUI fishingRodLevelText;
    [SerializeField] private TextMeshProUGUI boatLevelText;
    [SerializeField] private TextMeshProUGUI flashinglightLevelText;

    [SerializeField] private TextMeshProUGUI fishingRodDetailsText;
    [SerializeField] private TextMeshProUGUI boatDetailsText;
    [SerializeField] private TextMeshProUGUI flashinglightDetailsText;

    [SerializeField] private Image ingredientOneImage;
    [SerializeField] private Image ingredientTwoImage;
    [SerializeField] private Image ingredientThreeImage;
    [SerializeField] private Image ingredientFourImage;
    [SerializeField] private Image ingredientFiveImage;
    [SerializeField] private Image ingredientSixImage;
    [SerializeField] private Image ingredientSevenImage;

    [SerializeField] private TextMeshProUGUI ingredientOneText;
    [SerializeField] private TextMeshProUGUI ingredientTwoText;
    [SerializeField] private TextMeshProUGUI ingredientThreeText;
    [SerializeField] private TextMeshProUGUI ingredientFourText;
    [SerializeField] private TextMeshProUGUI ingredientFiveText;
    [SerializeField] private TextMeshProUGUI ingredientSixText;
    [SerializeField] private TextMeshProUGUI ingredientSevenText;

    [SerializeField] private Button recipeBookButton;
    [SerializeField] private TextMeshProUGUI recipeBookButtonText;
    [SerializeField] private Sprite recipeBookButtonLockedSprite;
    [SerializeField] private Sprite recipeBookButtonUnlockedSprite;

    [SerializeField] private IngredientSO ingredientOne;
    [SerializeField] private IngredientSO ingredientTwo;
    [SerializeField] private IngredientSO ingredientThree;
    [SerializeField] private IngredientSO ingredientFour;
    [SerializeField] private IngredientSO ingredientFive;
    [SerializeField] private IngredientSO ingredientSix;
    [SerializeField] private IngredientSO ingredientSeven;

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

    // Update the recipe book button UI
    public void UpdateRecipeBookButtonUI(bool isRecipeBookUnlocked)
    {
        if (isRecipeBookUnlocked)
        {
            recipeBookButton.interactable = true;
            recipeBookButtonText.text = "";
            recipeBookButton.GetComponent<Image>().sprite = recipeBookButtonUnlockedSprite;
        }
        else
        {
            recipeBookButton.interactable = false;
            recipeBookButtonText.text = "?";
            recipeBookButton.GetComponent<Image>().sprite = recipeBookButtonLockedSprite;
        }
    }

    // Update the fishing rod UI
    public void UpdateFishingRodUI(int fishingRodLevel)
    {
        fishingRodLevelText.text = "Level " + fishingRodLevel;
        if (fishingRodLevel == 1)
        {
            fishingRodDetailsText.text = "No special effect";
        }
        else if (fishingRodLevel == 2)
        {
            fishingRodDetailsText.text = "Green zone width increased";
        }
        else
        {
            fishingRodDetailsText.text = "Fish are caught more quickly";
        }
    }

    // Update the boat UI
    public void UpdateBoatUI(int boatLevel)
    {
        boatLevelText.text = "Level " + boatLevel;
        if (boatLevel == 1)
        {
            boatDetailsText.text = "No special effect";
        }
        else if (boatLevel == 2)
        {
            boatDetailsText.text = "Boat speed increased";
        }
        else
        {
            boatDetailsText.text = "Higher chances of rare fish appearing";
        }
    }

    // Update the flashlight UI
    public void UpdateFlashlightUI(int flashlightLevel)
    {
        flashinglightLevelText.text = "Level " + flashlightLevel;
        if (flashlightLevel == 1)
        {
            flashinglightDetailsText.text = "No special effect";
        }
        else if (flashlightLevel == 2)
        {
            flashinglightDetailsText.text = "...";
        }
        else
        {
            flashinglightDetailsText.text = "...";
        }
    }

    // Update the ingredient one UI
    public void UpdateIngredientOneUI(int ingredientOneCount)
    {
        ingredientOneText.text = "x " + ingredientOneCount;
        ingredientOneImage.sprite = ingredientOne.sprite;
        ingredientOneImage.color = ingredientOne.color;
    }

    // Update the ingredient two UI
    public void UpdateIngredientTwoUI(int ingredientTwoCount)
    {
        Debug.Log("ça c'est bon");
        ingredientTwoText.text = "x " + ingredientTwoCount;
        ingredientTwoImage.sprite = ingredientTwo.sprite;
        ingredientTwoImage.color = ingredientTwo.color;
    }

    // Update the ingredient three UI
    public void UpdateIngredientThreeUI(int ingredientThreeCount)
    {
        ingredientThreeText.text = "x " + ingredientThreeCount;
        ingredientThreeImage.sprite = ingredientThree.sprite;
        ingredientThreeImage.color = ingredientThree.color;
    }

    // Update the ingredient four UI
    public void UpdateIngredientFourUI(int ingredientFourCount)
    {
        ingredientFourText.text = "x " + ingredientFourCount;
        ingredientFourImage.sprite = ingredientFour.sprite;
        ingredientFourImage.color = ingredientFour.color;
    }

    // Update the ingredient five UI
    public void UpdateIngredientFiveUI(int ingredientFiveCount)
    {
        ingredientFiveText.text = "x " + ingredientFiveCount;
        ingredientFiveImage.sprite = ingredientFive.sprite;
        ingredientFiveImage.color = ingredientFive.color;
    }

    // Update the ingredient six UI
    public void UpdateIngredientSixUI(int ingredientSixCount)
    {
        ingredientSixText.text = "x " + ingredientSixCount;
        ingredientSixImage.sprite = ingredientSix.sprite;
        ingredientSixImage.color = ingredientSix.color;
    }

    // Update the ingredient seven UI
    public void UpdateIngredientSevenUI(int ingredientSevenCount)
    {
        ingredientSevenText.text = "x " + ingredientSevenCount;
        ingredientSevenImage.sprite = ingredientSeven.sprite;
        ingredientSevenImage.color = ingredientSeven.color;
    }

    // Display the UI for the Inventory state
    public void ShowInventoryStateUI()
    {
        inventoryPanel.SetActive(true);
    }

    // Display the UI for the Recipe Book state
    public void ShowRecipeBookStateUI()
    {
        recipeBookPanel.SetActive(true);
    }

    // Hide the UI for the Inventory state
    public void HideInventoryStateUI()
    {
        inventoryPanel.SetActive(false);
    }

    // Hide the UI for the Recipe Book state
    public void HideRecipeBookStateUI()
    {
        recipeBookPanel.SetActive(false);
    }
}
