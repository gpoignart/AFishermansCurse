using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Allow to call GameManager.Instance anywhere (singleton)
    public static GameManager Instance { get; private set; }

    // Attributes
    [SerializeField]
    private float dayDuration = 120f;

    [SerializeField]
    private float nightDuration = 120f;

    // Internal attributes
    private float timeRemaining;
    private Map currentMap;
    private TimeOfDay currentTimeOfDay;
    private int daysCount;
    private int nightsCount;
    private bool isFirstDay;
    private bool isFirstNight;
    private bool isRecipeBookUnlocked;

    // READ-ONLY ATTRIBUTES, CAN BE READ ANYWHERE
    public Map CurrentMap => currentMap;
    public TimeOfDay CurrentTimeOfDay => currentTimeOfDay;
    public float TimeRemaining => timeRemaining;
    public int DaysCount => daysCount;
    public int NightsCount => nightsCount;
    public bool IsFirstDay => isFirstDay;
    public bool IsFirstNight => isFirstNight;
    public bool IsRecipeBookUnlocker => isRecipeBookUnlocked;

    // Internal states
    private enum GameState
    {
        MapSelection,
        InventoryView,
        FishingView,
        MonsterView,
        IntroEvent,
        RecipeBookEvent,
        EndEvent
    }
    private GameState currentState;


    // Make this class a singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Keep the game context active for all scenes
        DontDestroyOnLoad(gameObject);
    }

    // Start the game mecanisms loop (called when the game start)
    void Start()
    {
        // Initialize attributes
        currentTimeOfDay = TimeOfDay.Day;
        daysCount = 1;
        nightsCount = 0;
        isFirstDay = true;
        isFirstNight = false;
        isRecipeBookUnlocked = true;

        // First state
        // TO CHANGE BY WHEN THE INTRO EVENT MADE : ChangeState(GameState.IntroEvent);
        ChangeState(GameState.MapSelection);
    }


    // PUBLIC FONCTIONS

    // Called at the end of the introEvent
    public void ExitIntroEvent()
    {
        ChangeState(GameState.MapSelection);
    }

    // Called at the end of the recipeBookEvent
    public void ExitRecipeBookEvent()
    {
        ChangeState(GameState.MapSelection);
        isRecipeBookUnlocked = true;
    }

    // Called in the MapSelection Scene when clicking on the inventory
    public void EnterInventory()
    {
        ChangeState(GameState.InventoryView);
    }

    // Called in the Inventory Scene when clicking return
    public void ExitInventory()
    {
        ChangeState(GameState.MapSelection);
    }

    // Called in the MapSelection Scene when clicking on a map
    public void SelectMap(Map mapSelected)
    {
        currentMap = mapSelected;
        StartTimer();
        ChangeState(GameState.FishingView);
    }

    // Called in the FishingView Scene in need of passing in monster view
    public void EnterMonsterView()
    {
        ChangeState(GameState.MonsterView);
    }

    // Called in the MonsterView Scene the first night in case of death
    public void FirstDeath()
    {
        ChangeState(GameState.MonsterView);
    }

    // Called in the MonsterView Scene the first night in case of win
    public void FirstWinAgainstMonster()
    {
        ChangeCurrentTimeOfDay();
        // TO CHANGE BY WHEN THE RECIPE BOOK EVENT MADE : ChangeState(GameState.RecipeBookEvent);
        ChangeState(GameState.MapSelection);
    }

    // Called in the MonsterView Scene after fending off the monster (except the first night)
    public void WinAgainstMonster()
    {
        ChangeState(GameState.FishingView);
    }

    // Called in the MonsterView Scene after dying
    public void Death()
    {
        ChangeState(GameState.FishingView);
    }

    // Called in the InventoryView when the player make the final remedy
    public void EnterEndEvent()
    {
        ChangeState(GameState.EndEvent);
    }

    // PRIVATE FONCTIONS

    // Update the game (called at each frame of the game)
    void Update()
    {
        // Handle the game update logic for states
        switch (currentState)
        {
            case GameState.MapSelection:
                break;

            case GameState.InventoryView:
                break;

            case GameState.FishingView:
                UpdateTimerAndCheckIfOut();
                break;

            case GameState.MonsterView:
                UpdateTimerAndCheckIfOut();
                break;

            case GameState.IntroEvent:
                break;

            case GameState.RecipeBookEvent:
                break;

            case GameState.EndEvent:
                break;
        }
    }

    // Pass from one state to another
    private void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.MapSelection:
                SceneManager.LoadScene("MapSelection");
                break;
            case GameState.InventoryView:
                SceneManager.LoadScene("InventoryView");
                break;
            case GameState.FishingView:
                SceneManager.LoadScene("FishingView");
                break;
            case GameState.MonsterView:
                SceneManager.LoadScene("MonsterView");
                break;
            case GameState.IntroEvent:
                SceneManager.LoadScene("IntroEvent");
                break;
            case GameState.RecipeBookEvent:
                SceneManager.LoadScene("RecipeBookEvent");
                break;
            case GameState.EndEvent:
                SceneManager.LoadScene("EndEvent");
                break;
        }
    }

    // Called when the time is out, we exit the fishing/monster view and return to the map selection
    private void TimeOut()
    {
        // TO CHANGE WHEN MONSTER VIEW MADE : if (isFirstNight) { return; } // The first night is not influenced by the timer as it's the monster tutorial
        ChangeCurrentTimeOfDay();
        ChangeState(GameState.MapSelection);
    }

    private void StartTimer()
    {
        if (currentTimeOfDay == TimeOfDay.Day)
        {
            timeRemaining = dayDuration;
        }
        else
        {
            timeRemaining = nightDuration;
        }
    }

    private void UpdateTimerAndCheckIfOut()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            TimeOut();
        }
    }

    private void ChangeCurrentTimeOfDay()
    {
        if (currentTimeOfDay == TimeOfDay.Day)
        {
            currentTimeOfDay = TimeOfDay.Night;
            nightsCount++;
            if (nightsCount == 1) { isFirstNight = true; }
            else { isFirstNight = false; }
        }
        else
        {
            currentTimeOfDay = TimeOfDay.Day;
            daysCount++;
            if (daysCount == 1) { isFirstDay = true; }
            else { isFirstDay = false; }
        }
    }
}
