using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    private GameObject ScoreMaster;
    private ScoreData Sd;
    public Text Yellowtx;
    public Text Redtx;
    public Text Yellowtext;
    public Text Redtext;
    public Text ScoreSumtext;
    private int YellowScore;
    private int RedScore;
    private float time;

    void Start()
    {
        ScoreMaster = GameObject.Find("ScoreData");  //ScoreDataを探す
        Sd = ScoreMaster.GetComponent<ScoreData>();

        YellowScore = Sd.GetYellowScore();
        Yellowtx.text = string.Format("=  {0} × 100", YellowScore);  //YellowScoreを表示するフォーマット
        Yellowtext.text = (YellowScore * 100).ToString();

        RedScore = Sd.GetRedScore();
        Redtx.text = string.Format("=  {0} × 300", RedScore);
        Redtext.text = (RedScore * 300).ToString();

        ScoreSumtext.text = ((YellowScore * 100) + (RedScore * 300)).ToString();
    }
}
