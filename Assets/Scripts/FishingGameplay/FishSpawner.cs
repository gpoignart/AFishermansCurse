using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fishPrefab;

    [SerializeField]
    private BoxCollider2D spawnArea;

    [SerializeField]
    private Transform fishContainer;

    private int minFish = 3;
    private int maxFish = 7;
    private float checkInterval = 5f;

    private Vector2 zoneSize;
    private Vector2 zoneOffset;

    private int targetFishCount;

    private void Start()
    {
        zoneSize = spawnArea.size;
        zoneOffset = spawnArea.offset;

        // Initialize the target fish count to 5
        targetFishCount = 5;

        InvokeRepeating(nameof(ManageFishCount), 0f, checkInterval);
    }

    private void ManageFishCount()
    {
        int currentFishCount = fishContainer.childCount;

        // Add fish if we don't have enough to reach the targetFishCount
        if (currentFishCount < targetFishCount)
        {
            int fishToSpawn = targetFishCount - currentFishCount;
            for (int i = 0; i < fishToSpawn; i++)
                SpawnFish();
        }

        // Change randomly the targetFishCount
        targetFishCount = Random.Range(minFish, maxFish + 1);
    }

    private void SpawnFish()
    {
        Vector2 spawnPosition;
        float minDistBetweenFish = 2f;
        bool validPosition = false;

        // Make fish to be at distance from each others
        do
        {
            float randomX = Random.Range(-zoneSize.x / 2f, zoneSize.x / 2f);
            float randomY = Random.Range(-zoneSize.y / 2f, zoneSize.y / 2f);

            Vector2 localPoint = new Vector2(randomX, randomY) + zoneOffset;
            spawnPosition = (Vector2) spawnArea.transform.position + localPoint;

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

        Instantiate(fishPrefab, spawnPosition, Quaternion.identity, fishContainer);
    }
}