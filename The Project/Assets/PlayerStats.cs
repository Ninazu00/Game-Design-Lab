using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hp = 6;
    public int lives = 3;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer sr;
    public bool Immune = false;
    private float immuneT = 0f;
    public float immuneD = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Immune){
            SpriteFlicker();
            immuneT += Time.deltaTime;
            if(immuneT >= immuneD){
                Immune = false;
                sr.enabled = true;
            }
        }
    }

    public void TakeDamage(int dmg){
        if(Immune){
            return;
        }
        hp = hp - dmg;
        Debug.Log("Player HP: " + hp.ToString());
        if(hp < 0)
            hp = 0;
        if (lives>0 && hp == 0){
            FindObjectOfType<LevelManager>().RespawnPlayer();
            hp = 6;
            lives--;
        }
        else if (lives == 0 && hp == 0){
            Debug.Log("GameOver");
            Destroy(this.gameObject);
            Debug.Log("Player HP: " + hp.ToString());
            Debug.Log("Player Lives: " + lives.ToString());
        }
        immuneT = 0f;
        Immune = true;
    }

    void SpriteFlicker(){
        if(flickerTime <flickerDuration)
        {
            flickerTime += Time.deltaTime;
        }
        else if (flickerTime>= flickerDuration)
        {
            sr.enabled = !(sr.enabled);
            flickerTime = 0f;
        }
    }
    
}
