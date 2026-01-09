using UnityEngine;
using System.Collections;

public class MonsterGameManager : MonoBehaviour
{
    // Singleton
    public static MonsterGameManager Instance { get; private set; }

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

    // Game elements
    [SerializeField] private BoxCollider2D leftSpawn;
    [SerializeField] private BoxCollider2D rightSpawn;
    [SerializeField] private Transform monsterContainer;
    
    // Parameters
    private float tutorialLoseTime = 10f;
    private float warningDuration = 0.7f;
    private float winMessageDuration = 2f;

    // Internal references
    private float loseTime;
    private float loseTimer;
    private bool isTimerActive;
    private bool isFlashlightActive; // Flashlight can move
    private bool isFlashlightChecking; // Flashlight check if monster
    private MonsterSO currentMonsterSO;
    private GameObject currentMonsterObj;
    
    // READ-ONLY ATTRIBUTES, CAN BE READ ANYWHERE
    public GameObject CurrentMonsterObj => currentMonsterObj;

    
    // Tutorial states
    private enum MonsterTutorialState
    {
        Start,
        NoFlashlight1,
        NoFlashlight2,
        FlashlightMonster,
        Death,
        MonsterRanAway,
        End
    }
    private MonsterTutorialState currentTutorialState = MonsterTutorialState.Start;


    // First The Offended encounter states
    private enum TheOffendedTutorialState
    {
        Start,
        Encounter,
        WinDirectly,
        DeathExplanation,
        TryAgain,
        End
    }
    private TheOffendedTutorialState currentTheOffendedTutorialState = TheOffendedTutorialState.Start;


    // First The Jester encounter states
    private enum TheJesterTutorialState
    {
        Start,
        Encounter,
        WinDirectly,
        DeathExplanation,
        TryAgain,
        End
    }
    private TheJesterTutorialState currentTheJesterTutorialState = TheJesterTutorialState.Start;


    // Start encounter
    private void Start()
    {
        // Tutorial initialization
        if (GameManager.Instance.IsFirstNight)
        {
            // Begin tutorial
            ChangeTutorialState(MonsterTutorialState.NoFlashlight1);
        }
        // Regular nights
        else
        {   
            // Hide elements
            MonsterUIManager.Instance.HideTutorialPanel();
            MonsterUIManager.Instance.HideMonsterRanAwayText();
            MonsterUIManager.Instance.HideNoiseWarning(fake: true);
            MonsterUIManager.Instance.HideNoiseWarning(fake: false);
            
            // Select randomly a monster to spawn
            MonsterSO[] allMonsters = GameManager.Instance.MonsterRegistry.AllMonsters;
            currentMonsterSO = allMonsters[Random.Range(0, allMonsters.Length)];

            // Position depending on side
            int realMonsterApparitionSide;

            if (!currentMonsterSO.isApparitionReversed) { realMonsterApparitionSide = GameManager.Instance.MonsterApparitionSide; }
            else { realMonsterApparitionSide = 1 - GameManager.Instance.MonsterApparitionSide; }

            Vector3 spawnPos = (realMonsterApparitionSide == 0)
                ? GetRandomPoint(leftSpawn)
                : GetRandomPoint(rightSpawn);

            // Spawn the monster
            currentMonsterObj = Instantiate(currentMonsterSO.monsterPrefab, spawnPos, Quaternion.identity, monsterContainer);

            // Show noise UI
            StartCoroutine(MonsterUIManager.Instance.ShowNoiseWarningForSeconds(GameManager.Instance.MonsterApparitionSide, warningDuration, currentMonsterSO.isWarningFake));

            // Start timer
            loseTime = currentMonsterSO.loseTime;
            loseTimer = 0f;
            isTimerActive = true;

            // Start flashlight
            FlashlightController.Instance.StartFlashlight();
            isFlashlightActive = true;
            isFlashlightChecking = true;

            // If first time we encounter the monster, launch the tutorial
            if (!currentMonsterSO.hasBeenEncountered && currentMonsterSO == GameManager.Instance.MonsterRegistry.theOffendedSO)
            {
                ChangeTheOffendedTutorialState(TheOffendedTutorialState.Encounter);
            }
            else if (!currentMonsterSO.hasBeenEncountered && currentMonsterSO == GameManager.Instance.MonsterRegistry.theJesterSO)
            {
                ChangeTheJesterTutorialState(TheJesterTutorialState.Encounter);
            }
        }
    }

    private void Update()
    {
        if (isFlashlightActive)
        {
            FlashlightController.Instance.UpdateFlashlight(loseTimer, loseTime, isFlashlightChecking);
        }

        if (isTimerActive)
        {
            loseTimer += Time.deltaTime;
            if (loseTimer >= loseTime)
            {
                isTimerActive = false;
                isFlashlightChecking = false;
                currentMonsterObj.GetComponent<Monster>().FlashlightTimeOut();
            }
        }

        // Handle the game update logic for tutorial states
        switch (currentTutorialState)
        {
            case MonsterTutorialState.NoFlashlight1:
                if (Input.GetKeyDown(KeyCode.Return)) { OnTutorialNextButtonPressed(); } // Click on next button with return
                break;
            
            case MonsterTutorialState.NoFlashlight2:
                if (Input.GetKeyDown(KeyCode.Return)) { OnTutorialNextButtonPressed(); } // Click on next button with return
                break;

            case MonsterTutorialState.MonsterRanAway:
                if (Input.GetKeyDown(KeyCode.Return)) { OnTutorialNextButtonPressed(); } // Click on next button with return
                break;
        }

        // Handle the game update logic for the offended tutorial states
        switch (currentTheOffendedTutorialState)
        {
            case TheOffendedTutorialState.WinDirectly:
                if (Input.GetKeyDown(KeyCode.Return)) { OnTutorialNextButtonPressed(); } // Click on next button with return
                break;
            
            case TheOffendedTutorialState.DeathExplanation:
                if (Input.GetKeyDown(KeyCode.Return)) { OnTutorialNextButtonPressed(); } // Click on next button with return
                break;
        }

        
        // Handle the game update logic for the jester tutorial states
        switch (currentTheJesterTutorialState)
        {
            case TheJesterTutorialState.WinDirectly:
                if (Input.GetKeyDown(KeyCode.Return)) { OnTutorialNextButtonPressed(); } // Click on next button with return
                break;
            
            case TheJesterTutorialState.DeathExplanation:
                if (Input.GetKeyDown(KeyCode.Return)) { OnTutorialNextButtonPressed(); } // Click on next button with return
                break;
        }
    }

    public void StopMonsterTimer()
    {
        isTimerActive = false;
    }

    public void OnTutorialNextButtonPressed()
    {   
        if (currentTutorialState == MonsterTutorialState.NoFlashlight1)
        {
            ChangeTutorialState(MonsterTutorialState.NoFlashlight2);
        }
        else if (currentTutorialState == MonsterTutorialState.NoFlashlight2)
        {
            ChangeTutorialState(MonsterTutorialState.FlashlightMonster);
        }
        else if (currentTutorialState == MonsterTutorialState.MonsterRanAway)
        {
            ChangeTutorialState(MonsterTutorialState.End);
        }
        else if (currentTheOffendedTutorialState == TheOffendedTutorialState.WinDirectly)
        {
            ChangeTheOffendedTutorialState(TheOffendedTutorialState.End);
        }
        else if (currentTheOffendedTutorialState == TheOffendedTutorialState.DeathExplanation)
        {
            ChangeTheOffendedTutorialState(TheOffendedTutorialState.TryAgain);
        }
        else if (currentTheJesterTutorialState == TheJesterTutorialState.WinDirectly)
        {
            ChangeTheJesterTutorialState(TheJesterTutorialState.End);
        }
        else if (currentTheJesterTutorialState == TheJesterTutorialState.DeathExplanation)
        {
            ChangeTheJesterTutorialState(TheJesterTutorialState.TryAgain);
        }
        AudioManager.Instance.PlayPressingButtonSFX();
    }

    public void PlayerWin()
    {        
        if (GameManager.Instance.IsFirstNight && (currentTutorialState == MonsterTutorialState.FlashlightMonster || currentTutorialState == MonsterTutorialState.Death))
        {
            ChangeTutorialState(MonsterTutorialState.MonsterRanAway);
        }
        else if (currentMonsterSO == GameManager.Instance.MonsterRegistry.theOffendedSO && currentTheOffendedTutorialState == TheOffendedTutorialState.Encounter)
        {
            ChangeTheOffendedTutorialState(TheOffendedTutorialState.WinDirectly);
        }
        else if (currentMonsterSO == GameManager.Instance.MonsterRegistry.theOffendedSO && currentTheOffendedTutorialState == TheOffendedTutorialState.TryAgain)
        {
            ChangeTheOffendedTutorialState(TheOffendedTutorialState.End);
        }
        else if (currentMonsterSO == GameManager.Instance.MonsterRegistry.theJesterSO && currentTheJesterTutorialState == TheJesterTutorialState.Encounter)
        {
            ChangeTheJesterTutorialState(TheJesterTutorialState.WinDirectly);
        }
        else if (currentMonsterSO == GameManager.Instance.MonsterRegistry.theJesterSO && currentTheJesterTutorialState == TheJesterTutorialState.TryAgain)
        {
            ChangeTheJesterTutorialState(TheJesterTutorialState.End);
        }
        else
        {
            isTimerActive = false;
            MonsterUIManager.Instance.HideSpotTheMonsterText();
            StartCoroutine(PlayPlayerWin());
        }
    }

    public IEnumerator PlayPlayerWin()
    {
        yield return new WaitForSeconds(0.5f);
        MonsterUIManager.Instance.ShowMonsterRanAwayText();
        yield return new WaitForSeconds(winMessageDuration);
        GameManager.Instance.WinAgainstMonster();
    }

    public void PlayerLose()
    {
        if (GameManager.Instance.IsFirstNight && (currentTutorialState == MonsterTutorialState.FlashlightMonster || currentTutorialState == MonsterTutorialState.Death))
        {
            ChangeTutorialState(MonsterTutorialState.Death);
        }
        else if (currentMonsterSO == GameManager.Instance.MonsterRegistry.theOffendedSO && currentTheOffendedTutorialState == TheOffendedTutorialState.Encounter)
        {
            ChangeTheOffendedTutorialState(TheOffendedTutorialState.DeathExplanation);
        }
        else if (currentMonsterSO == GameManager.Instance.MonsterRegistry.theOffendedSO && currentTheOffendedTutorialState == TheOffendedTutorialState.TryAgain)
        {
            ChangeTheOffendedTutorialState(TheOffendedTutorialState.TryAgain);
        }
        else if (currentMonsterSO == GameManager.Instance.MonsterRegistry.theJesterSO && currentTheJesterTutorialState == TheJesterTutorialState.Encounter)
        {
            ChangeTheJesterTutorialState(TheJesterTutorialState.DeathExplanation);
        }
        else if (currentMonsterSO == GameManager.Instance.MonsterRegistry.theJesterSO && currentTheJesterTutorialState == TheJesterTutorialState.TryAgain)
        {
            ChangeTheJesterTutorialState(TheJesterTutorialState.TryAgain);
        }
        else
        {
            GameManager.Instance.DeathAgainstMonster();
        }
    }


    // HELPING FUNCTIONS

    private Vector3 GetRandomPoint(BoxCollider2D zone)
    {
        Bounds b = zone.bounds;

        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);

        return new Vector3(x, y, 0f);
    }

    
    // HANDLE TUTORIAL STATES
    
    // Pass from one state to another
    private void ChangeTutorialState(MonsterTutorialState newTutorialState)
    {
        // Exit logic for the previous state
        OnTutorialStateExit(currentTutorialState);

        currentTutorialState = newTutorialState;

        // Enter logic for the new state
        OnTutorialStateEnter(currentTutorialState);
    }

    // Handle the game logic when entering states
    private void OnTutorialStateEnter(MonsterTutorialState state)
    {
        switch (state)
        {
            case MonsterTutorialState.Start:
                break;

            case MonsterTutorialState.NoFlashlight1:
                MonsterTutorialUIManager.Instance.ShowNoFlashlight1TutorialStepUI();
                break;
            
            case MonsterTutorialState.NoFlashlight2:
                MonsterTutorialUIManager.Instance.ShowNoFlashlight2TutorialStepUI();
                break;

            case MonsterTutorialState.FlashlightMonster:
                MonsterTutorialUIManager.Instance.ShowFlashlightMonsterTutorialStepUI();
                FlashlightController.Instance.StartFlashlight();
                isFlashlightActive = true;
                isFlashlightChecking = true;
                isTimerActive = true;
                break;
            
            case MonsterTutorialState.Death:
                MonsterTutorialUIManager.Instance.ShowDeathTutorialStepUI();
                loseTime = tutorialLoseTime;
                loseTimer = 0f;
                FlashlightController.Instance.StartFlashlight();
                isFlashlightActive = true;
                isFlashlightChecking = true;
                isTimerActive = true;
                break;

            case MonsterTutorialState.MonsterRanAway:
                MonsterTutorialUIManager.Instance.ShowMonsterRanAwayTutorialStepUI();
                MonsterUIManager.Instance.HideNoiseWarning();
                Cursor.visible = true;
                break;
            
            case MonsterTutorialState.End:
                loseTime = currentMonsterSO.loseTime;
                currentMonsterSO.hasBeenEncountered = true;
                MonsterUIManager.Instance.HideTutorialPanel();
                GameManager.Instance.WinAgainstMonster();
                break;
        }
    }

    // Handle the game logic when exiting states
    private void OnTutorialStateExit(MonsterTutorialState state)
    {
        switch (state)
        {
            case MonsterTutorialState.Start:
                // Hide elements
                MonsterUIManager.Instance.HideSpotTheMonsterText();
                MonsterUIManager.Instance.HideMonsterRanAwayText();
                MonsterUIManager.Instance.HideNoiseWarning(fake: true);
                MonsterUIManager.Instance.HideNoiseWarning(fake: false);

                // Position depending on side
                Vector3 spawnPos = (GameManager.Instance.MonsterApparitionSide == 0)
                    ? GetRandomPoint(leftSpawn)
                    : GetRandomPoint(rightSpawn);

                // Tutorial monster
                currentMonsterSO = GameManager.Instance.MonsterRegistry.theEyesSO;

                // Spawn the monster
                currentMonsterObj = Instantiate(currentMonsterSO.monsterPrefab, spawnPos, Quaternion.identity, monsterContainer);

                // Show noise UI
                MonsterUIManager.Instance.ShowNoiseWarning(GameManager.Instance.MonsterApparitionSide);
                
                // In tutorial, different lose time than normal
                loseTime = tutorialLoseTime;
                loseTimer = 0f;

                // No timer & no flashlight for now
                isTimerActive = false;
                isFlashlightActive = false;
                FlashlightController.Instance.HideFlashlightBeam();
                break;
            
            case MonsterTutorialState.NoFlashlight1:
                MonsterTutorialUIManager.Instance.HideNoFlashlight1TutorialStepUI();
                break;
            
            case MonsterTutorialState.NoFlashlight2:
                MonsterTutorialUIManager.Instance.HideNoFlashlight2TutorialStepUI();
                break;

            case MonsterTutorialState.FlashlightMonster:
                MonsterTutorialUIManager.Instance.HideFlashlightMonsterTutorialStepUI();
                break;
            
            case MonsterTutorialState.Death:
                MonsterTutorialUIManager.Instance.HideDeathTutorialStepUI();
                break;

            case MonsterTutorialState.MonsterRanAway:
                MonsterTutorialUIManager.Instance.HideMonsterRanAwayTutorialStepUI();
                break;

            case MonsterTutorialState.End:
                break;
        }
    }


        
    // HANDLE THE OFFENDED TUTORIAL STATES
    
    // Pass from one state to another
    private void ChangeTheOffendedTutorialState(TheOffendedTutorialState newTutorialState)
    {
        // Exit logic for the previous state
        OnTheOffendedTutorialStateExit(currentTheOffendedTutorialState);

        currentTheOffendedTutorialState = newTutorialState;

        // Enter logic for the new state
        OnTheOffendedTutorialStateEnter(currentTheOffendedTutorialState);
    }

    // Handle the game logic when entering states
    private void OnTheOffendedTutorialStateEnter(TheOffendedTutorialState state)
    {
        switch (state)
        {
            case TheOffendedTutorialState.Start:
                break;
            
            case TheOffendedTutorialState.Encounter:
                break;
            
            case TheOffendedTutorialState.WinDirectly:
                MonsterUIManager.Instance.HideSpotTheMonsterText();
                MonsterUIManager.Instance.HideMonsterRanAwayText();
                MonsterUIManager.Instance.HideNoiseWarning(fake: true);
                MonsterUIManager.Instance.HideNoiseWarning(fake: false);
                MonsterUIManager.Instance.ShowTutorialPanel();
                MonsterTutorialUIManager.Instance.ShowWinDirectlyTheOffendedTutorialStepUI();

                isFlashlightActive = true;
                isFlashlightChecking = false; // as the monster is again shown, we don't want to trigger a death by putting our flashlight on it now
                Cursor.visible = true;

                break;

            case TheOffendedTutorialState.DeathExplanation:
                MonsterUIManager.Instance.HideSpotTheMonsterText();
                MonsterUIManager.Instance.HideMonsterRanAwayText();
                MonsterUIManager.Instance.ShowTutorialPanel();
                MonsterTutorialUIManager.Instance.ShowDeathExplanationTheOffendedTutorialStepUI();
                
                FlashlightController.Instance.StartFlashlight(); // Reinitialize flashlight and camera visual
                isFlashlightChecking = false;
                Cursor.visible = true;

                break;
            
            case TheOffendedTutorialState.TryAgain:
                MonsterUIManager.Instance.HideSpotTheMonsterText();
                MonsterUIManager.Instance.HideMonsterRanAwayText();
                MonsterUIManager.Instance.ShowTutorialPanel();
                MonsterTutorialUIManager.Instance.ShowTryAgainTheOffendedTutorialStepUI();
                
                currentMonsterObj.GetComponent<TheOffended>().ReinitializeTheOffended(); // Allow the monster to be hitten again
                loseTime = currentMonsterSO.loseTime;
                loseTimer = 0f;

                FlashlightController.Instance.StartFlashlight();
                isFlashlightActive = true;
                isFlashlightChecking = true;
                isTimerActive = true;
                
                StartCoroutine(MonsterUIManager.Instance.ShowNoiseWarningForSeconds(GameManager.Instance.MonsterApparitionSide, warningDuration, currentMonsterSO.isWarningFake));
                
                break;

            case TheOffendedTutorialState.End:
                isTimerActive = false;
                MonsterUIManager.Instance.HideTutorialPanel();
                currentMonsterSO.hasBeenEncountered = true;
                GameManager.Instance.ResumeTimer();
                StartCoroutine(currentMonsterObj.GetComponent<TheOffended>().MonsterTimeOutReaction()); // The monster disappears
                StartCoroutine(PlayPlayerWin());
                break;
        }
    }

    // Handle the game logic when exiting states
    private void OnTheOffendedTutorialStateExit(TheOffendedTutorialState state)
    {
        switch (state)
        {
            case TheOffendedTutorialState.Start:
                GameManager.Instance.PauseTimer();
                break;
            
            case TheOffendedTutorialState.Encounter:
                break;
            
            case TheOffendedTutorialState.WinDirectly:
                MonsterTutorialUIManager.Instance.HideWinDirectlyTheOffendedTutorialStepUI();
                break;
            
            case TheOffendedTutorialState.DeathExplanation:
                MonsterTutorialUIManager.Instance.HideDeathExplanationTheOffendedTutorialStepUI();
                break;
            
            case TheOffendedTutorialState.TryAgain:
                MonsterTutorialUIManager.Instance.HideTryAgainTheOffendedTutorialStepUI();
                break;

            case TheOffendedTutorialState.End:
                break;
        }
    }


    // HANDLE THE JESTER TUTORIAL STATES
    
    // Pass from one state to another
    private void ChangeTheJesterTutorialState(TheJesterTutorialState newTutorialState)
    {
        // Exit logic for the previous state
        OnTheJesterTutorialStateExit(currentTheJesterTutorialState);

        currentTheJesterTutorialState = newTutorialState;

        // Enter logic for the new state
        OnTheJesterTutorialStateEnter(currentTheJesterTutorialState);
    }

    // Handle the game logic when entering states
    private void OnTheJesterTutorialStateEnter(TheJesterTutorialState state)
    {
        switch (state)
        {
            case TheJesterTutorialState.Start:
                break;
            
            case TheJesterTutorialState.Encounter:
                break;
            
            case TheJesterTutorialState.WinDirectly:
                MonsterUIManager.Instance.HideSpotTheMonsterText();
                MonsterUIManager.Instance.HideMonsterRanAwayText();
                MonsterUIManager.Instance.HideNoiseWarning(fake: true);
                MonsterUIManager.Instance.HideNoiseWarning(fake: false);
                MonsterUIManager.Instance.ShowTutorialPanel();
                MonsterTutorialUIManager.Instance.ShowWinDirectlyTheJesterTutorialStepUI();

                isFlashlightActive = true;
                Cursor.visible = true;

                break;

            case TheJesterTutorialState.DeathExplanation:
                MonsterUIManager.Instance.HideSpotTheMonsterText();
                MonsterUIManager.Instance.HideMonsterRanAwayText();
                MonsterUIManager.Instance.ShowTutorialPanel();
                MonsterTutorialUIManager.Instance.ShowDeathExplanationTheJesterTutorialStepUI();
                
                FlashlightController.Instance.StartFlashlight(); // Reinitialize flashlight and camera visual
                isFlashlightChecking = false;
                Cursor.visible = true;

                break;
            
            case TheJesterTutorialState.TryAgain:
                MonsterUIManager.Instance.HideSpotTheMonsterText();
                MonsterUIManager.Instance.HideMonsterRanAwayText();
                MonsterUIManager.Instance.ShowTutorialPanel();
                MonsterTutorialUIManager.Instance.ShowTryAgainTheJesterTutorialStepUI();
                
                loseTime = currentMonsterSO.loseTime;
                loseTimer = 0f;

                FlashlightController.Instance.StartFlashlight();
                isFlashlightActive = true;
                isFlashlightChecking = true;
                isTimerActive = true;

                MonsterUIManager.Instance.ShowNoiseWarning(GameManager.Instance.MonsterApparitionSide, currentMonsterSO.isWarningFake);
                
                break;

            case TheJesterTutorialState.End:
                isTimerActive = false;
                MonsterUIManager.Instance.HideTutorialPanel();
                currentMonsterSO.hasBeenEncountered = true;
                GameManager.Instance.ResumeTimer();
                StartCoroutine(PlayPlayerWin());
                break;
        }
    }

    // Handle the game logic when exiting states
    private void OnTheJesterTutorialStateExit(TheJesterTutorialState state)
    {
        switch (state)
        {
            case TheJesterTutorialState.Start:
                GameManager.Instance.PauseTimer();
                break;
            
            case TheJesterTutorialState.Encounter:
                break;
            
            case TheJesterTutorialState.WinDirectly:
                MonsterTutorialUIManager.Instance.HideWinDirectlyTheJesterTutorialStepUI();
                break;
            
            case TheJesterTutorialState.DeathExplanation:
                MonsterTutorialUIManager.Instance.HideDeathExplanationTheJesterTutorialStepUI();
                break;
            
            case TheJesterTutorialState.TryAgain:
                MonsterTutorialUIManager.Instance.HideTryAgainTheJesterTutorialStepUI();
                MonsterUIManager.Instance.HideNoiseWarning();
                break;

            case TheJesterTutorialState.End:
                break;
        }
    }
}
