using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   Rigidbody2D rb2d;
   Vector2 moveinput;
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
      moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      rb2d.AddForce(moveinput * speed );
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
