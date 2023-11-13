using UnityEngine;
using UnityEngine.Playables;

public class HitButton : MonoBehaviour
{
    [SerializeField] PlayableDirector hitPlayDir;
    [SerializeField] ParticleSystem hitParticle;
    RotateGauge rotateGauge;
    TtenSeokgi ttenSeokgi;
    MakingStoneManager makingStoneManager;
    HittingCrossHair hittingCrossHair;

    private void Start()
    {
        rotateGauge = FindObjectOfType<RotateGauge>();
        ttenSeokgi = FindObjectOfType<TtenSeokgi>();
        makingStoneManager = FindObjectOfType<MakingStoneManager>();
        hittingCrossHair = FindObjectOfType<HittingCrossHair>();
        hitPlayDir = FindObjectOfType<PlayableDirector>();
        hitParticle = FindObjectOfType<ParticleSystem>();
    }
    public void OnClick()
    {
        if (makingStoneManager.GetGameResult() == GameState.none)
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
                    makingStoneManager.SetGameResult(GameState.fail);
                }
            }
        }
        else
        {
            return;
        }
    }
}
