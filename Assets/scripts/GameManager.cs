using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject winText;
    public GameObject restartButton;

    private int score = 0;
    public int totalTargets = 5;

    void Start()
    {
        UpdateScore();
        winText.SetActive(false);
        restartButton.SetActive(false);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
        if (score >= totalTargets)
        {
            winText.SetActive(true);
            restartButton.SetActive(true);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}