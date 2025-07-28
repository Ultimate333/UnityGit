using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    [SerializeField] private GameObject objectToSpawn; // ������ ��� ������
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(5f, 5f); // ���� ������

    void Start()
    {
        // ����� ��� ������
        SpawnObject();
    }

    public void SpawnObject()
    {
        // ���������� ��������� ������� � ����
        Vector2 randomPosition = (Vector2)transform.position +
            new Vector2(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
            );

        // �������� �������
        GameObject newObj = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

        // ������������ ����� 5 ������
        Destroy(newObj, 5f);
    }
}
