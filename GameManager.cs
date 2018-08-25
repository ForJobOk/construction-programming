using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int StageNo; 　　　　　　　　//ステージナンバー
    public bool isBallMoving; 　　　　　//ボール移動中か否か
    public GameObject ballPrefab; 　　　//ボールプレハブ
    public GameObject ball; 　　　　　　//ボールオブジェクト

    public GameObject goButton; 　　　　//ボタン：ゲーム開始
    public GameObject retryButton; 　　 //ボタン：リトライ

	// Use this for initialization
	void Start () {
        Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
        rd.isKinematic = true;
        retryButton.SetActive(false);  //リトライボタンを非表示
        isBallMoving = false;          //ボールは「移動中ではない」
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PushGoButton()
    {
        Gravity(false);　　　　　　　//重力を有効化
　
        retryButton.SetActive(true); //リトライボタンを表示
        goButton.SetActive(false);　 //Goボタンを非表示
        isBallMoving = true;　　　　 //ボールは「移動中」
    }
    //リトライボタンを押す
    public void PushRetryButton()
    {
        Destroy(ball);             　//ボールオブジェクトを削除

        //プレハブから新しいボールオブジェクト作成
        ball = (GameObject)Instantiate(ballPrefab);  //Instantiateは引数に指定したオリジナルのオブジェクトのクローンを返す
                                                     //変数に代入するときは(GameObject)をつけてキャストする

        Gravity(true); 　　　　　　　　//重力を無効化

        retryButton.SetActive(false);　//リトライボタンを非表示
        goButton.SetActive(true);　　　//GOボタンを表示
        isBallMoving = false;　　　　　//ボールは「移動中ではない」
    }

    //ボールの重力を有効(false)、無効(true)に切り替える
    void Gravity(bool gravity)
    {
        Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
        rd.isKinematic = (gravity);  //isKinematicは物理エンジンを有効、無効に切り替える(bool型で有効はfalse)
    }
}
