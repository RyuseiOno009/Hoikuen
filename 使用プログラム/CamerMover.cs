using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CamerMover: MonoBehaviour
{
    // WASD：前後左右の移動
    // QE：上昇・降下
    // 右ドラッグ：カメラの回転
    // 左ドラッグ：前後左右の移動
    // スペース：カメラ操作の有効・無効の切り替え
    // P：回転を実行時の状態に初期化する

    //十字キー追加できるか？　2019/11/08
    // マウスホイールの回転値を格納する変数
    private float scroll;

    //カメラの移動量
    //[SerializeField, Range(0.1f, 10.0f)]
    private float _positionStep = 2.0f;

    //マウス感度
    [SerializeField, Range(30.0f, 150.0f)]
    private float _mouseSensitive = 90.0f;

    //カメラ操作の有効無効
    private bool _cameraMoveActive = true;
    //カメラのtransform  
    private Transform _camTransform;
    //マウスの始点 
    private Vector3 _startMousePos;
    //カメラ回転の始点情報
    private Vector3 _presentCamRotation;
    private Vector3 _presentCamPos;
    //初期状態 Rotation
    private Quaternion _initialCamRotation;
    //UIメッセージの表示
    private bool _uiMessageActiv;

    
    void Start()
    {
        _camTransform = this.gameObject.transform;

        //初期回転の保存
        _initialCamRotation = this.gameObject.transform.rotation;



    }

    void Update()
    {
        // マウスホイールの回転値を変数 scroll に渡す
        scroll = Input.GetAxis("Mouse ScrollWheel");

        // カメラの前後移動処理
        //（カメラが向いている方向 forward に変数 scroll と speed を乗算して加算する）
        Camera.main.transform.position += transform.forward * scroll * _positionStep;

        CamControlIsActive(); //カメラ操作の有効無効

        if (_cameraMoveActive)
        {
            ResetCameraRotation(); //回転角度のみリセット
            CameraRotationMouseControl(); //カメラの回転 マウス
            //CameraSlideMouseControl(); //カメラの縦横移動 マウス
            //CameraPositionKeyControl(); //カメラのローカル移動 キー
        }
    }

    //カメラ操作の有効無効
    public void CamControlIsActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cameraMoveActive = !_cameraMoveActive;

            if (_uiMessageActiv == false)
            {
                StartCoroutine(DisplayUiMessage());
            }
            Debug.Log("CamControl : " + _cameraMoveActive);
        }
    }

    //回転を初期状態にする
    private void ResetCameraRotation()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.gameObject.transform.rotation = _initialCamRotation;
            Debug.Log("Cam Rotate : " + _initialCamRotation.ToString());
        }
    }

    float prevAngleX = 0.0f, prevAngleY = 0.0f;
    float eulerX = 0, eulerY = 0;

    //カメラの回転 マウス
    private void CameraRotationMouseControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        { 
            //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
            float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = -(_startMousePos.y - Input.mousePosition.y) / Screen.height; 

            //回転開始角度 ＋ マウスの変化量 * マウス感度
            eulerX = prevAngleX + _presentCamRotation.x + y * _mouseSensitive;
            eulerY = prevAngleY + _presentCamRotation.y + x * _mouseSensitive;

            float xspeed = 0.01f;
            float angleX = eulerX * xspeed;
            angleX = Math.Min(0, Math.Max(-Mathf.PI / 2.0f, angleX));
            eulerX = angleX / xspeed;

            MoveObjects("Main Camera", "1FPivot", angleX, eulerY,0);
            MoveObjects("Cam2", "2FPivot", angleX, eulerY,100);
            //1FPivotと2FPivotを検索（回転するオブジェクトを検出）

        }
        if (Input.GetMouseButtonUp(0))
        {
            prevAngleX = eulerX;
            prevAngleY = eulerY;
            //マウスがクリックされたか真偽
        }
    }
    // tr = GameObject.Find("2Camera").transform;

    void MoveObjects(string camname, string objname, float angleX,float angleY,float camX)
    {
        float r = -6;
        //カメラ回転半径６で設定

        Transform tr = GameObject.Find(objname).transform;
        tr.rotation = Quaternion.AngleAxis(angleY, new Vector3(0, 1, 0));

        tr = GameObject.Find(camname).transform;
        tr.position = new Vector3(camX, r * Mathf.Sin(angleX), r * Mathf.Cos(angleX));
        float rotangle = -angleX * Mathf.Rad2Deg;
        tr.rotation = Quaternion.AngleAxis(rotangle, new Vector3(1, 0, 0));

    }

    //カメラの移動 マウス
    private void CameraSlideMouseControl()
    { 
        if (Input.GetMouseButtonDown(1))
            //マウスのボタンが押し込まれたか
        {
            _startMousePos = Input.mousePosition;
            _presentCamPos = _camTransform.position;
        }

        if (Input.GetMouseButton(1))
        {
            //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
            float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height; 

            x = x * _positionStep;
            y = y * _positionStep;

            Vector3 velocity = _camTransform.rotation * new Vector3(x, y, 0);
            velocity = velocity + _presentCamPos;
            _camTransform.position = velocity;
        } 
    } 

    //UIメッセージの表示
    private IEnumerator DisplayUiMessage()
    {
        _uiMessageActiv = true;
        float time = 0;
        while (time < 2)
        {
            time = time + Time.deltaTime;
            yield return null;
        }
        _uiMessageActiv = false;
    }

    void OnGUI()
    {
        if (_uiMessageActiv == false) { return; }
        GUI.color = Color.black;
        if (_cameraMoveActive == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 30, 100, 20), "カメラ操作 有効");
        }

        if (_cameraMoveActive == false)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 30, 100, 20), "カメラ操作 無効");
        }
    }

}
