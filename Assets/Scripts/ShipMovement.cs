using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Transform center;
    public float moveSpeed = 90f;
    public GameObject startPanel;
    public GameObject gameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(0, 0, transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (startPanel.activeInHierarchy)
           return;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(center.position, new Vector3(0, 0, 1f), moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(center.position, new Vector3(0, 0, 1f), -moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameoverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
