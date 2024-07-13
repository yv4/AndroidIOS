using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;
using UnityEngine.Android;

public class TestPermission : MonoBehaviour
{
    //��Ŀ������ɺ����
    [PostProcessBuild]
    private static void OnBuildFinish(BuildTarget buildTarget,string buildPath)
    {
#if UNITY_IPHONE
        SetXcodePermission(buildPath);
#endif
    }


    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void TestPermissionFun()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetXcodePermission(string buildPath)
    {
        PBXProject project = new PBXProject();
        project.ReadFromString(File.ReadAllText(PBXProject.GetPBXProjectPath(buildPath)));

        string targetGuid = project.GetUnityFrameworkTargetGuid(); 
        //���һ����
        project.AddFrameworkToProject(targetGuid,"AVKit.framework",false);
        //���Ȩ��
        PlistDocument plist = new PlistDocument();
        string path = Path.Combine(buildPath, "Info.plist");
        plist.ReadFromString(path);
        plist.root.SetString("", "");
        plist.WriteToFile(Path.Combine("", ""));

        //project.WriteToString(PBXProject.GetPBXProjectPath(buildPath));
    }
}
