using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;
    private int enemyCount;
    private int waveNumber = 1;
    private bool gameActive = true;
    private float spawnRange = 9.0f;

    void Start()
    {

        SpawnPowerup();
        SpawnEnemyWave(waveNumber);        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive) return;
        
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;        
        
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }
      void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0.3f, spawnPosZ);
    }

    void StopSpawning()
    {
        gameActive = false;
    }

    void OnEnable()
    {
        GameManager.OnGameOver += StopSpawning;
    }

    void OnDisable()
    {
        GameManager.OnGameOver -= StopSpawning;
    }

}
