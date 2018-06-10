using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    //指のIDを設定
    private int rightFingerId = 0;
    private int leftFingerId = 0;

    // Use this for initialization
    void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
		
	}
	
	// Update is called once per frame
	void Update () {

        //左矢印キーを推したときフリッパ
        if(Input.GetKeyDown(KeyCode.LeftArrow) && tag== "LeftFripperTag") {
        SetAngle(this.flickAngle);
        }
        //右矢印キーを押したとき右フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag"){
        SetAngle(this.flickAngle);
        }
		
        //矢印キーを離されたときフリッパーを元に戻す
        if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
        SetAngle(this.defaultAngle);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.defaultAngle);
        }

        //タッチされたかどうかを数える
        for (int i = 0; i < Input.touchCount; i++){

            var id = Input.touches[i].fingerId;
            var pos = Input.touches[i].position;

            //タッチされたときの処理
            if (Input.touches[i].phase == TouchPhase.Began){
                if (pos.x > Screen.width * 0.5 && tag == "RightFripperTag") {
                    rightFingerId = 0;
                    SetAngle(this.flickAngle);
                }else if (pos.x < Screen.width * 0.5 && tag == "LeftFripperTag") {
                    rightFingerId = 0;
                    SetAngle(this.flickAngle);

                }else if (Input.touches[i].phase == TouchPhase.Ended){
                    if (id == rightFingerId && tag == "RightFripperTag"){
                        SetAngle(this.defaultAngle);
                    }else if (id == leftFingerId && tag == "LeftFripperTag") {
                        SetAngle(this.defaultAngle);

                    }
                }

            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle) {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;

    }
}
