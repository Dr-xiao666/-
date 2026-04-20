using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmStop : MonoBehaviour
{
    public static BgmStop instance;
    private AudioSource audioSource;
    public AudioClip mainSceneBGM;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 停止音乐
    public void StopBGM()
    {
        audioSource.Stop();
    }
    public void PlayMusic(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
//最后一个脚本，完结了哈哈