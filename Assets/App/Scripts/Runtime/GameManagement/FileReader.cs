using System;
using Sirenix.OdinInspector;
using UnityEngine;
public class FileReader : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RSO_GameParametter rsoGameParametter;
    
    [Header("Input")]
    [SerializeField] private RSE_FilePath rseFilePath;

    private void OnEnable() => rseFilePath.action += ReadFile;
    private void OnDisable() => rseFilePath.action -= ReadFile;

    [PropertySpace(10)][Button]
    private void ReadFile(string filePath)
    {
        string infoData = System.IO.File.ReadAllText(filePath);
        rsoGameParametter.Value = JsonUtility.FromJson<GameParametter>(infoData);
    }
}