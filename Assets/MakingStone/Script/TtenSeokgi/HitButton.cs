using UnityEngine;
using UnityEngine.Playables;

public class HitButton : MonoBehaviour
{
    PlayableDirector hitPlayDir;
    ParticleSystem hitParticle;
    RotateGauge rotateGauge;
    TtenSeokgi ttenSeokgi;
    GameManager gameManager;
    HittingCrossHair hittingCrossHair;

    private void Start()
    {
        hitPlayDir = FindObjectOfType<PlayableDirector>();
        hitParticle = FindObjectOfType<ParticleSystem>();
        rotateGauge = FindObjectOfType<RotateGauge>();
        ttenSeokgi = FindObjectOfType<TtenSeokgi>();
        gameManager = FindObjectOfType<GameManager>();
        hittingCrossHair = FindObjectOfType<HittingCrossHair>();
    }
    public void OnClick()
    {
        if (gameManager.GetGameResult() == GameState.none)
        {
            if (hittingCrossHair.GetIsOnTarget())
            {
                if (rotateGauge.GetIsHitTiming() == HittingTimingState.SUCCESS_TIMING)
                {
                    hitPlayDir.Play();
                    hitParticle.Play();
                    ttenSeokgi.ReduceStoneHP();
                }
                else if (rotateGauge.GetIsHitTiming() == HittingTimingState.FAIL_TIMING)
                {
                    gameManager.SetGameResult(GameState.fail);
                }
            }
        }
        else
        {
            return;
        }
    }
}
