using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   Rigidbody2D rb2d;
   float move;
   [SerializeField] float speed;
   [SerializeField] float jumpForce;
   [SerializeField] bool isJumping;
    void Start()
    {
      rb2d = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
       move = Input.GetAxis("Horizontal"); 
       rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
       if (Input.GetButtonDown("Jump") && !isJumping)
       {
         rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));  
         Debug.Log("Jump");
       }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
          isJumping = false;  
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
          isJumping = true;  
        }
    }
}
