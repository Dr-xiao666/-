using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.name);
        //Debug.Log(scene.buildIndex);
         SceneManager.sceneLoaded += sceneLoadedOk;
    }


    // Update is called once per frame
    void Update()
    {
       //if (Input.GetKeyDown(KeyCode.W))
       //{
            
       // }
       // if (Input.GetKeyDown(KeyCode.L))
       //{
       //    SceneManager.LoadScene("_03_Battle01");
       //   }
    }

    public void LoadScene_02_Main()
    {
        SceneManager.LoadScene("_02_Main");
    }

    private void sceneLoadedOk(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("进入到新场景，新场景名称为：" + scene.name);
    }
}
