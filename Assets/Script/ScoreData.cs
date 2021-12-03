using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public int YellowScore;
    public int RedScore;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);  //シーン遷移してもデータを引き継ぐ
        YellowScore = 0;
        RedScore = 0;
    }

    public int GetYellowScore()
    {
        return YellowScore;  //ScoreDataの中のYellowScoreを返す
    }

    public int GetRedScore()
    {
        return RedScore;
    }
}
