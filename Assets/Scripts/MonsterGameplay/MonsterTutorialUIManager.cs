using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MonsterTutorialUIManager : MonoBehaviour
{
    // Allows to call MonsterTutorialUIManager.Instance anywhere (singleton)
    public static MonsterTutorialUIManager Instance { get; private set; }

    // Global UI elements
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private GameObject tutorialNextButton;

    // First tutorial texts
    private string noFlashlightText1 = "While you were fishing peacefully, you stiffened and paid attention to your surroundings.";
    private string noFlashlightText2 = "You are being watched by a monster. You clearly heard its scream to your right.";
    private string flashlightMonsterText = "Hurry! Before the ring around the beam empties, move your flashlight with the arrow keys or WASD to spot the monster and make him run away!";
    private string deathText = "You can't let yourself be fooled by this monster now. Move your flashlight with the arrow keys or WASD to spot the monster and make him run away!";
    private string monsterRanAwayText = "The monster left. He seemed interested in your fishing catch. You hope no other monsters will try to steal your ingredients in the coming nights.";

    // The Offended tutorial texts
    private string theOffendedWinDirectlyText = "You're lucky.\nIt seems that this type of monster leaves you alone as long as you do NOT shine your flashlight on it while the ring around the flashlight empties.\nNext time, keep missing it.";
    private string theOffendedDeathExplanationText = "The monster attacked you!\nIt seems the only way to survive with this kind of monster is to NOT shine your light on it while the ring around the flashlight empties.\nWhen you're ready to try again, click NEXT.";
    private string theOffendedTryAgainText = "Try again! Do not shine the monster and let time pass to get out of it.";

    // The Jester tutorial texts
    private string theJesterWinDirectlyText = "You weren't tricked.\nIt seems that this kind of monster appears on the opposite side of the road from where the noise is coming from.\nPay attention to the appearance of the noise sign so you never get fooled.";
    private string theJesterDeathExplanationText = "The monster attacked you!\nIt seems that this kind of monster appears on the opposite side of the road from where the noise is coming from.\nPay attention to the appearance of the noise sign so you never get fooled.\nWhen you're ready to try again, click NEXT.";
    private string theJesterTryAgainText = "Try again! Spot the monster, at the opposite of the noise sign.";

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

    // FIRST TUTORIAL

    public void ShowNoFlashlight1TutorialStepUI()
    {
        tutorialText.text = noFlashlightText1;
    }

    public void ShowNoFlashlight2TutorialStepUI()
    {
        tutorialText.text = noFlashlightText2;
    }

    public void ShowFlashlightMonsterTutorialStepUI()
    {
        tutorialText.text = flashlightMonsterText;
        tutorialNextButton.SetActive(false);
    }

    public void ShowDeathTutorialStepUI()
    {
        tutorialText.text = deathText;
        tutorialNextButton.SetActive(false);
    }

    public void ShowMonsterRanAwayTutorialStepUI()
    {
        tutorialText.text = monsterRanAwayText;
    }

    public void HideNoFlashlight1TutorialStepUI()
    {
        tutorialText.text = "";
    }

    public void HideNoFlashlight2TutorialStepUI()
    {
        tutorialText.text = "";
    }

    public void HideFlashlightMonsterTutorialStepUI()
    {
        tutorialText.text = "";
        tutorialNextButton.SetActive(true);
    }

    public void HideDeathTutorialStepUI()
    {
        tutorialText.text = "";
        tutorialNextButton.SetActive(true);
    }

    public void HideMonsterRanAwayTutorialStepUI()
    {
        tutorialText.text = "";   
    }

    // THE OFFENDED TUTORIAL
    
    public void ShowWinDirectlyTheOffendedTutorialStepUI()
    {
        tutorialText.text = theOffendedWinDirectlyText;
    }
    
    public void ShowDeathExplanationTheOffendedTutorialStepUI()
    {
        tutorialText.text = theOffendedDeathExplanationText;
    }
    
    public void ShowTryAgainTheOffendedTutorialStepUI()
    {
        tutorialText.text = theOffendedTryAgainText;
        tutorialNextButton.SetActive(false);
    }

    public void HideWinDirectlyTheOffendedTutorialStepUI()
    {
        tutorialText.text = "";
    }

    public void HideDeathExplanationTheOffendedTutorialStepUI()
    {
        tutorialText.text = "";
    }

    public void HideTryAgainTheOffendedTutorialStepUI()
    {
        tutorialText.text = "";
        tutorialNextButton.SetActive(true);
    }


    // THE JESTER TUTORIAL
    
    public void ShowWinDirectlyTheJesterTutorialStepUI()
    {
        tutorialText.text = theJesterWinDirectlyText;
    }
    
    public void ShowDeathExplanationTheJesterTutorialStepUI()
    {
        tutorialText.text = theJesterDeathExplanationText;
    }
    
    public void ShowTryAgainTheJesterTutorialStepUI()
    {
        tutorialText.text = theJesterTryAgainText;
        tutorialNextButton.SetActive(false);
    }

    public void HideWinDirectlyTheJesterTutorialStepUI()
    {
        tutorialText.text = "";
    }

    public void HideDeathExplanationTheJesterTutorialStepUI()
    {
        tutorialText.text = "";
    }

    public void HideTryAgainTheJesterTutorialStepUI()
    {
        tutorialText.text = "";
        tutorialNextButton.SetActive(true);
    }
}