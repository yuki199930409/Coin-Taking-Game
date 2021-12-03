using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audioSource;
    private float time;
    private int Startflg;
    private int keyflg;
    public int Dataflg;
    private GameObject Sd;

    void Start()
    {
        time = 0;  //初期値は0
        Startflg = 0; 
        keyflg = 0; 
        Dataflg = 0;
        Sd = GameObject.Find("ScoreData");  //ScoreDataを探す
    }

    public void ButtonClick()
    {
        keyflg = 1;  //ButtonClickが押された時に0から1になる
        Dataflg = 1;

        if(Dataflg == 1)  //ButtonClickが押された時にDataflgが1になるので下記を実行
        {
            Destroy(Sd);  //削除しないとScoreDataが増えるのでリトライした時にScoreDataを削除する
        }
    }

    public void StartClick()
    {
        Startflg = 1;  //StartClickが押された時にfalseからtrueになる
    }

    void Update()
    {
        if (keyflg == 1)  //ButtonClickが押されたら1になるのでif文が実行される
        {
            time = time + Time.deltaTime;  //0にTime.deltaTimeを足していく
            if (time >= 0.5f)
            {
                SceneManager.LoadScene("Start");  //timeが0.5秒経ったらStartに遷移される
            }
        }

        if (Startflg == 1)  //StartClickが押されたらtrueになるのでif文が実行される
        {
            time = time + Time.deltaTime;  //0にTime.deltaTimeを足していく
            if (time >= 0.5f)
            {
                SceneManager.LoadScene("GameMain");  //timeが0.5秒経ったらGameMainに遷移される
            }
        }
    }

    public void Sound()
    {
        audioSource.PlayOneShot(sound);  //Buttonのサウンド
    }
}
