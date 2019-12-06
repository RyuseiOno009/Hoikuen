using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gazou2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float[] zahyou1 = new float[3] { 97.062f, -0.002f, -2.831f };
        float[] zahyou2 = new float[3] { 102.371f, -0.002f, -2.831f };
        float[] zahyou3 = new float[3] { 102.371f, -0.002f, 2.716f };
        float[] zahyou4 = new float[3] { 97.062f, -0.002f, 2.716f };
        //見取り図の四隅の座標を入力。順に左下・右下・左上・右上

        Vector3 v1 = new Vector3(zahyou3[0], zahyou3[1], zahyou3[2]);
        Vector3 v2 = new Vector3(zahyou4[0], zahyou4[1], zahyou4[2]);
        Vector3 v3 = new Vector3(zahyou1[0], zahyou1[1], zahyou1[2]);

        float x = 0.4f, y = 0.5f;
        Vector3 pt = (1 - x - y) * v1 + x * v2 + y * v3;

        pt.y += 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
