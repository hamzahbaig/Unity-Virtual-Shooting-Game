using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource introdcutionSound;
    public GameObject mainMenu;
    
    void Start()
    {
        
        introdcutionSound.PlayDelayed(1.75f);

    }
    public void goToMainMenu()
    {
        introdcutionSound.Pause();
        mainMenu.SetActive(true);
    }
    
}
