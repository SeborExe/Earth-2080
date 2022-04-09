using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    [SerializeField] TMP_Text scoreBoardText;

    private void Start()
    {
        scoreBoardText.text = "START";
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreBoardText.text = score.ToString();
    }
}
