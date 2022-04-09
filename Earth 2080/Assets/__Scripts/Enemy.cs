using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject exposionParticle;
    private void OnParticleCollision(GameObject other)
    {
        var particle = Instantiate(exposionParticle, transform.position, Quaternion.identity);
        Destroy(particle, 2f);
        Destroy(this.gameObject);
    }
}
