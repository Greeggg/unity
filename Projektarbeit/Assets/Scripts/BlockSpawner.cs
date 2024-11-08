using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Das Prefab für die zu spawnenden Blöcke
    public Transform arrow;        // Der Pfeil, von dem aus die Blöcke gespawnt werden
    public int numberOfBlocks = 100;  // Anzahl der zu spawnenden Blöcke
    public float lineLength = 500.0f; // Gesamtlänge der Linie
    public float spawnOffsetRange = 200.0f; // Zufällige Abweichung in Einheiten

    private List<GameObject> spawnedBlocks = new List<GameObject>();

    void Start()
    {
        SpawnBlocksInLine();
    }

    public void SpawnBlocksInLine()
    {
        foreach (var block in spawnedBlocks)
        {
            Destroy(block);
        }
        spawnedBlocks.Clear(); 

        float spacing = lineLength / (numberOfBlocks - 1); // Abstand zwischen den Blöcken

        for (int i = 0; i < numberOfBlocks; i++)
        {
            Vector3 position = arrow.position + arrow.forward * (spacing * i);

            // Füge zufällige Abweichungen in der Position hinzu
            position.x += Random.Range(-spawnOffsetRange, spawnOffsetRange);
            position.y += Random.Range(-spawnOffsetRange, spawnOffsetRange);

            GameObject newBlock = Instantiate(blockPrefab, position, Quaternion.identity);
            spawnedBlocks.Add(newBlock);

        }
    }
}
