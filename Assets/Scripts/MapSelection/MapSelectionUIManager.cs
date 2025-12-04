using UnityEngine;
using TMPro;

public class MapSelectionUIManager : MonoBehaviour
{
    // Allow to call MapSelectionUIManager.Instance anywhere (singleton)
    public static MapSelectionUIManager Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI dayAndNightCounterText;

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

    // Initialize the UI (called when the scene is loaded)
    void Start()
    {
        UpdateDayAndNightCounterText();
    }

    public void UpdateDayAndNightCounterText()
    {
        if (GameManager.Instance.CurrentTimeOfDay == TimeOfDay.Day)
        {
            dayAndNightCounterText.text = $"Day {GameManager.Instance.DaysCount}";
        }
        else
        {
            dayAndNightCounterText.text = $"Night {GameManager.Instance.NightsCount}";
        }
    }
}
