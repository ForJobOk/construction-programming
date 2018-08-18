﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    //定数定義　壁方向　※定数は変数名と区別しやすくするために大文字

    public const int Wall_FRONT = 1;  //前　※定数は右回りで増加
    public const int Wall_RIGHT = 2;  //右
    public const int Wall_BACK = 3;  //後
    public const int Wall_LEFT = 4;  //左

    //定数定義　ボタンカラー

    public const int COLOR_GREEN = 0; //緑
    public const int COLOR_RED = 1; //赤
    public const int COLOR_BLUE = 2; //青
    public const int COLOR_WHITE = 3; //白

    //パブリック変数の宣言 UnityのInspectorで改良できる

    public GameObject panelWalls; 　     //壁全体

    public GameObject buttonHammer;      //ボタン : ハンマー
    public GameObject buttonKey;      //ボタン : 鍵

    public GameObject imageHammerIcon;   //アイコン : ハンマー
    public GameObject imageKeyIcon;   //アイコン : 鍵

    public GameObject buttonPig;      //ボタン : 豚の貯金箱


    public GameObject buttonMessage; 　　//ボタン : メッセージ
    public GameObject buttonMessageText; //メッセージテキスト

    public GameObject[] buttonLamp = new GameObject[3]; //ボタン : 金庫
    public Sprite[] buttonPicture = new Sprite[4]; 　　//ボタンの絵 

    public Sprite hammerPicture; 　　　　　　　　　　　 //ハンマーの絵
    public Sprite keyPicture; 　　　　　　　　　　　    //鍵の絵

    //プライベート変数 UnityのInspectorで改良不可

    private int wallNo; 　　　　　　　       //現在の向き

    private bool doesHaveHammer;             //ハンマーを持っているか ※bool型は真偽
    private bool doesHaveKey;             　 //鍵を持っているか 　　　※bool型は真偽

    private int[] buttonColor = new int[3];　//金庫のボタン



    // Use this for initialization
    void Start() {
        wallNo = Wall_FRONT;          //スタート時に前を向く

        doesHaveHammer = false;       //ハンマー持っていない状態
        doesHaveKey = false;       //鍵持っていない状態


        buttonColor[0] = COLOR_GREEN; //ボタン１の色は「緑」
        buttonColor[1] = COLOR_RED;   //ボタン２の色は「赤」
        buttonColor[2] = COLOR_BLUE;  //ボタン３の色は「青」
    }

    // Update is called once per frame
    void Update() {
    }

    //ボックスをタップ
    public void PushButtonBox()
    {
        if (doesHaveKey == false)
        {
            //鍵を持っていない場合
            DisplayMessage("鍵がかかっている");
        }
        else
        {
            //鍵を持っている場合
            SceneManager.LoadScene("ClearScene");
        }
    }

    //金庫のボタン１をタップ
    public void PushButtonLamp1()
    {
        ChangeButtonColor(0); //　※別途メソッド記述
    }
    public void PushButtonLamp2()
    {
        ChangeButtonColor(1); //　※別途メソッド記述
    }
    public void PushButtonLamp3()
    {
        ChangeButtonColor(2); //　※別途メソッド記述
    }

    //金庫のボタンの色を変更
    void ChangeButtonColor(int buttonNO)　//引数の型と変数
    {
        buttonColor[buttonNO]++;

        //白のときにボタンを押したら緑に変更
        if (buttonColor[buttonNO] > COLOR_WHITE)
        {
            buttonColor[buttonNO] = COLOR_GREEN;
        }
        //ボタンの画像を変更
        buttonLamp[buttonNO].GetComponent<Image>().sprite = buttonPicture[buttonColor[buttonNO]];


        //ボタンの色順をチェック
        if ((buttonColor[0] == COLOR_BLUE) && (buttonColor[1] == COLOR_WHITE) && (buttonColor[2] == COLOR_RED))
        {
            //ハンマーを所持しているか
            if (doesHaveHammer == false)
            {
                DisplayMessage("金庫の中にハンマーが入っていた");
                buttonHammer.SetActive(true);  //ハンマーの絵を表示
                imageHammerIcon.GetComponent<Image>().sprite = hammerPicture;

                doesHaveHammer = true;
            }
        }

    }

    //メモをタップ
    public void PushButtonMemo()
    {
        DisplayMessage("エッフェル塔と書いてある"); //※別途メソッド記述
    }

    //貯金箱をタップ
    public void PushButtonPig()
    {
        //ハンマーを所持しているか
        if (doesHaveHammer == false)
        {
            //持ってない
            DisplayMessage("素手では割れないほど固い");
        }
        else
        {
            //持っている
            DisplayMessage("貯金箱が割れて中から鍵が出てきた");

            buttonPig.SetActive(false); //貯金箱を消す
            buttonKey.SetActive(true);  //鍵の絵を表示
            imageKeyIcon.GetComponent<Image>().sprite = keyPicture;

            doesHaveKey = true;
        }
    }



    //ハンマーの絵をタップ
    public void PushButtonHammer()
    {
        buttonHammer.SetActive(false); //非アクティブで非表示にする
    }

    //鍵の絵をタップ
    public void PushButtonKey()
    {
        buttonKey.SetActive(false);
    }

    //メッセージをタップ
    public void PushButtonMessage()
    {
        buttonMessage.SetActive(false); //メッセージを消す　※SetActiveで非アクティブに
    }

        //右ボタン押したら
        public void PushButtonRight()
        {
            wallNo++; //方向を一つ右に

            //右回りなので「左」の次の向きは「前」
            if(wallNo > 4) 
            {
                wallNo = Wall_FRONT;
            }
            DisplayWall(); //壁表示更新　　※別途メソッド記述

            ClearButton(); //いらないものを消す
        }

        //左ボタン押したら
         public void PushButtonLeft()
        {
            wallNo--; //方向を一つ右に

            //左回りなので「前」の次の向きは「左」
            if (wallNo < 1)
            {
                wallNo = Wall_LEFT;
            }
            DisplayWall(); //壁表示更新　　※別途メソッド記述

        　　ClearButton(); //いらないものを消す
    }
    　　//表示ウィンドウを消す
        void ClearButton()
    {
        buttonHammer.SetActive(false);
        buttonKey.SetActive(false);
        buttonMessage.SetActive(false);
    } 
    　　
    　　//メッセージ表示
      void DisplayMessage(string mes) //引数の型と変数
    {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }

        //向いた方向の壁の情報 ※キャンバス上のパネルの位置を取得する
        void DisplayWall()
        {
            switch (wallNo)
            {
                case Wall_FRONT: //前
                    panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    break;
                case Wall_RIGHT: //右
                    panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                    break;
                case Wall_BACK: //後
                    panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                    break;
                case Wall_LEFT: //左
                    panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                    break;
            }
        }
}
