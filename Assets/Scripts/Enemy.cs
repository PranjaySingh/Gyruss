using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startRadius = 1f;
    public float maxRadius;
    public float moveSpeed = 1.5f;
    public float radiusIncRate = 0.2f;
    public int direction = 1;
    public ScoreManager scoreManager;

    private float currentRadius;
    private float angle;

    private void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentRadius = startRadius;
        angle = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * moveSpeed * direction;
        float x = Mathf.Cos(angle) * currentRadius;
        float y = Mathf.Sin(angle) * currentRadius;
        transform.position = new Vector3(x, y, 0f);
        if (currentRadius <= maxRadius)
        {
            currentRadius += Time.deltaTime * radiusIncRate;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            scoreManager.Addscore(currentRadius, maxRadius);
        }
    }
}
