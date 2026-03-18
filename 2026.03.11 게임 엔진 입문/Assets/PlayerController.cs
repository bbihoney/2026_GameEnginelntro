using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
        private Vector2 movelnput;
    public float moveSpeed = 7f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private Animator myAnimator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("move", false);
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed) // 점프버튼 누르면
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    public void OnMove(InputValue value)
      {
          movelnput = value.Get<Vector2>();
      }
        // Update is called once per frame
        void Update()
    {
        if(movelnput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if(movelnput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }

        if(movelnput.magnitude > 0)
        {
            myAnimator.SetBool("move", true);
        }
        else
        {
            myAnimator.SetBool("move", false);
        }
        transform.Translate(Vector3.right * moveSpeed * movelnput.x * Time.deltaTime);
    }

    
}
