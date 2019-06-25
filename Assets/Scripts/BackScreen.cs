using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BackScreen : MonoBehaviour
{
    int index;
    private void Awake()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (index == 0)
                {
                    Application.Quit();
                }
                if (index == 3 || index == 2 || index == 1)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

}
