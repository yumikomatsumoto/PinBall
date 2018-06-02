using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreText : MonoBehaviour{
    //スコアを表示するテキスト
    private GameObject scoreText;

    //スコア用の変数
    private int score = 0;

    // Use this for initialization
    void Start(){
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update(){
    }


    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other){

        //当たったオブジェクトに応じてスコアを足しわける
        if (other.gameObject.tag == "SmallStarTag") {
            Debug.Log(other.gameObject.name);
            score += 5;
        } else if (other.gameObject.tag == "SmallCloudTag"){
            Debug.Log(other.gameObject.name);
            score += 10;
        } else if (other.gameObject.tag == "LargeCloudTag"){
            Debug.Log(other.gameObject.name);
            score += 20;
        } else if (other.gameObject.tag == "LargeStarTag"){
            Debug.Log(other.gameObject.name);
            score += 30;
        }

        //スコアをテキストに反映させる
        this.scoreText.GetComponent<Text>().text = "Score:" + score;
    }
}