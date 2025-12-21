using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TransitionUIManager : MonoBehaviour
{
    // Allow to call TransitionUIManager.Instance anywhere (singleton)
    public static TransitionUIManager Instance { get; private set; }

    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI transitionText;

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

    private void Start()
    {
        backgroundImage.sprite = GameManager.Instance.CurrentTransition.backgroundSprite;
        transitionText.text = GameManager.Instance.CurrentTransition.text;
    }
}
