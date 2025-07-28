using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class coin : MonoBehaviour
{
    [Header("Настройки движения")]
    [SerializeField][Range(1f, 10f)] private float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        // Ввод с клавиатуры
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        // Применение движения
        rb.velocity = movement * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка столкновения с врагом
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        // Перезагрузка текущей сцены
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}