using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPowerUps;
    [SerializeField] private Transform[] spawnLocations;

    private void Start()
    {
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            Instantiate(spawnPowerUps[Random.Range(0, spawnPowerUps.Length)], spawnLocations[i]);   
        }
    }
}
