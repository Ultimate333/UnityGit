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

    
}

