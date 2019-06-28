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
        if (Progress.levelFinished == 1)
        {
            Level1Dying();
        }
        else if (Progress.levelFinished == 2)
        {

            Level2Dying();
        }
        SpriteRenderer currentObject = this.gameObject.GetComponent<SpriteRenderer>();
        currentObject.color = Color.white;
        enemyKilled.enabled = true;
        enemyKilled.Play();
        health = 1;
        this.transform.position = Position;
        this.gameObject.SetActive(false);
        //Invoke("setFalse", 1.0f);

    }



    void setFalse()
    {
        this.gameObject.SetActive(false);
    }

    void Level1Dying()
    {
        AudioSource[] sounds = this.GetComponents<AudioSource>();
        foreach (AudioSource s in sounds)
        {
            if (s.clip.name == "final_steps")
            {
                s.enabled = false;
                break;
            }
        }
    }

    void Level2Dying()
    {
        if (this.gameObject.name == "Enemy1")
        {

            AudioSource[] sounds = this.GetComponents<AudioSource>();
            foreach (AudioSource s in sounds)
            {
                if (s.clip.name == "Cut_beep")
                {
                    s.enabled = false;
                }
            }
        }
        else
        {

           AudioSource currentAudio = this.GetComponent<AudioSource>();
            currentAudio.enabled = false;
        }
    }
    
}
