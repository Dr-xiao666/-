using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public PlayerControl playerControl;
    public GameObject overPanel;
    public Text score_txt;


    public Button returnBtn;
    void Start()
    {
        playerControl = GameManager.Instance.GetCurPlayer().GetComponent<PlayerControl>();
        overPanel.SetActive(false);
        returnBtn.onClick.AddListener(returnBtnClick);
        //GamePanel赋值
        GameManager.Instance.SetGamePanel(this);

        //GameManager.Instance.InstantiatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControl.hp <= 0)
        {
            overPanel.SetActive(true);
            Time.timeScale = 0f;
            BgmStop.instance.StopBGM();
            overPanel.SetActive(true);
        }
    }
    public void returnBtnClick()
    {
        GameManager.Instance.LoadScene_02_Main();//跳转场景2
        Time.timeScale = 1;
        if (BgmStop.instance != null && BgmStop.instance.mainSceneBGM != null)
        {
            BgmStop.instance.PlayMusic(BgmStop.instance.mainSceneBGM);
        }
    }
      public int score = 0;

      public void SetScore(int add)
    {
        //计算分数
        score += add;
        //显示分数
        score_txt.text = score.ToString();
    }



}//白嫖了威龙红皮哈哈哈
