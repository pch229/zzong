using UnityEngine;
using UnityEngine.Playables;

public class StoneHit : MonoBehaviour
{
    PlayableDirector hitPlayDir;
    ParticleSystem hitParticle;

    void Start()
    {
        hitPlayDir = GetComponent<PlayableDirector>();
        hitParticle = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            hitPlayDir.Play();
            hitParticle.Play();
        }
    }
}
