using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

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
        print(System.IO.File.Exists(filePath));
        string infoData = System.IO.File.ReadAllText(filePath);
        rsoGameParameter.Value = JsonUtility.FromJson<GameParameter>(infoData);
        print(rsoGameParameter.Value.nb_throws);
    }
}