/*
/* Sourcefile:      scr_TargetSpawner.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Spawns targets at random positions
 */
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
    

    /// <summary>
    /// Spawn a number of targets, based on targetsToSpawn, at random spawn locations. 
    /// </summary>
    void SpawnTargets()
    {
        /// Populate the list of target locations.
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            targetSpawnLocations.Add(gameObject.transform.GetChild(i));
        }

        /// Spawn targets at random positions, ensuring not to spawn overlapping duplicates. 
        for (int i = 0; i < targetsToSpawn; i++)
        {
            int randomIndex = Random.Range(0, targetSpawnLocations.Count);
            Instantiate(targetPrefab, targetSpawnLocations[randomIndex].position, Quaternion.identity);
            targetSpawnLocations.RemoveAt(randomIndex);
        }

    }
}
