using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSerializeExample : MonoBehaviour
{
    void ReadAsset()
    {
        AssetSeriTest ast = UnityEditor.AssetDatabase.LoadAssetAtPath<AssetSeriTest>("Assets/TestAsset.asset");
        if (ast == null)
        {
            Debug.LogError("AssetSeriTest ast is not exist");
        }
        Debug.Log(ast.Id);
        Debug.Log(ast.name);
        foreach (int item in ast.List)
        {
            Debug.Log(item);
        }
    }

    private void Start()
    {
        ReadAsset();
    }
}

[CreateAssetMenu(fileName ="TestAsset",menuName ="CreateTestAsset",order =0)]
public class AssetSeriTest : ScriptableObject
{
    public int Id;
    public string Name;
    public List<int> List = new List<int>();
}
