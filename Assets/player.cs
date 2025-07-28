using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    [SerializeField] private GameObject objectToSpawn; // Префаб для спавна
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(5f, 5f); // Зона спавна

    void Start()
    {
        // Спавн при старте
        SpawnObject();
    }

    public void SpawnObject()
    {
        // Вычисление случайной позиции в зоне
        Vector2 randomPosition = (Vector2)transform.position +
            new Vector2(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
            );

        // Создание объекта
        GameObject newObj = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

        // Автоудаление через 5 секунд
        Destroy(newObj, 5f);
    }
}
