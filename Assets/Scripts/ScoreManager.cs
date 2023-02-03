using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    } 

    public void Addscore(float currentRadius, float maxRadius)
    {
        score += (int)maxRadius - (int)currentRadius;
        scoreText.text = "Score : "+score.ToString();
    } 
}
