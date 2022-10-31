using Assets.Scripts.CharacterBuilder;
using Assets.Scripts.CharacterBuilder.Builder;
using Assets.Scripts.CharacterBuilder.Enemy;
using Assets.Scripts.CharacterBuilder.Player;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Dictionary<string, GameObject> enemyPrefabs;
    public GameObject powerUpPrefab;

    static readonly float positionRange = 9f;
    int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        Spawnplayer();
        SpawnPowerUp();
        SpawnEnemyWave(waveNumber);
    }

    private void Spawnplayer()
    {
        Director.Builder<Player1Builder>()
            .SetPosition(GenerateSpawnPosition())
            .SetVelocity(7f)
            .Build();
    }

    private void SpawnPowerUp()
    {
        var pw = GameObject.FindGameObjectWithTag("powerup");
        if (pw == null)
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    private void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;

        if (enemyCount < 1)
        {
            SpawnPowerUp();
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            IBuilder builder;

            if(enemiesToSpawn != 0 && enemiesToSpawn 3 == 0 && i % 3 == 0)
                builder = Director.Builder<Enemy2Builder>()
                .SetVelocity(6f);
            else
                builder = Director.Builder<Enemy1Builder>()
                .SetVelocity(8f);

            builder.SetPosition(GenerateSpawnPosition())
                .Build();
        }
    }

    private static Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-positionRange, positionRange);
        float spawnPosZ = Random.Range(-positionRange, positionRange);

        return new(spawnPosX, 0, spawnPosZ); ;
    }
}
