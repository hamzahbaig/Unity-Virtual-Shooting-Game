using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructionsound : MonoBehaviour
{
    public AudioSource Instructions;
    public AudioSource Title;
    public GameObject  Gun;
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        Instructions.Play();
        Title.PlayDelayed(10.0f);
        Invoke("makeActive", 13.0f);
    }
    void makeActive()
    {
        if (flag)
        {
            Gun.SetActive(true);
            Destroy(this.gameObject);
            flag = false;
        }
        
    }

    void Update()
    {
        if(Input.touchCount ==1)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                this.gameObject.GetComponent<AudioSource>().Pause();
                Instructions.Pause();
                makeActive();
                flag = false;
            }
        }
    }
}
