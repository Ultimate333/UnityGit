using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{


    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector2 spawnArea = new Vector2(5, 5);
    [SerializeField] private float spawnRate = 1f;

    private Transform player1;

    void Start()
    {
        player1 = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = (Vector2)transform.position +
                          new Vector2(Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                                      Random.Range(-spawnArea.y / 2, spawnArea.y / 2));

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemy.AddComponent<EnemyController>().Initialize(player1);
        Destroy(enemy, 5f);
    }
}

public class EnemyController : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed = 3f;

    public void Initialize(Transform target) => this.target = target;

    void FixedUpdate()
    {
        if (target)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}