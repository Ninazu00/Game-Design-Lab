using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(L)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>()!=null){
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if(Input.GetKey(R)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (GetComponent<SpriteRenderer>()!=null){
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if(Input.GetKeyUp(spacebar)&& grounded){
            Jump();
        }
    }

    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position, GCRadius, whatIsGround);
    }


    void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
