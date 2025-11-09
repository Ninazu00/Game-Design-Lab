using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxSpeed = 2;
    public int dmg = 1;
    // Start is called before the first frame update
    public SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void Flip(){
        sr.flipX = !(sr.flipX);
    }

    void OnTriggerEnter2D(Collider2D other){
        Flip();
        if(other.tag == "Player"){
            FindObjectOfType<PlayerStats>().TakeDamage(dmg);
        }
        else if (other.tag == "Wall"){
            //Flip();
        }
    }
}
