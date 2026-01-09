using UnityEngine;
using System.Collections;

public class MonsterUIManager : MonoBehaviour
{
    public static MonsterUIManager Instance { get; private set; }

    // Noise warning UI
    [SerializeField] private RectTransform noiseWarningUI;
    [SerializeField] private RectTransform fakeNoiseWarningUI;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject spotTheMonsterText;
    [SerializeField] private GameObject monsterRanAwayText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (noiseWarningUI != null) { noiseWarningUI.gameObject.SetActive(false); }
    }

    // Noise warning
    public void ShowNoiseWarning(int side, bool fake = false)
    {
        float marginX = 180f;
        float marginY = 150f;

        RectTransform currentNoiseWarningUI;

        if (!fake) { currentNoiseWarningUI = noiseWarningUI; }
        else { currentNoiseWarningUI = fakeNoiseWarningUI; }

        currentNoiseWarningUI.gameObject.SetActive(true);
        
        // LEFT
        if (side == 0)
        {
            currentNoiseWarningUI.anchorMin = new Vector2(0f, 0.5f);
            currentNoiseWarningUI.anchorMax = new Vector2(0f, 0.5f);
            currentNoiseWarningUI.anchoredPosition = new Vector2(marginX, marginY);
        }
        // RIGHT
        else 
        {
            currentNoiseWarningUI.anchorMin = new Vector2(1f, 0.5f);
            currentNoiseWarningUI.anchorMax = new Vector2(1f, 0.5f);
            currentNoiseWarningUI.anchoredPosition = new Vector2(-marginX, marginY);
        }
    }

    public IEnumerator ShowNoiseWarningForSeconds(int side, float duration, bool fake = false)
    {
        ShowNoiseWarning(side, fake);

        StopAllCoroutines();
        yield return new WaitForSeconds(duration);

        HideNoiseWarning(fake);
    }

    public void HideNoiseWarning(bool fake = false)
    {
        if (!fake) { noiseWarningUI.gameObject.SetActive(false); }
        else { fakeNoiseWarningUI.gameObject.SetActive(false); }
    }

    // Spot the monster text
    public void ShowSpotTheMonsterText()
    {
        spotTheMonsterText.SetActive(true);
    }

    public void HideSpotTheMonsterText()
    {
        spotTheMonsterText.SetActive(false);
    }

    // The monster ran away text
    public void ShowMonsterRanAwayText()
    {
        monsterRanAwayText.SetActive(true);
    }
    
    public void HideMonsterRanAwayText()
    {
        monsterRanAwayText.SetActive(false);
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
}
