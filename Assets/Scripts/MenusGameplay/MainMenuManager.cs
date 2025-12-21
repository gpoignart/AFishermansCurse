using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{
    // Allow to call MainMenuManager.Instance anywhere (singleton)
    public static MainMenuManager Instance { get; private set; }

    [SerializeField] private Button continueButton;

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
        continueButton.interactable = SaveSystem.HasSave();
    }

    public void OnNewGameButtonPressed()
    {
        GameManager.Instance.StartNewGame();
    }

    public void OnContinueButtonPressed()
    {
        GameManager.Instance.ContinueGame();
    }

    public void OnQuitButtonPressed()
    {
        GameManager.Instance.QuitGame();
    }

    public void OnCreditsButtonPressed()
    {
        GameManager.Instance.EnterCredits();
    }
}