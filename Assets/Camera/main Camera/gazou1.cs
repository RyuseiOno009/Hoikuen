using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gazou1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          float[] zahyou1 = new float[3] { 1.2868f, 0, 1.6927f };
   float[] zahyou2 = new float[3] { 9.6191f, 0, 1.6939f };
     float[] zahyou3 = new float[3] { 1.287f, 0, 8.89f };
   float[] zahyou4 = new float[3] { 9.6242f, 0, 8.8773f };
    //見取り図の四隅の座標を入力。順に左下・右下・左上・右上

    Vector3 v1 = new Vector3(zahyou3[0], zahyou3[1], zahyou3[2]);
    Vector3 v2 = new Vector3(zahyou4[0], zahyou4[1], zahyou4[2]);
    Vector3 v3 = new Vector3(zahyou1[0], zahyou1[1], zahyou1[2]);

    float x = 0.2f, y = 0.5f;
    Vector3 pt = (1 - x - y) * v1 + x * v2 + y * v3;

    pt.y += 2;
}

// Update is called once per frame
void Update()
    {
        
    }
}
