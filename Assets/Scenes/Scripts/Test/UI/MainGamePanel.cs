using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGamePanel : MonoBehaviour
{
    public Button StartGameBtn;
    public Button leftBtn;
    public Button rightBtn;

    public GameObject[] players;
    private int showIndex = 0;

    void Start()
    {
        StartGameBtn.onClick.AddListener(StartGameBtnClick);

        leftBtn.onClick.AddListener(leftBtnClick);
        rightBtn.onClick.AddListener(rightBtnClick);
    }


    void Update()
    {

    }

    public void StartGameBtnClick()
    {
        GameManager.Instance.LoadScene_03_Battle01();//跳转场景3
    }
    public void leftBtnClick()
    {
        players[showIndex].SetActive(false);
        showIndex--;
        showIndex = showIndex < 0 ? players.Length - 1 : showIndex;
        players[showIndex].SetActive(true);

        //通知GameManager 当前选择的玩家
        GameManager.Instance.playerIndex = showIndex;
    }
    public void rightBtnClick()
    {

        players[showIndex].SetActive(false);
        showIndex++;
        showIndex = showIndex % players.Length;
        players[showIndex].SetActive(true);

        //通知GameManager 当前选择的玩家
        GameManager.Instance.playerIndex = showIndex;
    }
}
