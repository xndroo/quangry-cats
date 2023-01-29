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
	Debug.Log("Score: " + points.ToString());
	scoreText.text = "Score: " + points.ToString();
    }
    public void RatPoints()
    {
        points += 1000;
	scoreText.text = "Score: " + points.ToString();
    }
    public void ArmoredRatPoints()
    {
        points += 2000;
	scoreText.text = "Score: " + points.ToString();
    }
    public void MetalPoints()
    {
        points += 30;
	scoreText.text = "Score: " + points.ToString();
	Debug.Log("Score: " + points.ToString());
    }
    public void GlassPoints()
    {
        points += 10;
	scoreText.text = "Score: " + points.ToString();
    }
    public void WoodPoints()
    {
        points += 20;
	scoreText.text = "Score: " + points.ToString();
    }
}
