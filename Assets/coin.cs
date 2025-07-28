using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class coin : MonoBehaviour
{
    [Header("движение игрока")]
    [SerializeField][Range(1f,10f)] private float speed = 5f;
    private Rigidbody2D rb;
    
    void Start() => rb = GetComponent<Rigidbody2D>();

   
    
    private void FixedUpdate()
    {
      float h =  Input.GetAxisRaw("Horizontal");
     
        rb.linearVelocity = new Vector2(h * speed, rb.linearVelocity.y);
        
    }

}

