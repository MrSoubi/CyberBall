using System;
using System.IO;
using System.Text;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class FileReader : MonoBehaviour
{
    [FormerlySerializedAs("rsoGameParametter")]
    [Header("References")]
    [SerializeField] private RSO_GameParameter rsoGameParameter;
    
    [Header("Input")]
    [SerializeField] private RSE_FilePath rseFilePath;

    private void OnEnable() => rseFilePath.action += ReadFile;
    private void OnDisable() => rseFilePath.action -= ReadFile;

    [PropertySpace(10)][Button]
    private void ReadFile(string filePath)
    {
        Debug.Log(filePath);
        Debug.Log(filePath.Length);
        Encoding encoding = Encoding.GetEncoding(28591);
        print(System.IO.File.Exists(filePath));
        string infoData = System.IO.File.ReadAllText(filePath);
        var classe =JsonUtility.FromJson<GameParameter>(infoData);
        classe.is_avatar_selection_enabled = true;
        rsoGameParameter.Value = classe;
        print(rsoGameParameter.Value.nb_throws);
    }
}