using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UnpackSinespace
{
    [InitializeOnLoadMethod]
    static void CheckForUnpack()
    {
        PerformVersionUnpack(false);
    }

    private enum UnityVersion
    {
        Unknown,
        v2017_2,
        v2017_3,
        v2017_4,
        v2018_1,
        v2018_2,
        v2018_3,
        v2018_4,
        v2019_1,
        v2019_2
    };

    [MenuItem("Sinespace/Unpack Editor Pack...", priority = 999)]
    static void PerformVersionUnpackMenu()
    {
        PerformVersionUnpack(true);
    }

    static void PerformVersionUnpack(bool force)
    {
        if (Directory.Exists("Assets/SpacePack") && !force) // this is useful for fresh installs only
            return;

        var version = Application.unityVersion;

        UnityVersion ver;
        if (version.StartsWith("2017.2."))
            ver = UnityVersion.v2017_2;
        else if (version.StartsWith("2017.3."))
            ver = UnityVersion.v2017_3;
        else if (version.StartsWith("2017.4."))
            ver = UnityVersion.v2017_4;
        else if (version.StartsWith("2018.1."))
            ver = UnityVersion.v2018_1;
        else if (version.StartsWith("2018.2."))
            ver = UnityVersion.v2018_2;
        else if (version.StartsWith("2018.3."))
            ver = UnityVersion.v2018_3;
        else if (version.StartsWith("2018.4."))
            ver = UnityVersion.v2018_4;
        else if (version.StartsWith("2019.1."))
            ver = UnityVersion.v2019_1;
        else ver = UnityVersion.Unknown;

        if(ver==UnityVersion.Unknown)
            return;

        if (!force && System.DateTime.Parse(EditorPrefs.GetString("sinespace.next_install_remind", new DateTime(2000, 1, 1, 1, 1, 1).ToString("R"))) 
			    > System.DateTime.Parse(DateTime.Now.ToUniversalTime().ToString("R")))
            return;

        var item = EditorUtility.DisplayDialog("Do you wish to unpack the sinespace editor pack?",
            "This will install the Editor Pack for Unity " + ver.ToString(), "Install Editor Pack", "Not Now");

        if (!item)
        {
            EditorPrefs.SetString("sinespace.next_install_remind",
                (DateTime.Now.ToUniversalTime() + TimeSpan.FromMinutes(5)).ToString("R"));
            return;
        }

#if UNITY_2017_3_OR_NEWER
        // Fun fact: Unity does not automatically add these to a new project. :|
        UnityEditor.PackageManager.Client.Add("Physics");
        UnityEditor.PackageManager.Client.Add("XR");
        UnityEditor.PackageManager.Client.Add("VR");
#endif

        string packageName = "";

        switch (ver)
        {
            default:
            case UnityVersion.Unknown:
                EditorUtility.DisplayDialog("Unsupported Version",
                    "This version of Unity is not supported by the Sinespace Editor Pack", "OK");
                return;
            case UnityVersion.v2017_2:
                packageName = "2017.2.";
                break;
            case UnityVersion.v2017_4:
            case UnityVersion.v2017_3:
                packageName = "2017.3.";
                break;
            case UnityVersion.v2018_1:
                packageName = "2018.1.";
                break;
            case UnityVersion.v2018_2:
                packageName = "2018.2.";
                break;
            case UnityVersion.v2018_3:
            case UnityVersion.v2018_4:
                packageName = "2018.3.";
                break;
        }

        if (packageName == "")
        {
            EditorUtility.DisplayDialog("Unable to find a package",
                "Was not able to find a matching package file for Unity " + packageName + "x", "OK");
            Debug.Log("Could not find the correct package, aborting!");
            return;
        }

        var packages = Directory.GetFiles("Assets/Sinespace", "*.unitypackage");
        
        foreach (var package in packages)
        {
            if (package.Contains(packageName))
            {
                AssetDatabase.ImportPackage(package, true);
                return;
            }
        }

        EditorUtility.DisplayDialog("Package is missing",
            "The associated Sinespace Editor Package for this version could not be found.", "OK");
    }
}
