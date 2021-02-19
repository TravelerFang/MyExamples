using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySerializeExample : MonoBehaviour
{
    void SerializeTest()
    {
        BinarySerializeTest bst = new BinarySerializeTest();
        bst.Id = 0;
        bst.Name = "make american greater again";
        bst.List = new List<int>();
        bst.List.Add(1);
        bst.List.Add(3);

        BinarySerialize(bst);
    }

    void BinaryDeSerializeTest()
    {
        TextAsset ta = UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/bst.bytes");//加载TextAsset，准备存储二进制文件
        if (ta == null)
        {
            Debug.LogError("TextAsset ta is null");
        }
        BinarySerializeTest bst =  BinaryDerialize(ta);
        Debug.Log("二进制文件中 Id is :" + bst.Id);
        Debug.Log("二进制文件中 Name is : " + bst.Name);
        foreach (int item in bst.List)
        {
            Debug.Log(item);
        }
    }
    //将C#代码进行序列化操作
    void BinarySerialize(BinarySerializeTest bst)
    {
        FileStream fs = new FileStream(Application.dataPath + "/bst.bytes",FileMode.Create,FileAccess.ReadWrite);//创建文件流
        BinaryFormatter bf = new BinaryFormatter();//创建二进制格式化器
        bf.Serialize(fs, bst);//对C#类做二进制序列化
        fs.Close();//关闭文件流
    }
    //对二进制文件进行反序列化操作
    BinarySerializeTest BinaryDerialize(TextAsset ta)
    {
        MemoryStream ms = new MemoryStream(ta.bytes);
        BinaryFormatter bf = new BinaryFormatter();
        BinarySerializeTest bst = (BinarySerializeTest)bf.Deserialize(ms);
        ms.Close();
        return bst;
    }

    private void Start()
    {
        //SerializeTest();
        BinaryDeSerializeTest();
    }
}

[Serializable]
public class BinarySerializeTest
{
    [XmlAttribute]
    public int Id { get; set; }
    [XmlAttribute]
    public string Name { get; set; }
    [XmlElement]
    public List<int> List;
}


