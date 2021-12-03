using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Time : MonoBehaviour
{
    public GameObject Finish;  //紐づけたいオブジェクトを紐づける
    private float time; //カウントダウンタイム
    public Text TimeText;  //タイムを表示させたいTextを紐づける
    private float SceneTime;    //経過時間カウント用
    public static float deltaTime = 0.017f;

    void Start()
    {
        time = 10.0f; 
        SceneTime = 0;
    }

    void Update()
    {
        TimeText.text = String.Format("{00:00.00}", time);  //TimeTextの中のtextのタイム表示
        time -= Time.deltaTime;   //経過時刻を引いていく

        if (time <= 0.0f)
        {
            time = 0.0f;  //timeが0以下になってもカウントダウンされるためtimeは0秒で止めておく
            Finish.SetActive(true);  //timeが0になればFinishを表示
            SceneTime += Time.deltaTime;  //Time.deltaTimで足していく

            if (SceneTime >= 1.0f)
            {
                SceneManager.LoadScene("Result");  //ゲームが終わって1秒後にResultへ遷移される
            }
        }
    }
}
