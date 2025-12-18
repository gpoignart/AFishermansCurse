using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FishingTutorialUIManager : MonoBehaviour
{
    // Allows to call FishingTutorialUIManager.Instance anywhere (singleton)
    public static FishingTutorialUIManager Instance { get; private set; }

    // Global UI elements
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private GameObject tutorialNextButton;

    // Tutorial texts
    private string moveText =
        "You’ve arrived at your fishing spot.\nTry moving around by holding the horizontal arrow keys, or A and D.";
    private string flipText =
        "You can turn around by pressing F.";
    private string detectFishText =
        "You notice a fish in the water.\nPosition your fishing rod directly above it to start fishing.";
    private string hookText =
        "Press Space or click the hook button to hook the fish.";
    private string fishingText =
        "The fish is resisting.\nHold the Spacebar to move the yellow bar to the right, release it to move left.\nKeep the yellow bar inside the green zone as long as possible to catch the fish. Staying outside for too long will cause it to escape.";
    private string lootText =
        "By catching this fish, you collect a special ingredient.\nYour loot appears in the bottom right corner.\nDifferent fish provide different ingredients.";
    private string inventoryText =
        "Ingredients gathered during your journey may prove essential.\nYou can review your collected ingredients and current equipment in your inventory, accessible at the end of the tutorial.";
    private string timerText =
        "As nothing lasts forever, you can see on the timer how much time you have left before nightfall.\nMake the most of the day and keep fishing.";

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

    public void ShowMoveTutorialStepUI()
    {
        tutorialText.text = moveText;
        tutorialNextButton.SetActive(false);
    }

    public void ShowFlipTutorialStepUI()
    {
        tutorialText.text = flipText;
        tutorialNextButton.SetActive(false);
    }

    public void ShowDetectFishTutorialStepUI()
    {
        tutorialText.text = detectFishText;
        tutorialNextButton.SetActive(false);
    }

    public void ShowHookTutorialStepUI()
    {
        tutorialText.text = hookText;
        tutorialNextButton.SetActive(false);
    }

    public void ShowFishingTutorialStepUI()
    {
        tutorialText.text = fishingText;
        tutorialNextButton.SetActive(false);
    }

    public void ShowLootTutorialStepUI()
    {
        tutorialText.text = lootText;
        tutorialNextButton.SetActive(true);
    }

    public void ShowInventoryTutorialStepUI()
    {
        tutorialText.text = inventoryText;
        tutorialNextButton.SetActive(true);
    }

    public void ShowTimerTutorialStepUI()
    {
        tutorialText.text = timerText;
        tutorialNextButton.SetActive(true);
    }

    public void HideMoveTutorialStepUI()
    {
        tutorialText.text = "";   
    }

    public void HideFlipTutorialStepUI()
    {
        tutorialText.text = "";         
    }

    public void HideDetectFishTutorialStepUI()
    {
        tutorialText.text = "";         
    }

    public void HideHookTutorialStepUI()
    {
        tutorialText.text = "";         
    }

    public void HideFishingTutorialStepUI()
    {
        tutorialText.text = "";         
    }

    public void HideLootTutorialStepUI()
    {
        tutorialText.text = "";  
        tutorialNextButton.SetActive(false);    
    }

    public void HideInventoryTutorialStepUI()
    {
        tutorialText.text = "";   
        tutorialNextButton.SetActive(false);    
    }

    public void HideTimerTutorialStepUI()
    {
        tutorialText.text = "";
        tutorialNextButton.SetActive(false);
    }
}