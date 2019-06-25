using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundOnTap : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Mode;
    public AudioSource ModeSelected;
    
    public int nextScreenIndex;
    public static int Classic;
    public static int Tap;
    void Start()
    {
        Classic = 0 ;
        Tap = 0;
    }

    public void OnclickbuttonClassic()
    {
        Classic++;
        Tap = 0;
        if (Classic == 1)
        {
            Mode.Play();
        }
        else if(Classic == 2 )
        {
           
            ModeSelected.Play();
            Invoke("Myfunc", 1.6f);
           
           // Classic = 0;
        }
    }
    public void OnClickButtonTap()
    {
        Tap++;
        Classic = 0;
        if(Tap == 1)
        {
            Mode.Play();
        }
        else if(Tap == 2)
        {
            ModeSelected.Play();
            Invoke("Myfunc", 1.6f);
            //Tap = 0;
        }
    }



    void Myfunc()
    {
        SceneManager.LoadScene(nextScreenIndex);
    }
    
}
