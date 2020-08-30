﻿using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class MultiTouch : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    //タッチ情報
    Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            this.touch = Input.touches[0];

            //左画面をタップした時左フリッパーを動かす
            if (touch.phase == TouchPhase.Began && touch.position.x <= Screen.width/2 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            
            //右画面をタップした時左フリッパーを動かす
            if (touch.phase == TouchPhase.Began && touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //左画面のタップが終わった時フリッパーを元に戻す
            if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            
            //右画面のタップが終わった時フリッパーを元に戻す
            if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
