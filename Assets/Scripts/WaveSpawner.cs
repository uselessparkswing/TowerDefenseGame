using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TMP_Text waveCountdownText;

    private int waveNumber = 0;

    public GameManager gameManager;

    void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = "Wave: " + waveNumber.ToString();
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveNumber];

        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveNumber++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
