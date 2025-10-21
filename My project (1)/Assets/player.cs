using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float GCRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (Input.GetKeyUp(spacebar) && grounded)
        {
            Jump();
        }
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetFloat("VSpeed", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("Grounded", grounded);
    }
    
    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position, GCRadius, whatIsGround);
    }
    
    void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
