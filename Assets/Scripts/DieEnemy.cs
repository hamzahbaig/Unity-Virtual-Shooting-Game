using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour {

    public int health;
    public AudioSource enemyKilled;
    private Vector3 Position;
    public void Start()
    {
        Position = this.transform.position; 
        this.gameObject.SetActive(false);

    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        AudioSource currentAudio = this.gameObject.GetComponent<AudioSource>();
        currentAudio.enabled = false;
        SpriteRenderer currentObject = this.gameObject.GetComponent<SpriteRenderer>();
        currentObject.color = Color.white;
        enemyKilled.enabled = true;
        enemyKilled.Play();
        health=1;
        this.transform.position = Position;
        this.gameObject.SetActive(false);


    }

    
}
