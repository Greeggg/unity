using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyManager : MonoBehaviour
{
    public TMP_Dropdown difficultyDropdown; 
    public BlockSpawner blockSpawner;   

    void Start()
    {

        difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);

    }
    void OnDifficultyChanged(int index)
    {
        if (index == 0) 
        {
            blockSpawner.numberOfBlocks = 20;  
        }
        else if (index == 1) 
        {
            blockSpawner.numberOfBlocks = 50; 
        }
        else if (index == 2) 
        {
            blockSpawner.numberOfBlocks = 100; 
        }


        blockSpawner.SpawnBlocksInLine();
    }
}
