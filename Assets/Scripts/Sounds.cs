using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource infoSound;
    void Start()
    {
        infoSound.PlayDelayed(1.75f);
        if (Progress.levelFinished == 1)
        {
            Invoke("setInActive", 8.0f);
        } else if (Progress.levelFinished == 2)
        {
            Invoke("setInActive", 19.0f);
        }
    }
    void setInActive()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
}
