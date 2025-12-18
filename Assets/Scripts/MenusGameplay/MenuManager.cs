using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    // Allow to call MenuManager.Instance anywhere (singleton)
    public static MenuManager Instance { get; private set; }

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

    // Continue Game
    public void OnContinueButtonPressed()
    {
        GameManager.Instance.ContinueGame();
    }

    // Quit game
    public void OnQuitButtonPressed()
    {
        GameManager.Instance.QuitGame();
    }
}