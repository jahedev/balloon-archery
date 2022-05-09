using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score;
    private Coroutine coroutine;


    public void UpdateScore(int score)
    {
        this.score += score;
        ShowScore();
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public int GetScore()
    {
        return score;
    }

    public void ShowScore()
    {
        float waitSeconds = 1f;

        scoreText.text = score.ToString();

        if (coroutine == null)
        {
            coroutine = StartCoroutine(HideScore(waitSeconds));
        }
        else
        {
            StopCoroutine(coroutine);
            StartCoroutine(HideScore(waitSeconds));
        }
    }

    IEnumerator HideScore(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        scoreText.text = "";
        coroutine = null;
    }

}
