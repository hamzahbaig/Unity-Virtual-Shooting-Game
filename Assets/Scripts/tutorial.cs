using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject sound;
    public AudioSource beepsound;
    //public int nextScreenIndex;
    private bool flag = false;
    void Start()
    {
        Progress.levelFinished = 2;
        if (Progress.levelFinished == 1)
        {
            Introduction.timesPlayed++;
            if (Introduction.timesPlayed < 2)
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
    void NextScreen()
    {
        sound = this.gameObject.transform.GetChild(5).gameObject;
        sound.SetActive(true);
        flag = true;
        
    }
    private void Update()
    {
        if(Progress.levelFinished == 2)
        {
            float step = 0.5f * Time.deltaTime;
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
                    if(SoundOnTap.Tap == 2)
                    {
                       // print("tap");
                        SceneManager.LoadScene(2);
                    }
                    if(SoundOnTap.Classic == 2)
                    {
                        //print("Classic");
                        SceneManager.LoadScene(3);
                    }
                    
                }
            }
        }
       
    }
}
