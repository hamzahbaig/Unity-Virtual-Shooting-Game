using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour
{
    private AudioSource currentAudio;
    private SpriteRenderer currentSprite;
    private Transform currentObject;
    private bool firstTurn = true;
    private int index;
    public int enemies;
    private int[] turns = { 1, 0, 2, 1, 2, 0 };
    private int currentTurn = 0;
    public static float bulletDistance = 0.0f;
    

    void Update()
    {
        if(currentTurn == turns.Length)
        {
        }
        else if (firstTurn)
        {
            turnByTurnAudio(turns[currentTurn]);
        }
        else if (currentAudio.enabled == false)
        {
            turnByTurnAudio(turns[currentTurn]);
        }

    }

    private void turnByTurnAudio(int cond)
    {
        currentTurn++;
        firstTurn = false;
        currentObject = this.gameObject.transform.GetChild(cond);
        currentObject.gameObject.SetActive(true);
        currentSprite = currentObject.GetComponent<SpriteRenderer>();
        currentSprite.color = Color.red;
        currentAudio = currentObject.GetComponent<AudioSource>();
        currentAudio.enabled = true;
        currentAudio.Play();
    }

    private void randomAudio(int cond)
    {
        firstTurn = false;
        //randomGenerator(cond);
        currentObject = this.gameObject.transform.GetChild(index);
        //postitionchange();
        currentObject.gameObject.SetActive(true);
        currentSprite = currentObject.GetComponent<SpriteRenderer>();
        currentSprite.color = Color.red;
        currentAudio = currentObject.GetComponent<AudioSource>();
        currentAudio.enabled = true;
        currentAudio.Play();
    }
    private void postitionchange()
    {
        if (index == 0)
        {
            currentObject.transform.position = new Vector3(Random.Range(-2.0f, 2.1f), 4.21f, 0);
        }
        if (index == 1)
        {
            currentObject.transform.position = new Vector3(-2.5f, Random.Range(1.38f, 2.35f), 0);
        }
        if (index == 2)
        {
            currentObject.transform.position = new Vector3(2.5f, Random.Range(1.38f, 2.35f), 0);
        }
        if (index == 3)
        {
            currentObject.transform.position = new Vector3(Random.Range(-2.0f, 2.1f), -2.5f, 0);
        }

    }
    private void randomGenerator(int cond)
    {

        if (cond == -1)
        {
            index = Random.Range(0, enemies);
        }
        else if (cond == 0)
        {
            index = Random.Range(0, 3);
        }
        else if (cond == 3)
        {
            index = Random.Range(1, 4);
        }
        else if (cond == 2)
        {
            index = 1;
            while (index == 1)
            {
                index = Random.Range(0, enemies);
            }
        }
        else if (cond == 1)
        {
            index = 2;
            while (index == 2)
            {
                index = Random.Range(0, enemies);
            }
        }

    }
}
