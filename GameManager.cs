using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    //定数定義　壁方向　※定数は変数名と区別しやすくするために大文字
    public const int Wall_FRONT = 1;  //前　※定数は右回りで増加
    public const int Wall_RIGHT = 2;  //右
    public const int Wall_BACK  = 3;  //後
    public const int Wall_LEFT  = 4;  //左

    public GameObject panelWalls; 　 //壁全体

    private int wallNo; 　　　　　　　//現在の向き



    // Use this for initialization
    void Start () {
        wallNo = Wall_FRONT;          //スタート時に前を向く
	}

    // Update is called once per frame
    void Update() {
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
