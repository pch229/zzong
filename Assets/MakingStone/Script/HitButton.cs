using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class HitButton : MonoBehaviour
{
    PlayableDirector hitPlayDir;
    ParticleSystem hitParticle;

    private void Start()
    {
        hitPlayDir = FindObjectOfType<PlayableDirector>();
        hitParticle = FindObjectOfType<ParticleSystem>();
    }
    public void OnClick()
    {
        hitPlayDir.Play();
        hitParticle.Play();
    }
}
