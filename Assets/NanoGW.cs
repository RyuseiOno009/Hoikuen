using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class NanoGW : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string jsNanoGWGetFolders();

    [DllImport("__Internal")]
    private static extern string jsNanoGWGetCacheFile(string folderName);

    void Start()
    {
        //Debug.Log(
        GetFolders();
            //);
    }

    public static string GetFolders()
    {
        return jsNanoGWGetFolders();
    }

    public static string GetCacheFile(string folderName)
    {
        return jsNanoGWGetCacheFile(folderName);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
