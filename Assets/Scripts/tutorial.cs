using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tutorial : MonoBehaviour
{
    private GameObject sound;
    private bool flag = false;

    void Start()
    {
        //Progress.timesPlayed++;
        
        // LEVEL1 TUTORIAL
        if(Progress.levelFinished == 1)
        {
            Progress.timesPlayed_1++;
            if (Progress.timesPlayed_1 < 2)
            {
                Invoke("sound1", 9.50f);
                Invoke("sound2", 19.0f);
                Invoke("sound3", 28.0f);
                if (SoundOnTap.Classic == 2)
                {
                    Invoke("sound4", 37.0f);
                    Invoke("NextScreen", 55.0f);
                }
                if (SoundOnTap.Tap == 2)
                {
                    Invoke("sound5", 37.0f);
                    Invoke("NextScreen", 45.0f);
                }
            }
            else
            {
                flag = true;
            }
        }
        // LEVEL2 TUTORIAL
        else if(Progress.levelFinished == 2)
        {
            Progress.timesPlayed_2++;
            if (Progress.timesPlayed_2 < 2)
            {
                Invoke("movingEnemy", 9.50f);
                Invoke("NextScreen", 30.0f);    
            }
            else
            {
                flag = true;
            }
        }
          
    }
    void sound1()
    {
        sound = this.gameObject.transform.GetChild(0).gameObject;
        sound.SetActive(true);
        
    }
    void sound2()
    {
        sound = this.gameObject.transform.GetChild(1).gameObject;
        sound.SetActive(true);
    }
    void sound3()
    {
        sound = this.gameObject.transform.GetChild(2).gameObject;
        sound.SetActive(true);
    }

    void sound4()
    {

        sound = this.gameObject.transform.GetChild(3).gameObject;
        sound.SetActive(true);

    }
    void sound5()
    { 
            sound = this.gameObject.transform.GetChild(4).gameObject;
            sound.SetActive(true);
    }
    void movingEnemy()
    {
        sound = this.gameObject.transform.GetChild(6).gameObject;
     
        sound.SetActive(true);
    }
    void NextScreen()
    {
        sound = this.gameObject.transform.GetChild(5).gameObject;
        sound.SetActive(true);
        flag = true;
        
    }
    private void Update()
    {
        if(Progress.levelFinished ==2)
        {
            float step = 0.5f * Time.deltaTime; // calculate distance to move
            sound.transform.position = Vector3.MoveTowards(sound.transform.position, new Vector3(0.0f, 0.1900001f, 0.0f), step);
        }
        if(Input.touchCount == 1)
        {
            flag = true;
        }
        if(flag)
        {
            
            if (Input.touchCount == 1)
            {
                for(int i=0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    SceneManager.LoadScene(1);
                    if(SoundOnTap.Tap == 2)
                    {
                       // print("tap");
                        SceneManager.LoadScene(2);
                    }
                    if(SoundOnTap.Classic == 2)
                    {
                        //print("Classic");
                        SceneManager.LoadScene(1);
                    }
                    
                }
            }
        }
       
    }
}
