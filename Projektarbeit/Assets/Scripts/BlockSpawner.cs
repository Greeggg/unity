using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;         
    public Transform arrow;                
    public Transform dartboard;            
    public float blockSize = 1.0f;         
    public int numberOfBlocks = 10;        
    public float spawnOffsetRange = 20.0f; 

    private List<GameObject> spawnedBlocks = new List<GameObject>();

    void Start()
    {
        SpawnBlocks();
    }

    public void SpawnBlocks()

    {
        foreach (var block in spawnedBlocks)
        {
            Destroy(block);
        }
        spawnedBlocks.Clear(); 

        int spawnedCount = 0;
        int maxAttempts = numberOfBlocks * 10;
        int attempts = 0;

        while (spawnedCount < numberOfBlocks && attempts < maxAttempts)
        {
            Vector3 basePosition = GenerateRandomPositionBetweenArrowAndDartboard();
            Vector3 offset = new Vector3(
                Random.Range(-spawnOffsetRange, spawnOffsetRange), 
                Random.Range(-spawnOffsetRange, spawnOffsetRange),
                0 
            );

            Vector3 randomPosition = basePosition + offset;

            if (IsPositionFree(randomPosition))
            {
                GameObject newBlock = Instantiate(blockPrefab, randomPosition, Quaternion.identity);
                spawnedBlocks.Add(newBlock);
                spawnedCount++;
            }

            attempts++;
        }
    }

    Vector3 GenerateRandomPositionBetweenArrowAndDartboard()
    {
        float t = Random.Range(0f, 1f);
        Vector3 position = Vector3.Lerp(arrow.position, dartboard.position, t);
        return position;
    }

    bool IsPositionFree(Vector3 position)
    {
        foreach (GameObject block in spawnedBlocks)
        {
            if (Vector3.Distance(position, block.transform.position) < blockSize)
            {
                return false;
            }
        }
        return true;
    }
}
