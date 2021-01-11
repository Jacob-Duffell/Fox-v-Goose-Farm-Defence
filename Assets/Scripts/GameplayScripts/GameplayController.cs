using SerializeStatic_NET;
using TMPro;
using UnityEngine;

/// <summary>
/// Handles logic for the overall gameplay scene of the game.
/// </summary>
public class GameplayController : MonoBehaviour
{
    private float enemySpawnTime;
    private GameObject currentEnemySpawnPoint;
    private GameObject[] enemySpawners;
    private int enemySpawnNum;

    [SerializeField] private float timer;
    [SerializeField] private float enemySpawnDelay;
    [SerializeField] private GameObject enemy;
    [SerializeField] private TMP_Text timerText;

    /// <summary>
    /// Initialises variables for the gameplay.
    /// </summary>
    void Start()
    {
        GameHandler.CurrentWeekKills = 0;
        GameHandler.CurrentWeekNumber++;

        timerText.text = "Time: " + timer.ToString("F");

        enemySpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        enemySpawnTime = enemySpawnDelay;
    }

    /// <summary>
    /// Updates logic for the timer and enemy spawner objects.
    /// </summary>
    void Update()
    {
        // Update timer
        if (timer >= 0.0f)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F");
        }
        else if (timer <= 0.0f)
        {
            timerText.text = "Time: 0.00";
            timer = 0.0f;

            GameHandler.CurrentMoney += GameHandler.CurrentWeekEarnings;
            GameHandler.TotalEarnings += GameHandler.CurrentWeekEarnings;
            GameHandler.TotalKills += GameHandler.CurrentWeekKills;

            GameHandler.CurrentWeekRewardClaimed = false;

            SerializeStatic.Save();

            Loader.Load(Loader.Scene.HubMenuScene);
        }

        // Update enemy spawner
        if (enemySpawnDelay > 0)
        {
            enemySpawnDelay -= Time.deltaTime;
        }
        else if (enemySpawnDelay <= 0)
        {
            enemySpawnNum = Random.Range(0, enemySpawners.Length);
            currentEnemySpawnPoint = enemySpawners[enemySpawnNum];
            Instantiate(enemy, currentEnemySpawnPoint.transform.position, currentEnemySpawnPoint.transform.rotation);
            enemySpawnDelay = enemySpawnTime;
        }
    }
}
