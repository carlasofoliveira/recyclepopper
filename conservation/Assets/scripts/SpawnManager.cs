using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // this makes a singleton to be accessed by other scripts
    public static SpawnManager Instance;
    
    [SerializeField] private bool canSpawn;
    [SerializeField] private GameObject[] entitiesPrefabs;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float entitiesSpeed = 50;
    [SerializeField] private float xMargin = 2;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnTimerMax = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        TrySpawn();
    }

    private void TrySpawn()
    {
        if (!canSpawn)
        {
            return;
        }

        if ( spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnTimerMax;
            // spawn here
            SpawnEntity();
        }
    }

    public void StartScript()
    {
        canSpawn = true;
        spawnTimer = spawnTimerMax;
    }

    private void SpawnEntity()
    {
        GameObject entityToSpawn = entitiesPrefabs[Random.Range(0, entitiesPrefabs.Length)];
        spawnPosition.x = Random.Range(-xMargin, xMargin);

        GameObject spawnedEntity;

        if ((entityToSpawn.GetComponent<EntityType>().entityType == EntityType.EntityTypes.factory) && (PlayerMoney.Instance.ReturnCurrentpaper() > 10))
        {
            spawnedEntity = Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
            spawnedEntity.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -entitiesSpeed);
            return;
        }

        if (entityToSpawn.GetComponent<EntityType>().entityType != EntityType.EntityTypes.factory)
        {
            spawnedEntity = Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
            spawnedEntity.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -entitiesSpeed);
        }
    }
}
