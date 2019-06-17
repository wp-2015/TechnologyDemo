using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class BackLuaCode : MonoBehaviour
{
    public Button bt;
    private void Start()
    {
        ReadFile();
        bt.onClick.AddListener(work);
    }

    byte[] _Bytes;

    void ReadFile()
    {
        var bytes = File.ReadAllBytes(Application.dataPath + "/BackCode/RedPointPreConditions.lua");
        string res = "";
        for(int i = 0; i < 200; i++)
        {
            res +=  " " + bytes[i].ToString();
        }
        Debug.Log(res);

        var bytes1 = File.ReadAllBytes(Application.dataPath + "/BackCode/UIActionIDCacheManager.lua");
        string res1 = "";
        for (int i = 0; i < 200; i++)
        {
            res1 += " " + bytes1[i].ToString();
        }
        Debug.Log(res1);

        for(int i = 0; i < 200; i++)
        {
            if(bytes[i] != bytes1[i])
            {
                Debug.Log(i + "   " + bytes[i] + "   " + bytes1[i]);
                break;
            }
        }

        _Bytes = bytes;

        var len = _Bytes.Length;
        var temp = new byte[len - 45];
        for (int i = 45; i < len; i++)
        {
            temp[i - 45] = _Bytes[i];
        }
        _Bytes = temp;
        string res2 = "";
        for (int i = 0; i < 200; i++)
        {
            res2 += " " + _Bytes[i].ToString();
        }
        totalIndex = 45;
        Debug.Log(res2);
        Debug.Log(System.Text.Encoding.Default.GetString(_Bytes));
        //
    }

    int startindex = 1;
    int totalIndex = 0;
    void work()
    {
        Debug.Log(++totalIndex);
        var len = _Bytes.Length;
        var temp = new byte[len - startindex];
        for(int i = startindex; i < len; i++)
        {
            temp[i - startindex] = _Bytes[i];
        }
        _Bytes = temp;

        string res1 = "";
        for (int i = 0; i < 200; i++)
        {
            res1 += " " + _Bytes[i].ToString();
        }
        Debug.Log(res1);
        Debug.Log(System.Text.Encoding.Default.GetString(_Bytes));
    }
}
