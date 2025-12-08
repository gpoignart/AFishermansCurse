using UnityEngine;
using System.Collections;

public class MonsterUIManager : MonoBehaviour
{
    public static MonsterUIManager Instance { get; private set; }

    [Header("Noise Warning UI")]
    public RectTransform noiseWarningUI;
    public float warningDuration = 1.5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (noiseWarningUI != null)
            noiseWarningUI.gameObject.SetActive(false);
    }

    public void ShowNoiseWarning(int side)
    {
        if (noiseWarningUI == null) return;

        noiseWarningUI.gameObject.SetActive(true);

        float marginX = 180f;  // chỉnh cho đẹp theo game
        float marginY = 150f;  // độ cao

        if (side == 0) // LEFT
        {
            noiseWarningUI.anchorMin = new Vector2(0f, 0.5f);
            noiseWarningUI.anchorMax = new Vector2(0f, 0.5f);
            noiseWarningUI.anchoredPosition = new Vector2(marginX, marginY);
        }
        else // RIGHT
        {
            noiseWarningUI.anchorMin = new Vector2(1f, 0.5f);
            noiseWarningUI.anchorMax = new Vector2(1f, 0.5f);
            noiseWarningUI.anchoredPosition = new Vector2(-marginX, marginY);
        }

        StopAllCoroutines();
        StartCoroutine(HideNoiseWarning());
    }

    IEnumerator HideNoiseWarning()
    {
        yield return new WaitForSeconds(warningDuration);
        if (noiseWarningUI != null)
            noiseWarningUI.gameObject.SetActive(false);
    }
}
