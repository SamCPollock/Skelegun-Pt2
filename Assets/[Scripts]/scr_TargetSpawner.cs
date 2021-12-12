using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TargetSpawner : MonoBehaviour
{

    private List<Transform> targetSpawnLocations = new List<Transform>();
    public GameObject targetPrefab;
    public int targetsToSpawn;

    void Start()
    {
        SpawnTargets();
    }
    

    void SpawnTargets()
    {

        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            targetSpawnLocations.Add(gameObject.transform.GetChild(i));
        }

        for (int i = 0; i < targetsToSpawn; i++)
        {
            int randomIndex = Random.Range(0, targetSpawnLocations.Count);
            Instantiate(targetPrefab, targetSpawnLocations[randomIndex].position, Quaternion.identity);
            targetSpawnLocations.RemoveAt(randomIndex);
        }

        //foreach (Transform spawnLocation in targetSpawnLocations)
        //{
        //    int random = Random.Range(0, 2);
        //    Debug.Log("RANDOM ROLL = " + random);
        //    if (random > 0 )
        //    {
        //        Instantiate(targetPrefab, spawnLocation);
        //    }
        //}
    }
}
