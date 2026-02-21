using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private int enemyCount;
    private int waveNumber = 1;
    private bool gameActive = true;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive) return;

        enemyCount = Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;        
        
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
        float spawnRange = 9.0f;
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 1.5f, spawnPosZ);
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
