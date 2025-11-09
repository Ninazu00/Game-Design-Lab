using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.flipX == true){
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed,this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else{
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed,this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
