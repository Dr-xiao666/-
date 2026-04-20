using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//全局管理者
public class GameManager : MonoBehaviour
{

    #region 单例模式
    public static GameManager Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion
    private GamePanel gamePanel;
    public AudioSource audioSource;
    //玩家数组
    public GameObject[] Players;

    public int playerIndex = 0;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //初始化
        Init();
        //获取成绩
        float score = PlayerPrefs.GetFloat("GameScore");

        //设置音量
        audioSource.volume = 0.5f;
        
    }

    //实例化玩家
    private GameObject insPlayer;
    public void InstantiatePlayer()
    {
        insPlayer = Instantiate(Players[playerIndex], new Vector3(0, 0, 0), Quaternion.identity);
    }
    public GameObject GetCurPlayer()
    {
        return insPlayer;
    }
    void Update()
    {
        
    }
    //场景加载功能初始化
    private void Init()
    {
        SceneManager.sceneLoaded += sceneLoadedOk;
    }
    public void SetGamePanel(GamePanel gamePanel)
    {
        this.gamePanel = gamePanel;
    }
    //设置分数
    public void SetScore(int addscore)
    {
        this.gamePanel.SetScore(addscore);
    }
    #region 场景加载
    public void LoadScene_01_StartMenu()
    {
        SceneManager.LoadScene("_01_StartMenu");
    }

    public void LoadScene_02_Main()
    {
        SceneManager.LoadScene("_02_Main");
    }

    public void LoadScene_03_Battle01()
    {
        SceneManager.LoadScene("_03_Battle01");
        
    }

    public void LoadScene_04_Battle02()
    {
        SceneManager.LoadScene("_03_Battle02");
    }

    public void LoadScene_05_Battle03()
    {
        SceneManager.LoadScene("_03_Battle03");
    }

    //当前场景加载完成之后
    private void sceneLoadedOk(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("进入到新场景，新场景名称为：" + scene.name);
        if (scene.name == "_03_Battle01")
        {
            InstantiatePlayer();
        }
    }
    #endregion
   


}


