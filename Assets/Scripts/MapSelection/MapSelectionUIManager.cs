using UnityEngine;
using TMPro;

public class MapSelectionUIManager : MonoBehaviour
{
    // Allow to call MapSelectionUIManager.Instance anywhere (singleton)
    public static MapSelectionUIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI[] mapButtonTexts;
    [SerializeField] private TextMeshProUGUI dayAndNightCounterText;

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

    public void UpdateMapButtonText(int index, MapSO map)
    {
        mapButtonTexts[index].text = map.mapName;
    }

    public void UpdateDayAndNightCounterText()
    {
        if (GameManager.Instance.CurrentTimeOfDay == GameManager.Instance.TimeOfDayRegistry.daySO)
        {
            dayAndNightCounterText.text = $"Day {GameManager.Instance.DaysCount}";
        }
        else
        {
            dayAndNightCounterText.text = $"Night {GameManager.Instance.NightsCount}";
        }
    }
}
