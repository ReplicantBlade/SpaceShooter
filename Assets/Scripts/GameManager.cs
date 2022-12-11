using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public enum StateType
    {
        Wave,
        Win,
        Lose
    };

    [HideInInspector] public enum Difficulty
    {
        easy,
        medium,
        hard
    }

    public int WaveCount;

    public int maxBulletToSpawn;
    public int maxHealthPointsToSpawn;
    public int maxFuelToSpawn;

    public GameObject player;

    public List<Transform> spawnLocations = new();
    public List<GameObject> Asteroids = new();
    public List<GameObject> Bullets = new();
    public List<GameObject> HealthPoints = new();
    public List<GameObject> Fuel = new();

    private List<string> allSpaceTypes = new List<string>();

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        var state = new StateType();

        switch (state)
        {
            case StateType.Wave:
                SpawnSpaceObjects();
                break;
            case StateType.Win:
                break;
            case StateType.Lose:
                break;
            default:
                break;
        }
    }

    float cooldown = 0.8f;
    float cooldownTimestamp;
    private void SpawnSpaceObjects()
    {
        if (Time.time < cooldownTimestamp) return;

        Transform spawnLocation = GetRandomSpawnLocation();
        GameObject spaceObject = GetSpaceObjectToSpawn();
        var spaceObjectInstance = Instantiate(spaceObject, spawnLocation.transform);

        spaceObjectInstance.GetComponent<Rigidbody2D>().velocity = spawnLocation.transform.up * Random.Range(5f, 30f);
        Destroy(spaceObjectInstance, 5);

        cooldownTimestamp = Time.time + cooldown;
        cooldown = Random.Range(0.8f, 3f);
    }

    private Transform GetRandomSpawnLocation()
    {
        return spawnLocations[Random.Range(0, spawnLocations.Count)];
    }

    private GameObject GetSpaceObjectToSpawn()
    {
        List<GameObject> choosenList = null;
        allSpaceTypes.Add("Asteroids");
        allSpaceTypes.Add("Bullets");
        allSpaceTypes.Add("HealthPoints");
        allSpaceTypes.Add("Fuel");

        while (choosenList == null)
        {
            int index = Random.Range(0, allSpaceTypes.Count);
            switch (allSpaceTypes[index])
            {
                case "Asteroids":
                    choosenList = Asteroids;
                    break;

                case "Bullets":
                    choosenList = Bullets;
                    maxBulletToSpawn--;
                    if (maxBulletToSpawn <= 0) allSpaceTypes.RemoveAt(index);
                    break;

                case "HealthPoints":
                    choosenList = HealthPoints;
                    maxHealthPointsToSpawn--;
                    if (maxHealthPointsToSpawn <= 0) allSpaceTypes.RemoveAt(index);
                    break;

                case "Fuel":
                    choosenList = Fuel;
                    maxFuelToSpawn--;
                    if (maxFuelToSpawn <= 0) allSpaceTypes.RemoveAt(index);
                    break;

                default:
                    choosenList = null;
                    break;
            }
        }

        return choosenList[Random.Range(0, choosenList.Count)];
    }
}
