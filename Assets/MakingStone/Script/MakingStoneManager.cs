using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    success,
    fail,
    none
}

public class MakingStoneManager : MonoBehaviour
{
    [SerializeField] GameObject successModalObj;
    [SerializeField] GameObject failModalObj;
    [SerializeField] GameObject materialImageObj;
    [SerializeField] int successRate;
    [SerializeField] Image successModalImage;
    [SerializeField] Image failModalImage;
    [SerializeField] Sprite[] spriteImages;
    [SerializeField] Sprite[] materialImages;

    Gamemanager gameManager;
    GameObject[] ttenSeokgiPool;
    GameObject[] ganSeokgiArrPool;
    Image materialImage;

    GameState gameState = GameState.none;
    int rate = 0;
    bool showStoneMaterials = false;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<Gamemanager>();
        materialImage = materialImageObj.GetComponentInChildren<Image>();
    }

    void Update()
    {
        if (gameState == GameState.success)
        {
            if (rate < (successRate / 10))
            {
                successModalImage.sprite = spriteImages[(int)gameManager.GetSelectedStone() * 2];
                successModalObj.SetActive(true);
            }
            else
            {
                failModalImage.sprite = spriteImages[(int)gameManager.GetSelectedStone() * 2 + 1];
                gameState = GameState.fail;
            }
        }
        else if (gameState == GameState.fail)
        {
            failModalImage.sprite = spriteImages[(int)gameManager.GetSelectedStone() * 2 + 1];
            failModalObj.SetActive(true);
        }

        if(showStoneMaterials)
        {
            successModalObj.SetActive(false);
            failModalObj.SetActive(false);
            materialImageObj.SetActive(true);
            materialImage.sprite = materialImages[(int)gameManager.GetSelectedStone()];
        }
    }

    public void SetGameResult(GameState result)
    {
        gameState = result;
    }

    public void SetSuccessRate()
    {
        rate = Random.Range(0, 10);
    }

    public GameState GetGameResult()
    {
        return gameState;
    }

    public void ShowStoneMaterial()
    {
        showStoneMaterials = true;
    }

    public void ExitWorkingScene()
    {
        SceneManager.LoadScene("1_Cave");
    }
}
