using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//StartGamePanel管理开始界面所有的UI
public class StartGamePanel : MonoBehaviour
{
    public Button LoginGameBtn;


    void Start()
    {
        LoginGameBtn.onClick.AddListener(LoginGameBtnClick);
    }


    void Update()
    {

    }

    public void LoginGameBtnClick()
    {
        GameManager.Instance.LoadScene_02_Main();//跳转场景2
    }
}
