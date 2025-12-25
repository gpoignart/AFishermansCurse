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
        "You’ve arrived at your fishing spot.\nTry moving around by holding the Horizontal Arrow Keys, or A and D.";
    private string flipText =
        "You can turn around by pressing W or the Up Arrow.";
    private string detectFishText =
        "You notice a fish in the water.\nPosition your fishing rod directly above it to start fishing.";
    private string hookText =
        "Press Space or click the hook button to hook the fish.";
    private string fishing1Text =
        "The fish is resisting.\nHold the Spacebar to move the yellow bar to the right, and release it to move it back to the left.\nTake a moment to get used to the yellow bar movement, then click NEXT.";
    private string fishing2Text =
        "You can now see your progress bar.\nKeeping the yellow bar in the green zone fills the green side on the right, while leaving it fills the red side on the left. Fill the green side to catch the fish, but beware: if the red side fills first, the fish escapes.\nExperiment a bit before clicking NEXT.";
    private string fishing3Text =
        "Now, try to catch the next fish.";
    private string lootText =
        "By catching a fish, you collect a special ingredient.\nDifferent fish provide different ingredients.";
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

    public void ShowFishing1TutorialStepUI()
    {
        tutorialText.text = fishing1Text;
        tutorialNextButton.SetActive(true);
    }

    public void ShowFishing2TutorialStepUI()
    {
        tutorialText.text = fishing2Text;
        tutorialNextButton.SetActive(true);
    }

    public void ShowFishing3TutorialStepUI()
    {
        tutorialText.text = fishing3Text;
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

    public void HideFishing1TutorialStepUI()
    {
        tutorialText.text = "";        
        tutorialNextButton.SetActive(false); 
    }

    public void HideFishing2TutorialStepUI()
    {
        tutorialText.text = "";
        tutorialNextButton.SetActive(false);
    }

    public void HideFishing3TutorialStepUI()
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