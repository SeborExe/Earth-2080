using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem ExplosionParticle;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        var level = SceneManager.GetActiveScene().buildIndex;
        GetComponent<PlayerControlls>().enabled = false;

        GetComponent<MeshRenderer>().enabled = false;
        ExplosionParticle.Play();

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
