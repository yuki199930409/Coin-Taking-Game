using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMain : MonoBehaviour
{
    public int YellowScore;
    public int RedScore;
    public Text YellowScoreText;
    public Text RedScoreText;
    public ScoreData Sd;
    public AudioClip[] sound;
    public AudioSource audioSource;

    void Start()
    {
        YellowScore = 0;
        RedScore = 0;
        Sd = GameObject.Find("ScoreData").GetComponent<ScoreData>();  //ScoreDataを探す
    }

    void Update()
    {
        YellowScoreText.text = string.Format("= {0}", YellowScore);  //YellowScoreTextの中のtextのスコア表示
        RedScoreText.text = string.Format("= {0}", RedScore);  //RedScoreTextの中のtextのスコア表示

        Sd.YellowScore = YellowScore;
        Sd.RedScore = RedScore;
    }

    public void Sound(int num)
    {
        audioSource.PlayOneShot(sound[num]);  //サウンドを出すためのコード
    }
}
