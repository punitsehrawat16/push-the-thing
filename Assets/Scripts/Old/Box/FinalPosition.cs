using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FinalPosition : MonoBehaviour
{
    bool isAllBoxesPlaced = false;
    [SerializeField] public Transform[] storeFinalPosition; // array to store the positions of the final targets where the boxes need to be placed
    [SerializeField] private GameObject prefabOfTarget; // prefab of the final target to be instantiated so that player can see where to place the boxes
    [SerializeField] int correctBoxplaced = 0;
    [SerializeField] WinManager winManager;
    void Start() // called before the first frame update
    {
        SpawnTargetVisual();
        winManager = FindAnyObjectByType<WinManager>();

    }
    void SpawnTargetVisual() // function to spawn the target visual at the final positions 
    {
        foreach (Transform final in storeFinalPosition) // loop which will spawn the visual prefab through each final position in the array 
        {
            Vector3 spawnPoint = final.position; // get the position of the final target from the array
            Instantiate(prefabOfTarget, spawnPoint, Quaternion.identity); // instantiate the target visual prefab at the position of the final target
        }
    }
    public void BoxPlaced()
    {
        correctBoxplaced += 1;
        if (SoundManager.instance.correctBoxPlacement.isPlaying) CheckAllBoxesPlaced(); 
        
        else SoundManager.instance.PlayCorrectBoxPlacementSound();
        CheckAllBoxesPlaced();
    }
    public void BoxRemoved()
    {
        correctBoxplaced -= 1;
    }
    public void CheckAllBoxesPlaced()
    {
        if (correctBoxplaced == storeFinalPosition.Length)
        {
            //Debug.Log("You Win!");
            SoundManager.instance.PlayLevelCompleteSound();
            winManager.ShowPanel();

        }
        else
        {
            Debug.Log("Boxes Placed: " + correctBoxplaced + "/" + storeFinalPosition.Length);
        }
    }
}

