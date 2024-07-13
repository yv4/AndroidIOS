using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCallJava : MonoBehaviour
{
    private AndroidJavaClass m_JavaClass = null;
    private AndroidJavaObject m_JavaObject = null;
    public InputField LogInput;
    public Text LogText;

    // Start is called before the first frame update
    void Start()
    {
        m_JavaClass = new AndroidJavaClass("com.example.testlib.TestMyName");
        m_JavaObject = new AndroidJavaObject("com.example.testlib.TestMyName");
        AndroidJavaObject unityPlayer = new AndroidJavaObject("com.unity3d.player.UnityPlayerActivity");

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            SetStaticTestName();
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            GetStaticTestName();
        }

    }

    public void SetStaticTestName()
    {
        m_JavaClass.CallStatic("SetStaticTestName", LogInput.text);
    }

    public void GetStaticTestName()
    {
        string staticName = m_JavaClass.CallStatic<string>("GetStaticTestName");
        Debug.Log("StaticName:" + staticName);
        LogText.text = staticName;

    }

    public void SetStaticField()
    {
        m_JavaClass.SetStatic("TestStaticName", LogInput.text);
    }

    public void GetTestName()
    {
        string name = m_JavaObject.Call<string>("GetTestName", LogInput.text);
        Debug.Log("Name:" + name);
        
    }

    public void SetTestName()
    {
        m_JavaObject.Call("SetTestName", LogInput.text);
    }

    public void Test()
    {
        Debug.Log("UnityTest");
    }
}
