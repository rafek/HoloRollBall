using System.IO;
using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetsBundles()
    {
        string assetBundledirectory = "Assets/AssetBundles";
        
        if (!Directory.Exists(assetBundledirectory))
        {
            Directory.CreateDirectory(assetBundledirectory);
        }

        BuildPipeline.BuildAssetBundles(assetBundledirectory, BuildAssetBundleOptions.None, BuildTarget.WSAPlayer);
    }
}
