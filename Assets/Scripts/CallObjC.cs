using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CallObjC : MonoBehaviour
{
#if UNITY_IPHONE
    [DllImport("__Internal")]
    static extern void IOSLog(string message);
#endif

    public void OnButtonClick()
    {
        IOSLog("ABC");
    }
}
