using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateCusomTile : Editor
{
    [MenuItem("ScriptableObjectTest/Create")]
    public static void Create()
    {
        // ScriptableObject.CreateInstance()でインスタンスを生成
        // この時点ではアセット化はされていない
        var asset = CreateInstance<CustomTile>();

        // アセット化するにはAssetDatabase.CreateAsset()
        // 拡張子は必ず.assetとする
        AssetDatabase.CreateAsset(asset, "Assets/customtile.asset");
        AssetDatabase.Refresh();
    }

}
