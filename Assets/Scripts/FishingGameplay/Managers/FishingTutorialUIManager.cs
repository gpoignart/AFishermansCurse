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
    private string moveText = "You've arrived at your fishing spot!\nFirst, try moving around the space by holding the horizontal arrow keys, or A and D.";
    private string flipText = "You can also turn around by clicking on F.";
    private string detectFishText = "You spot the first fish!\nPosition your fishing rod directly above it to begin fishing.";
    private string hookText = "Press space or click the hook button to hook the fish.";
    private string fishingText = "The fish is putting up a fight! Hold down spacebar to move the yellow bar to the right and release to move it to the left.\nKeep your yellow bar inside the green zone as long as possible to catch it. If you leave it outside for too long, the fish will eventually escape.";
    private string lootText = "By catching this fish, you collected a special ingredient. You can see your loot appear in the bottom right corner.\nEach kind of fish gives different ingredients.";
    private string inventoryText = "Gathering different ingredients during your journey could prove essential.\nYou can find a list of the ingredients you've collected, as well as your current equipment, in your inventory, which will be accessible at the end of the tutorial.";
    private string timerText = "As nothing lasts forever, you can see on the timer how much time you have left before nightfall.\nEnjoy the end of the day and keep fishing!"; 
    
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