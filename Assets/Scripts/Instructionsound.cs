using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructionsound : MonoBehaviour
{
    public AudioSource Instructions;
    public GameObject  Gun;
    // Start is called before the first frame update
    void Start()
    {
        Instructions.Play();
        Invoke("makeActive", 10.0f);
    }
    void makeActive()
    {
        Gun.SetActive(true);
        Destroy(this.gameObject);
    }

   
}
