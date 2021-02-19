using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XmlSerializeExample : MonoBehaviour
{
    private void Start()
    {
        XmlSerializeTest(); 
        XmlDeSerializeTest();
    }

    void XmlSerializeTest()
    {
        SerializeTest  xmlSeriTest = new SerializeTest();
        xmlSeriTest.List = new List<int>();
        xmlSeriTest.Id = 1;
        xmlSeriTest.Name = "YesAmd";
        xmlSeriTest.List.Add(1);
        xmlSeriTest.List.Add(2);

        SerilizeXml(xmlSeriTest);
    }

    void XmlDeSerializeTest()
    {
        SerializeTest seriTest = XmlDeSerialize();
        Debug.LogFormat("seriTest.Id is:{0} Name is: {1} ", seriTest.Id, seriTest.Name);
        foreach (int item in seriTest.List)
        {
            Debug.Log(item);
        }
    }

    void SerilizeXml(SerializeTest seriTest)//将C#脚本用Xml序列化
    {
        FileStream fileStream = new FileStream(Application.dataPath + "/test.xml",FileMode.Create);//创建文件流
        StreamWriter sw = new StreamWriter(fileStream, System.Text.Encoding.UTF8);//创建写入流

        XmlSerializer serializer = new XmlSerializer(typeof(SerializeTest));//创建XML序列化器
        serializer.Serialize(sw,seriTest);//调用XmlSerializer API

        sw.Close();
        fileStream.Close();
    }

    SerializeTest XmlDeSerialize()
    {
        FileStream fs = new FileStream(Application.dataPath + "/test.xml",FileMode.Open);
        XmlSerializer serializer = new XmlSerializer(typeof(SerializeTest));

        SerializeTest seritest = (SerializeTest)serializer.Deserialize(fs);
        return (seritest);
    }
}

[System.Serializable]
public class SerializeTest
{
    [XmlAttribute("Id")]
    public int Id { get; set; }
    [XmlAttribute("Name")]
    public string Name { get; set; }
    [XmlElement()]
    public List<int> List;

}
