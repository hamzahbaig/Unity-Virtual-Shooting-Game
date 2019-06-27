using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;


public class level2 : MonoBehaviour
{
    private AudioSource currentAudio;
    private SpriteRenderer currentSprite;
    private Transform currentObject;
    private bool firstTurn = true;
    private int index;
    public int enemies;
    private int[] turns = { 1, 0, 2, 1, 2, 0 };
    private int currentTurn;
    public static float bulletDistance = 0.0f;
    public GameObject Gun;
    private Transform EnemyIntialPosition;
    private bool GameFinished;
    private AudioSource beepSource;
    public Stopwatch timer;
    public static int score;
    public  AudioSource threeStars;
    public  AudioSource twoStars;
    public  AudioSource oneStar;
    private bool checkScore;
    

    void Start()
    {
        InitalisingValues();
    }

    void Update()
    {
        if(!GameFinished)
        {
            // check whats the progress of the user!!
            if(Progress.levelFinished == 2)
            {
                // Play Level2
                level2Initate();
            }
            else if(Progress.levelFinished == 1)
            {
                // Play Level1
                level1Initate();
            }
        }
        else if(checkScore)
        {
            timer.Stop();
            score = timer.Elapsed.Seconds;
            computeScore();
            checkScore = false;
        }


    }

    public void InitalisingValues()
    {
        timer = new Stopwatch();
        timer.Start();
        firstTurn = true;
        currentTurn = 0;
        GameFinished = false;
        checkScore = false;
    }

    public void level1Initate()
    {
       if (firstTurn)
        {
            turnByTurnAudio(turns[currentTurn]);
        }
        else if (currentAudio.enabled == false)
        {
            if (currentTurn == turns.Length)
            {
                GameFinished = true;
                checkScore = true;
            }
            else
            {
                turnByTurnAudio(turns[currentTurn]);

            }
        }
    }

    public void level2Initate()
    {
        ///print(timer.Elapsed.Seconds);
        // when its first turn  
        if (firstTurn)
        {

            turnByTurnAudio(turns[currentTurn]);
        }
        // when audio is not playing 
        //1) game is GameFinished 
        //  or 
        //2) generate another enemy
        else if (currentAudio.enabled == false)
        {
            if (currentTurn == turns.Length)
            {
                GameFinished = true;
                checkScore = true;
            }
            else
            {
                turnByTurnAudio(turns[currentTurn]);

            }
        }
        // audio is playing 
        else if (currentAudio.enabled == true)
        {

            if (index == 0)
            {
                //beepSource.volume += 0.1f;
                currentAudio.volume += 0.1f;
                float step = 0.5f * Time.deltaTime; // calculate distance to move
                currentObject.position = Vector3.MoveTowards(currentObject.position, Gun.transform.position, step);
            }
        }
    }
    public  void computeScore()
    {
        
        if (score <= 15)
        {
            threeStars.Play();
            Progress.levelFinished++;
            InitalisingValues();
        }
        else if (score <= 20)
        {
            twoStars.Play();
            Progress.levelFinished++;
            InitalisingValues();
        }
        else if (score <= 25)
        {
            oneStar.Play();
            Progress.levelFinished++;
            InitalisingValues();
        }
        else if (score > 25)
        {
            // level failed audio and restart

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void turnByTurnAudio(int cond)
    {
      
          
        currentTurn++;
        index = cond;
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
