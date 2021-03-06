using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect, hitParticles;
    [SerializeField] int score = 10;
    [SerializeField] int hitPoints = 2;
    int currentHitPoints;

    ScoreBoard scoreBoard;

    private void Start()
    {   
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;

        scoreBoard = FindObjectOfType<ScoreBoard>();
        currentHitPoints = hitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHitPoints--;

        var particle = Instantiate(hitParticles, transform.position, Quaternion.identity);
        Destroy(particle, 1f);

        if (currentHitPoints <= 0)
            DestroyEnemy();
    }

    void DestroyEnemy()
    {
        scoreBoard.IncreaseScore(score);
        var particle = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(particle, 2f);
        Destroy(this.gameObject);
    }
}
