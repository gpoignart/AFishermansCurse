using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Panels
        // in-game
    [SerializeField] private GameObject IdlePanel;
    [SerializeField] private GameObject WaitPanel;
    [SerializeField] private GameObject HookPanel;
    [SerializeField] private GameObject DragPanel;
        // pause/end-game
    [SerializeField] private GameObject TimeOutPanel;
    [SerializeField] private GameObject PausePanel;

    // Global UI elements
    [SerializeField] private GameObject BackgroundImage;
        // in-game
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject Timer;
    [SerializeField] private GameObject FishCounter;
    [SerializeField] private GameObject Character;
        // pause/end-game
    [SerializeField] private GameObject PauseAndEndBoard;

    // Hook Button (usefull to set its position randomly)
    [SerializeField] private GameObject HookButton;

    // FishCounter positions (for moving it in the TimeOutPanel)
    private Vector2 FishCounterCenterPosition = new Vector2(0, 0);
    private Vector2 FishCounterTopRightPosition = new Vector2(760, 430);

    // Texts to update for the timer and the fishcount
    [SerializeField] private TMPro.TextMeshProUGUI timerText;
    [SerializeField] private TMPro.TextMeshProUGUI fishCounterText;


    // Called when the game start, initialize the UI
    void Start()
    {
        // We start on the idle panel
        ShowIdlePanel();
    }

    // This method shows the idle panel
    public void ShowIdlePanel()
    {
        // Set inactive all panels except the idle panel
        IdlePanel.SetActive(true);
        WaitPanel.SetActive(false);
        HookPanel.SetActive(false);
        DragPanel.SetActive(false);
        TimeOutPanel.SetActive(false);
        PausePanel.SetActive(false);

        // Set in-game elements active
        SetInGameElementsActive();
    }

    // This method shows the waiting panel
    public void ShowWaitingPanel()
    {
        // Set inactive all panels except the wait panel
        IdlePanel.SetActive(false);
        WaitPanel.SetActive(true);
        HookPanel.SetActive(false);
        DragPanel.SetActive(false);
        TimeOutPanel.SetActive(false);
        PausePanel.SetActive(false);

        // Set in-game elements active
        SetInGameElementsActive();
    }

    // This method shows the hook panel
    public void ShowHookPanel()
    {
        // Set inactive all panels except the hook panel
        IdlePanel.SetActive(false);
        WaitPanel.SetActive(false);
        HookPanel.SetActive(true);
        DragPanel.SetActive(false);
        TimeOutPanel.SetActive(false);
        PausePanel.SetActive(false);

        // Set in-game elements active
        SetInGameElementsActive();

        // Set the hook button position randomly in the 3/4 from the bottom of the screen
        SetHookButtonRandomPosition();
;   }

    // This method shows the drag panel
    public void ShowDragPanel()
    {
        // Set inactive all panels except the hook panel
        IdlePanel.SetActive(false);
        WaitPanel.SetActive(false);
        HookPanel.SetActive(false);
        DragPanel.SetActive(true);
        TimeOutPanel.SetActive(false);
        PausePanel.SetActive(false);

        // Set in-game elements active
        SetInGameElementsActive();
    }

    // This method shows the timeout panel
    public void ShowTimeOutPanel()
    {
        // Set inactive all panels except the timeout panel
        IdlePanel.SetActive(false);
        WaitPanel.SetActive(false);
        HookPanel.SetActive(false);
        DragPanel.SetActive(false);
        TimeOutPanel.SetActive(true);
        PausePanel.SetActive(false);

        // Set pause/end-game elements active
        SetPauseEndGameElementsActive();

        // Set the fish counter at the center position
        RectTransform FishCounterRect = FishCounter.GetComponent<RectTransform>();
        FishCounterRect.anchoredPosition = FishCounterCenterPosition;
        FishCounter.SetActive(true);
    }

    // This method shows the pause panel
    public void ShowPausePanel()
    {
        // Set inactive all panels except the pause panel
        IdlePanel.SetActive(false);
        WaitPanel.SetActive(false);
        HookPanel.SetActive(false);
        DragPanel.SetActive(false);
        TimeOutPanel.SetActive(false);
        PausePanel.SetActive(true);

        // Set pause/end-game elements active
        SetPauseEndGameElementsActive();
    }

    // This method updates the timer display
    public void UpdateTimerDisplay(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    // This method updates the fish count display
    public void UpdateFishCounterDisplay(int fishCount)
    {
        fishCounterText.text = "x " + fishCount.ToString();
    }

    // This method sets in-game ui element active, pause/end-game ui elements inactive
    // and positionate top-right the fish counter
    private void SetInGameElementsActive()
    {
        PauseButton.SetActive(true);
        Timer.SetActive(true);
        FishCounter.SetActive(true);
        Character.SetActive(true);
        PauseAndEndBoard.SetActive(false);

        // Set the fish counter at the top-right position
        RectTransform FishCounterRect = FishCounter.GetComponent<RectTransform>();
        FishCounterRect.anchoredPosition = FishCounterTopRightPosition;

    }

    // This method sets in-game ui element inactive and pause/end-game ui elements active
    private void SetPauseEndGameElementsActive()
    {
        PauseButton.SetActive(false);
        Timer.SetActive(false);
        FishCounter.SetActive(false);
        Character.SetActive(false);
        PauseAndEndBoard.SetActive(true);
    }

    // This method sets the hookButton at a random position in the canvas (in the 3/4 from the bottom)
    private void SetHookButtonRandomPosition()
    {
        RectTransform HookPanelRect = HookPanel.GetComponent<RectTransform>();
        RectTransform HookButtonRect = HookButton.GetComponent<RectTransform>();

        // Horizontal limits (all the width)
        float xMin = -HookPanelRect.rect.width / 2 + HookButtonRect.rect.width / 2;
        float xMax = HookPanelRect.rect.width / 2 - HookButtonRect.rect.width / 2;

        // Vertical limits (the 3/4 from the bottom)
        float yMin = -HookPanelRect.rect.height / 2 + HookButtonRect.rect.height / 2;
        float yMax = -HookPanelRect.rect.height / 2 + HookPanelRect.rect.height * 0.75f - HookButtonRect.rect.height / 2;

        // Position aléatoire
        float randomX = Random.Range(xMin, xMax);
        float randomY = Random.Range(yMin, yMax);

        HookButtonRect.anchoredPosition = new Vector2(randomX, randomY);
    }
}
