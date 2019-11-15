﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    //static void main() {
    private float[] zahyou1 = new float[3] { 1.2868f, 0, 1.6927f };
    private float[] zahyou2 = new float[3] { 9.6191f, 0, 1.6939f };
    private float[] zahyou3 = new float[3] { 1.287f, 0, 8.89f };
    private float[] zahyou4 = new float[3] { 9.6242f, 0, 8.8773f };
    //見取り図の四隅の座標を入力。順に左下・右下・左上・右上
//}

    //private string url = "https://s3-ap-northeast-1.amazonaws.com/samurai-blog-media/blog/wp-content/uploads/2018/09/skybox.jpg";
    //URL経由で画像を読み込む
    // Start is called before the first frame update
    void Start()
    //スレッドを作成する
    {
        //float xcenter = (zahyou1[0] + zahyou2[0] + zahyou3[0] + zahyou4[0])/4;
        //float ycenter = 2+(zahyou1[1] + zahyou2[1] + zahyou3[1] + zahyou4[1])/4;
        //float zcenter = (zahyou1[2] + zahyou2[2] + zahyou3[2] + zahyou4[2])/4;
        //各座標の中心（平均）を求める

        byte[] bytes = System.Convert.FromBase64String(
           //"data:image/jpeg;base64,"+
           "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"
           );
        //Base64の画像を読み込む
        var texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        //WWW www = new WWW(url);
        //URLから画像を読み込む
       // yield return www;
       //画像が表示されるまで別スレッドで読み込む

        //Texture tx = www.texture;
        int width = texture.width;
        int height = texture.height;
        //読み込んだ画像に合わせた縦横比にする

        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //画面に四角形を表示する

        Vector3 v1 = new Vector3(zahyou3[0], zahyou3[1], zahyou3[2]);
        Vector3 v2 = new Vector3(zahyou4[0], zahyou4[1], zahyou4[2]);
        Vector3 v3 = new Vector3(zahyou1[0], zahyou1[1], zahyou1[2]);

        float x = 0.2f , y = 0.5f;
        Vector3 pt = (1-x-y) * v1 +  x * v2 + y * v3 ;

        const float imgOffsY = 2.0f;
        const float imgH = 1.0f;

        pt.y += imgOffsY;
        obj.transform.position = pt; // new Vector3((float)xcenter, (float)ycenter, (float)zcenter);
        pt.y -= imgOffsY;

        //四角形の位置を変更する
        obj.transform.localScale = new Vector3(width/(float)height, imgH, 1);
        //四角形のサイズを読み込んだ画像から縦横比を割り出す

        obj.GetComponent<Renderer>().material.mainTexture = texture;// www.texture;


        // Draw lines
        GameObject bObj = GameObject.Find("building");
        //倉木永田のオブジェクト情報の読み取り

        bObj.AddComponent<LineRenderer>();
        LineRenderer lineObj = bObj.GetComponent<LineRenderer>();
        //LineRendererの立ち位置の宣言

        lineObj.positionCount = 2;

        lineObj.SetPosition(0, pt);
        pt.y += imgOffsY - 0.5f* imgH;
        lineObj.SetPosition(1, pt);
        //ラインの位置調整

        lineObj.startWidth = 0.05f;
        lineObj.endWidth = 0.05f;
        //ラインの太さ変更



        /*Vector3[] vertex = new Vector3[] { 
            new Vector3(0f, 0f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(1f, 1f, 0f)
        }; 
        //各座標を指定している
        int[] face = new int[] { 0, 1, 2 };
        // 0と1、1と2、2と0がつながり面となる
        Mesh mesh = new Mesh();
        //3Dの形状を管理するモデルデータを作って渡す
        mesh.vertices = ;
        mesh.triangles = face;
        //頂点や面情報を渡す
        GameObject  = new GameObject("Object"); 

        MeshFilter mesh_filter = obj.AddComponent<MeshFilter>();
        obj.AddComponent<MeshRenderer>();
        mesh_filter.mesh = mesh;        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
