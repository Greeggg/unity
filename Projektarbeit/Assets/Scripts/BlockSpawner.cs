using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Das Prefab f�r die zu spawnenden Bl�cke
    public Transform arrow;        // Der Pfeil, von dem aus die Bl�cke gespawnt werden
    public int numberOfBlocks = 100;  // Anzahl der zu spawnenden Bl�cke
    public float lineLength = 500.0f; // Gesamtl�nge der Linie
    public float spawnOffsetRange = 200.0f; // Zuf�llige Abweichung in Einheiten

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

        float spacing = lineLength / (numberOfBlocks - 1); // Abstand zwischen den Bl�cken

        for (int i = 0; i < numberOfBlocks; i++)
        {
            Vector3 position = arrow.position + arrow.forward * (spacing * i);

            // F�ge zuf�llige Abweichungen in der Position hinzu
            position.x += Random.Range(-spawnOffsetRange, spawnOffsetRange);
            position.y += Random.Range(-spawnOffsetRange, spawnOffsetRange);

            GameObject newBlock = Instantiate(blockPrefab, position, Quaternion.identity);
            spawnedBlocks.Add(newBlock);

        }
    }
}
