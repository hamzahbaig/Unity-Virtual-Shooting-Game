using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchPosition : MonoBehaviour
{
    private Vector3 target;
    public GameObject crosshairs;
    public GameObject gun;
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public AudioSource gunSound;
    public GameObject AudioManager;

    private void Start()
    {
        AudioManager.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

        gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
       
        if (Input.touchCount == 1) {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z));
                crosshairs.transform.position = new Vector2(-target.x, -target.y);

                Vector3 difference = target - gun.transform.position;
                float rotatioZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotatioZ + 90.0f);
                Shoot();
                
            }
        }
       
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        gunSound.enabled = true;
        gunSound.Play();
    }
}
