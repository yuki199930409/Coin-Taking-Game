using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public SystemMain Sm;
    private int CoinStatus;

    void OnTriggerEnter(Collider collision)
    {
        if (CoinStatus == 0)
        {
            if (gameObject.tag == "YellowCoin")  //YellowCoinタグがついていれば
            {
                Sm.YellowScore += 1;  //SystemMainの中のYellowScoreが+1上がる
                Destroy(this.gameObject);
                Sm.Sound(0);
            }
            else if (gameObject.tag == "RedCoin")
            {
                Sm.RedScore += 1;
                Destroy(this.gameObject);
                Sm.Sound(1);
            }
        }
    }

    void Start()
    {
        Sm = GameObject.Find("SystemMain").GetComponent<SystemMain>();  //SystemMainを探す
        CoinStatus = 0;
    }
}
