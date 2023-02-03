using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    public GameObject startPanel;
    public float bulletSpeed = 10f;
    private bool isButtonPressed = false;


    // Update is called once per frame
    void Update()
    {
        if (startPanel.activeInHierarchy)
            return;

        if (Input.GetKey(KeyCode.Space) && !isButtonPressed)
        {
            isButtonPressed = true;
            InvokeRepeating("SpawnBullet", 0f, 0.3f);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isButtonPressed = false;
            CancelInvoke("SpawnBullet");
        }
    }

    private void SpawnBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawner.forward * bulletSpeed;
    }
}
