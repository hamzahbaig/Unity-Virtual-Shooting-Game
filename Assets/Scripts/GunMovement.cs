using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GunMovement : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public Gyroscope deviceGyro;
    public Text counter;
    private int secs = 7;
    private bool gyroEnabled;
    float offset;
    private bool flag = true;
    int count = 0;
    public GameObject AudioManager;
    public AudioSource gunSound;
    public static float distance = 12.0f;
    public int Allowedmiss;
    private int currentMiss = 0;
    public AudioSource Shotmissed;
    

    // Use this for initialization
    void Start()
    {

        counter.text = secs.ToString();
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {

        if (SystemInfo.supportsGyroscope)
        {
            deviceGyro = Input.gyro;
            deviceGyro.enabled = true;
            

            return true;
        }
     
        return false;
    }
   
    // Update is called once per frame
    void Update()
    {
        
        if (Physics2D.Raycast(transform.position,transform.up, 10))
        {
           // Handheld.Vibrate();
        }
        
        // Adjust the gun after 2 secs.
        if (flag)
        {
            GunCalibiration();
        }

        // Check the input of user every frame.. If Yes then fires the bullet
        if (level1.bulletDistance > distance)
        {
            Shotmissed.Play();
            currentMiss++;
            // Voice to be added on missed 
            
            level1.bulletDistance = 0;

        }
        if(currentMiss >= Allowedmiss )
        {
            Invoke("changeScene", 1.5f);
            

        }
        
        ChechShoot();
        

        // Gyroscope implementation.
        GunRotation();
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.name == "Enemy1")
        {
            currentMiss++;
        }
    }

    void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        gunSound.enabled = true;
        gunSound.Play();
    }

    void ChechShoot()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                    Shoot();
            }
        }
    }

    void GunRotation()
    {
        transform.localEulerAngles = new Vector3(0, 0,deviceGyro.attitude.eulerAngles.z +  offset);
    }

    void GunCalibiration()
    {
        count++;
        if (count == 420) {
            offset = 360.0f - deviceGyro.attitude.eulerAngles.z;
            counter.text = "";
            flag = false;
            AudioManager.SetActive(true);

        }
        else if (count % 60 == 0)
        {
            counter.text = (--secs).ToString();
        }

    }

   
}
