using UnityEngine;

public class TtenSeokgi : MonoBehaviour
{
    [SerializeField] int hp = 5;

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
            gameManager.SetSuccessRate();
            gameManager.SetGameResult(GameState.success);
        }
    }
}
