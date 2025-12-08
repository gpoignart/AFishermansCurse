using UnityEngine;

public class MonsterGameManager : MonoBehaviour
{
    // Singleton 
    public static MonsterGameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    [Header("Monster")]
    public GameObject TheEyes;

    [Header("Spawn Zones")]
    public BoxCollider2D leftSpawn;
    public BoxCollider2D rightSpawn;

    private GameObject currentMonster;

    void Start()
    {
        StartEncounter();
    }

    public void StartEncounter()
    {
        //Pick random side (0 = left, 1 = right)
        int side = Random.Range(0, 2);

        //Choose random position inside correct zone
        Vector3 spawnPos = (side == 0)
            ? GetRandomPoint(leftSpawn)
            : GetRandomPoint(rightSpawn);

        //Spawn monster at that position
        currentMonster = Instantiate(TheEyes, spawnPos, Quaternion.identity);
        FlashlightController.Instance.SetMonster(currentMonster.transform);


        //Show noise UI
        MonsterUIManager.Instance.ShowNoiseWarning(side);

        //Init monster behavior
        currentMonster.GetComponent<TheEyes>().Init(side);
    }


    //Generate a random point inside a BoxCollider2D area
  
    private Vector3 GetRandomPoint(BoxCollider2D zone)
    {
        Bounds b = zone.bounds;

        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);

        return new Vector3(x, y, 0f);
    }

    public void EndEncounter()
    {

        GameManager.Instance.WinAgainstMonster();

    }
}
