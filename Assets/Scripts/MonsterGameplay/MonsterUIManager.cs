using UnityEngine;

public class MonsterUIManager : MonoBehaviour
{
    // Allow to call MonsterUIManager.Instance anywhere (singleton)
    public static MonsterUIManager Instance { get; private set; }

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
}
