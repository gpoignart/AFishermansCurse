using UnityEngine;

public class FishingGameManager : MonoBehaviour
{
    // Allow to call FishingGameManager.Instance anywhere (singleton)
    public static FishingGameManager Instance { get; private set; }

    // States
    private enum FishingGameState
    {
        Moving,
        Hooking,
        Fishing
    }
    private FishingGameState currentState;

    // Internal parameters
    private float startTime = 60f;
    private float timeRemaining;
    private Transform currentFishBelow = null;

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

    // Start the game mecanisms loop (called when the game start)
    void Start()
    {
        // Timer setup
        timeRemaining = startTime;
        FishingUIManager.Instance.UpdateTimerUI(timeRemaining);

        // First state
        ChangeState(FishingGameState.Moving);
    }

    // Update the game (called at each frame of the game)
    void Update()
    {
        // Update the timer
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f) { timeRemaining = 0f; }
        FishingUIManager.Instance.UpdateTimerUI(timeRemaining);

        // Handle the game update logic for states
        switch (currentState)
        {
            case FishingGameState.Moving:
                PlayerController.Instance.UpdatePlayer();
                break;

            case FishingGameState.Hooking:
                PlayerController.Instance.UpdatePlayer();
                break;

            case FishingGameState.Fishing:
                FishingMinigameManager.Instance.UpdateMiniGame();
                break;
        }
    }

    // Pass from one state to another
    private void ChangeState(FishingGameState newState)
    {
        // Exit logic for the previous state
        OnStateExit(currentState);

        currentState = newState;

        // Enter logic for the new state
        OnStateEnter(currentState);
    }

    // Handle the game logic when entering states
    private void OnStateEnter(FishingGameState state)
    {
        switch (state)
        {
            case FishingGameState.Moving:
                Debug.Log("Entering Moving state");
                break;

            case FishingGameState.Hooking:
                FishingUIManager.Instance.ShowHookingStateUI();
                Debug.Log("Entering Hooking state");
                break;

            case FishingGameState.Fishing:
                FishingUIManager.Instance.ShowFishingStateUI();
                FishingMinigameManager.Instance.StartMiniGame();
                Debug.Log("Entering Fishing state");
                break;
        }
    }

    // Handle the game logic when exiting states
    private void OnStateExit(FishingGameState state)
    {
        switch (state)
        {
            case FishingGameState.Moving:
                Debug.Log("Exiting Moving state");
                break;

            case FishingGameState.Hooking:
                FishingUIManager.Instance.HideHookingStateUI();
                Debug.Log("Exiting Hooking state");
                break;

            case FishingGameState.Fishing:
                FishingUIManager.Instance.HideFishingStateUI();
                Debug.Log("Exiting Fishing state");
                break;
        }
    }

    // Called by the PlayerController if the player is above a fish, keep the fish in memory
    public void PlayerAboveFish(Transform fishBelow)
    {
        if (currentState != FishingGameState.Hooking)
        {
            ChangeState(FishingGameState.Hooking);
        }
        currentFishBelow = fishBelow;
    }

    // Called by the PlayerController if the player is not above a fish, no fish in memory
    public void PlayerNotAboveFish()
    {
        if (currentState != FishingGameState.Moving)
        {
            ChangeState(FishingGameState.Moving);
        }
        currentFishBelow = null;
    }

    // Called when the player clicks the Hook button
    public void OnHookButtonPressed()
    {
        ChangeState(FishingGameState.Fishing);
    }

    // Called by the FishingMinigameManager when success
    public void FishingMinigameSuccess()
    {
        ChangeState(FishingGameState.Moving);

        // Delete the fish
        if (currentFishBelow != null)
        {
            Destroy(currentFishBelow.gameObject);
            currentFishBelow = null;
        }
    }

    // Called by the FishingMinigameManager when fail
    public void FishingMinigameFail()
    {
        ChangeState(FishingGameState.Moving);

        // Delete the fish
        if (currentFishBelow != null)
        {
            Destroy(currentFishBelow.gameObject);
            currentFishBelow = null;
        }
    }
}
