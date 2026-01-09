using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class MapSelectionUIManager : MonoBehaviour
{
    // Allow to call MapSelectionUIManager.Instance anywhere (singleton)
    public static MapSelectionUIManager Instance { get; private set; }

    // Sprites
    [SerializeField] private Sprite dayBackgroundSprite;
    [SerializeField] private Sprite nightBackgroundSprite;

    // UI elements
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI dayAndNightCounterText;
    [SerializeField] private TextMeshProUGUI chooseAMapText;
    [SerializeField] private GameObject explanationPanel;
    [SerializeField] private TextMeshProUGUI explanationText;
    [SerializeField] private CanvasGroup mapSelectionButtons;
    [SerializeField] private Image[] mapButtonImages;
    [SerializeField] private Transform[] mapBubbleContainers;
    [SerializeField] private TextMeshProUGUI[] mapButtonTexts;
    
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

    public void UpdateBackgroundImage()
    {
        if (GameManager.Instance.CurrentTimeOfDay == GameManager.Instance.TimeOfDayRegistry.daySO)
        {
            backgroundImage.sprite = dayBackgroundSprite;
        }
        else
        {
            backgroundImage.sprite = nightBackgroundSprite;         
        }
    }

    public void UpdateDayAndNightCounterText()
    {
        if (GameManager.Instance.CurrentTimeOfDay == GameManager.Instance.TimeOfDayRegistry.daySO)
        {
            dayAndNightCounterText.text = $"DAY {GameManager.Instance.DaysCount}";
        }
        else
        {
            dayAndNightCounterText.text = $"NIGHT {GameManager.Instance.NightsCount}";
        }
    }

    public void UpdateMapButton(int index, string mapName, Sprite mapLogo)
    {
        mapButtonTexts[index].text = mapName;
        mapButtonImages[index].sprite = mapLogo;
    }

    public void UpdateBubbles(int indexMap, FishSO[] fishes)
    {
        Transform bubbleContainer = mapBubbleContainers[indexMap];
        int bubbleCount = bubbleContainer.childCount;

        for (int i = 0; i < bubbleCount; i++)
        {
            Transform bubble = bubbleContainer.GetChild(i);

            // If there is no fish for this bubble, hide it
            if (i >= fishes.Length)
            {
                bubble.gameObject.SetActive(false);
                continue;
            }

            bubble.gameObject.SetActive(true);

            // Fish bubble
            FishSO fish = fishes[i];
            Transform fishBubble = bubble.Find("FishBubble");
            Image fishBubbleImage = fishBubble.GetComponent<Image>();
            
            if (GameManager.Instance.CurrentTimeOfDay == GameManager.Instance.TimeOfDayRegistry.daySO)
            {
                fishBubbleImage.color = GameManager.Instance.MapRegistry.AllMaps[indexMap].dayFishBubbleColor;
            }
            else
            {
                fishBubbleImage.color = GameManager.Instance.MapRegistry.AllMaps[indexMap].nightFishBubbleColor;                
            }
            
            Image fishImage = fishBubble.GetChild(0).GetComponent<Image>();
            fishImage.sprite = fish.sprite;
            fishImage.preserveAspect = true;

            // Ingredient bubbles
            int ingredientIndex = 0;

            foreach (IngredientSO ingredient in fish.drops)
            {
                string ingredientBubbleName = $"IngredientBubble{ingredientIndex + 1}";
                Transform ingredientBubble = bubble.Find(ingredientBubbleName);

                ingredientBubble.gameObject.SetActive(true);

                Image ingredientBubbleImage = ingredientBubble.GetComponent<Image>();

                if (GameManager.Instance.CurrentTimeOfDay == GameManager.Instance.TimeOfDayRegistry.daySO)
                {
                    ingredientBubbleImage.color = GameManager.Instance.MapRegistry.AllMaps[indexMap].dayIngredientBubbleColor;
                }
                else
                {
                    ingredientBubbleImage.color = GameManager.Instance.MapRegistry.AllMaps[indexMap].nightIngredientBubbleColor;                
                }
                
                Image ingredientImage = ingredientBubble.GetChild(0).GetComponent<Image>();
                ingredientImage.sprite = ingredient.sprite;

                ingredientIndex++;
            }

            // Hide unused ingredient bubbles
            for (int j = ingredientIndex + 1; j <= 3; j++)
            {
                Transform unusedBubble = bubble.Find($"IngredientBubble{j}");
                if (unusedBubble != null) { unusedBubble.gameObject.SetActive(false); }
            }
        }
    }

    public void UpdateExplanationText(string explanationTextContent)
    {
        explanationText.text = explanationTextContent;
    }

    public void ShowExplanationPanel()
    {
        explanationPanel.SetActive(true);
    }

    public void HideExplanationPanel()
    {
        explanationPanel.SetActive(false);   
    }

    public void ShowChooseAMapText()
    {
        chooseAMapText.gameObject.SetActive(true);
    }

    public void HideChooseAMapText()
    {
        chooseAMapText.gameObject.SetActive(false);
    }

    public void DisableMapSelectionButtons()
    {
        mapSelectionButtons.interactable = false;
    }

    public void AbleMapSelectionButtons()
    {
        mapSelectionButtons.interactable = true;
    }

    public void ChangeMapBubbleContainersOpacity(float opacity)
    {
        foreach (Transform bubbleContainer in mapBubbleContainers)
        {
            CanvasGroup canvasGroup = bubbleContainer.GetComponent<CanvasGroup>();
            canvasGroup.alpha = opacity;
        }
    }
}
