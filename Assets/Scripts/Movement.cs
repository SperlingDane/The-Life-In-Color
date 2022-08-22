using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    public GameObject player;
    

    [SerializeField] private int speed;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float jumpspeed;
    [SerializeField] private float holdjumpspeed;
    private float Timer = 10;
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;



    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("Right", true);
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Moving", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Moving", false);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Moving", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Moving", false);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Timer += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded && Timer >= 1)
        {
            jump(holdjumpspeed);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            jump(jumpspeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            Timer = 0;
            animator.SetBool("IsJumping", false);
        }
        if (other.CompareTag("MovingPlatform"))
        {
            isGrounded = true;
            Timer = 0;
            player.transform.parent = other.gameObject.transform;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            player.transform.parent = null;
        }
    }

    private void jump(float speed)
    {
        rb.AddForce(new Vector2(rb.velocity.x, speed), ForceMode2D.Impulse);
        isGrounded = false;
        animator.SetBool("IsJumping", true);
    }
}