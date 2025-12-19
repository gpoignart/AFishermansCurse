using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FishSpawner : MonoBehaviour
{
    // Allow to call FishSpawner.Instance anywhere (singleton)
    public static FishSpawner Instance { get; private set; }

    [SerializeField]
    private GameObject fishPrefab;

    [SerializeField]
    private BoxCollider2D spawnZone;

    [SerializeField]
    private Transform fishContainer;

    // Parameters
    private float minDistBetweenFish = 2f;
    private int minFish = 3;
    private int maxFish = 7;
    private int targetFishCount = 5;
    private float targetRecheckDelay = 1f;
    private float minSpawnDelay = 1f;
    private float maxSpawnDelay = 3f;

    // Internal references
    private Vector2 zoneSize;
    private Vector2 zoneOffset;

    
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

    // Make one fish spawn for the tutorial
    public void SpawnTutorialFish()
    {
        zoneSize = spawnZone.size;
        zoneOffset = spawnZone.offset;

        // Spawn position at the right of the screen
        Vector2 localPoint = new Vector2( zoneSize.x / 2f - 0.5f, zoneSize.y / 2f - 0.5f) + zoneOffset;
        Vector2 spawnPosition = (Vector2) spawnZone.transform.position + localPoint;

        // Spawn tutorial fish
        SpawnFish(spawnPosition: spawnPosition, fishSO: GameManager.Instance.FishRegistry.carpSO, useLifeTime: false, useFadeIn: true);
    }

    // Regular fish spawner
    public void StartFishSpawner()
    {
        zoneSize = spawnZone.size;
        zoneOffset = spawnZone.offset;

        // Initial fishes
        SpawnInitialFishes();

        // Further spawns
        StartCoroutine(FishSpawnerLoop());
    }

    private void SpawnInitialFishes()
    {
        while (fishContainer.childCount < targetFishCount)
        {
            SpawnFish(spawnPosition: selectRandomSpawnPosition(), fishSO: selectRandomFish(), useLifeTime: true, useFadeIn: false);
        }
    }

    private IEnumerator FishSpawnerLoop()
    {
        while (true)
        {
            int currentFishCount = fishContainer.childCount;

            // Add fish if we don't have enough to reach the targetFishCount
            if (currentFishCount < targetFishCount)
            {
                SpawnFish(spawnPosition: selectRandomSpawnPosition(), fishSO: selectRandomFish(), useLifeTime: true, useFadeIn: true);

                // Random spawn delay
                float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                // Wait till less fish
                yield return new WaitForSeconds(targetRecheckDelay);

                // New target fish count
                targetFishCount = Random.Range(minFish, maxFish + 1);
            }
        }
    }

    private void SpawnFish(Vector2 spawnPosition, FishSO fishSO, bool useLifeTime, bool useFadeIn)
    {
        GameObject newFishObj = Instantiate(fishPrefab, spawnPosition, Quaternion.identity, fishContainer);
        Fish newFish = newFishObj.GetComponent<Fish>();
        newFish.fishSO = fishSO;
        newFish.StartFish(useLifeTime: useLifeTime, useFadeIn: useFadeIn);
    }

    // Select random and valid spawn position (in the spawn zone and fish not too close from each other)
    private Vector2 selectRandomSpawnPosition()
    {
        Vector2 spawnPosition;
        bool validPosition = false;

        do
        {
            float randomX = Random.Range(-zoneSize.x / 2f, zoneSize.x / 2f);
            float randomY = Random.Range(-zoneSize.y / 2f, zoneSize.y / 2f);

            Vector2 localPoint = new Vector2(randomX, randomY) + zoneOffset;
            spawnPosition = (Vector2) spawnZone.transform.position + localPoint;

            validPosition = true;

            // Check the distance with all fish already spawned
            foreach (Transform fish in fishContainer)
            {
                if (Vector2.Distance(fish.position, spawnPosition) < minDistBetweenFish)
                {
                    validPosition = false;
                    break;
                }
            }
        } while (!validPosition);

        return spawnPosition;
    }

    // Select a valid fish type to be spawned + depending of the spawn chance
    private FishSO selectRandomFish()
    {
        // Filter valid types fish depending of the map and time of the day
        FishSO[] validFishes = GameManager.Instance.FishRegistry.AllFish
            .Where(f => (f.spawnMaps.Contains(GameManager.Instance.CurrentMap)
                     && f.spawnTimes.Contains(GameManager.Instance.CurrentTimeOfDay)))
            .ToArray();

        // Random weighted choice
        int totalWeight = validFishes.Sum(f => f.spawnChance);
        int rand = Random.Range(0, totalWeight);
        FishSO selectedType = null;

        foreach (var fish in validFishes)
        {
            if (rand < fish.spawnChance)
            {
                selectedType = fish;
                break;
            }
            rand -= fish.spawnChance;
        }

        return selectedType;
    }
}
