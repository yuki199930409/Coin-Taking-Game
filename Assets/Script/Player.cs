using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Animator Ani;
    private SpriteRenderer spr;
    private int KeyFlg;
    private int status;
    private float JumpPower = 250;  //ジャンプ力
    public int JumpCount;
    public SystemMain Sm;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        status = 0;
        JumpCount = 0;
    }

    void Update()
    {
        KeyFlg = 0;  //どのアニメーションを再生させるかのフラグ

        if (Input.GetKey(KeyCode.RightArrow))
        {
            KeyFlg = 1;  //KeyFlgが0なのでStopアニメーションは再生されない
            transform.Translate(0.1f, 0f, 0f);  //右キーを押した時に移動される
            if (status != 1)
            {
                spr.flipX = false;  //sprの中のflipXがオフ
                status = 1;
                Ani.Play("Player");  //Playerアニメーションが再生される
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            KeyFlg = 1;  //KeyFlgが0なのでStopアニメーションは再生されない
            transform.Translate(-0.1f, 0f, 0f);  //左キーを押した時に移動される
            if (status != 2)
            {
                spr.flipX = true;  //sprの中のflipXがオン
                status = 2;
                Ani.Play("Player");  //Playerアニメーションが再生される
            }
        }

        if (KeyFlg == 0)  //KeyFlgが0であればStayアニメーションが再生される
        {
            Ani.Play("Stop");
        }

        if (JumpCount <= 1)  //JumpCountが1以下だったら
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpCount++;  //JumpCountに+1足されていく
                rb.AddForce(Vector3.up * JumpPower);  //上にJumpPower分、力をかける
                Sm.Sound(2);
            }
            //スペースキーと右キーまたはスペースキーと左キーを押すとJumpアニメーションが表示
            if ((Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow)))
            {
                Ani.Play("Jump");
            }
        }
    }

    void OnCollisionEnter(Collision collision)  //地面に触れた時の処理
    {
        JumpCount = 0;
        Ani.Play("Player");
    }
}
