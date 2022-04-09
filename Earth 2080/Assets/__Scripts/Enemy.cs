using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject exposionParticle;
    [SerializeField] int score = 10;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        var particle = Instantiate(exposionParticle, transform.position, Quaternion.identity);
        Destroy(particle, 2f);

        scoreBoard.IncreaseScore(score);

        Destroy(this.gameObject);
    }
}
