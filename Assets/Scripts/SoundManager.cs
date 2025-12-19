using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Allow to call SoundManager.Instance anywhere (singleton)
    public static SoundManager Instance { get; private set; }

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

    private void Start()
    {
    }
}
