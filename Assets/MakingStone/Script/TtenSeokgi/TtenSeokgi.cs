using UnityEngine;

public class TtenSeokgi : MonoBehaviour
{
    [SerializeField] int hp = 5;

    MakingStoneManager makingStoneManager;

    void Start()
    {
        makingStoneManager = FindObjectOfType<MakingStoneManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReduceStoneHP()
    {
        hp--;

        if (hp == 0)
        {
            makingStoneManager.SetSuccessRate();
            makingStoneManager.SetGameResult(GameState.success);
        }
    }
}
