using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tutorial : MonoBehaviour
{
    private GameObject sound;
<<<<<<< HEAD
=======
    public AudioSource beepsound;
    //public int nextScreenIndex;
>>>>>>> 56fad7a7f607ab190139c1d19fa2b832ac905450
    private bool flag = false;

    void Start()
    {
<<<<<<< HEAD
        //Progress.timesPlayed++;
        
        // LEVEL1 TUTORIAL
        if(Progress.levelFinished == 1)
        {
            Progress.timesPlayed_1++;
            if (Progress.timesPlayed_1 < 2)
=======
        Progress.levelFinished = 2;
        if (Progress.levelFinished == 1)
        {
            Introduction.timesPlayed++;
            if (Introduction.timesPlayed < 2)
>>>>>>> 56fad7a7f607ab190139c1d19fa2b832ac905450
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
<<<<<<< HEAD
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
          
=======
        if (Progress.levelFinished == 2)
        {
            this.gameObject.GetComponent<AudioSource>().enabled = false; 
            sound = this.gameObject.transform.GetChild(2).gameObject;
            sound.SetActive(true);
            AudioSource[] sounds = sound.gameObject.GetComponents<AudioSource>();
            foreach(AudioSource s in sounds)
            {
                s.enabled = false;
            }
           
            beepsound.Play();
            


        }
        
        
        
      
        
>>>>>>> 56fad7a7f607ab190139c1d19fa2b832ac905450
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
<<<<<<< HEAD
        if(Progress.levelFinished ==2)
        {
            float step = 0.5f * Time.deltaTime; // calculate distance to move
            sound.transform.position = Vector3.MoveTowards(sound.transform.position, new Vector3(0.0f, 0.1900001f, 0.0f), step);
        }
=======
        if(Progress.levelFinished == 2)
        {
            float step = 0.5f * Time.deltaTime;
            sound.transform.position = Vector3.MoveTowards(sound.transform.position, new Vector3(0.0f, 0.1900001f, 0.0f), step);
        }

>>>>>>> 56fad7a7f607ab190139c1d19fa2b832ac905450
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
