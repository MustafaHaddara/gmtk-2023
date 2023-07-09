using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem particlesToSpawn;
    private Camera c;

    // Start is called before the first frame update
    void Start()
    {
        c = Camera.main;
    }

    public void SpawnParticles() {
        Vector3 worldPos = c.ScreenToWorldPoint(gameObject.transform.position);
        Vector3 particlePos = new Vector3(worldPos.x, worldPos.y, 0);
        ParticleSystem particles = Instantiate(particlesToSpawn, particlePos, Quaternion.identity);

        ScreenSpaceFollower ssf = particles.gameObject.GetComponent<ScreenSpaceFollower>();
        ssf.c = c;
        ssf.parent = gameObject;
    }

}
