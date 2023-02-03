using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public static PointCounter instance;
    public TMP_Text scoreText;
    int points = 0;
    private void Awake()
    {
	instance = this;
    }
    void Start()
    {
      scoreText.text = "Score: " + points.ToString();
    }
    public void AddPoints(int p)
    {
        points += p;
        scoreText.text = "Score: " + points.ToString();
    }
}
