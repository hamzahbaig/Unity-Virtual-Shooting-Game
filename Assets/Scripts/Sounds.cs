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
        Invoke("setInActive", 8.0f);
    }
    void setInActive()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
}
