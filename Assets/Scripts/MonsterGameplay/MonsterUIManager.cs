using UnityEngine;
using System.Collections;

public class MonsterUIManager : MonoBehaviour
{
    public static MonsterUIManager Instance { get; private set; }

    // Noise warning UI
    [SerializeField] private RectTransform noiseWarningUI;
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
    public void ShowNoiseWarning(int side)
    {
        if (noiseWarningUI == null) return;

        noiseWarningUI.gameObject.SetActive(true);

        float marginX = 180f;
        float marginY = 150f;
        
        // LEFT
        if (side == 0)
        {
            noiseWarningUI.anchorMin = new Vector2(0f, 0.5f);
            noiseWarningUI.anchorMax = new Vector2(0f, 0.5f);
            noiseWarningUI.anchoredPosition = new Vector2(marginX, marginY);
        }
        // RIGHT
        else 
        {
            noiseWarningUI.anchorMin = new Vector2(1f, 0.5f);
            noiseWarningUI.anchorMax = new Vector2(1f, 0.5f);
            noiseWarningUI.anchoredPosition = new Vector2(-marginX, marginY);
        }
    }

    public IEnumerator ShowNoiseWarningForSeconds(int side, float duration)
    {
        ShowNoiseWarning(side);

        StopAllCoroutines();
        yield return new WaitForSeconds(duration);

        HideNoiseWarning();
    }

    public void HideNoiseWarning()
    {
        if (noiseWarningUI != null) { noiseWarningUI.gameObject.SetActive(false); }
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
    public IEnumerator ShowMonsterRanAwayTextForSeconds(float duration)
    {
        monsterRanAwayText.SetActive(true);

        yield return new WaitForSeconds(duration);

        HideMonsterRanAwayText();
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
