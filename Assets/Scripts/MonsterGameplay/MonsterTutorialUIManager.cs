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

    // Tutorial texts
    private string noFlashlightText1 =
        "While you were fishing peacefully, you stiffened and paid attention to your surroundings.";
    private string noFlashlightText2 =
        "You are being watched by a monster. You clearly heard its scream to your right.";
    private string flashlightMonsterText =
        "Hurry, move your flashlight with your mouse towards him to blind him and make him run away.";
    private string monsterRanAwayText =
        "The monster left. Who knows what would have happened if you had taken longer to react? And who knows if other monsters won't come in the coming nights?";
    
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

    public void HideMonsterRanAwayTutorialStepUI()
    {
        tutorialText.text = "";   
    }
}