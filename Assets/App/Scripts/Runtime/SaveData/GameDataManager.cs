using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using SFB;

public class GameDataManager : MonoBehaviour
{
    public List<GameAction> actions = new List<GameAction>();
    string exportData;

    [Header("Intput")]
    [SerializeField] RSE_ExportDataToCsv rseExportData;
    [SerializeField] RSE_AddGameAction rseAddGameAction;

    [Space(5)]
    [SerializeField] RSE_SetupPlayerID rseSetupPlayerID;
    [SerializeField] RSE_SetupPlayerGender RSE_SetupPlayerGender;
    string playerId;
    PlayerGender playerGender;

    private void OnEnable()
    {
        rseExportData.action += ExportToCsv;
        rseAddGameAction.action += AddGameAction;
    }
    private void OnDisable()
    {
        rseExportData.action -= ExportToCsv;
        rseAddGameAction.action -= AddGameAction;
    }

    void AddGameAction(GameAction action)
    {
        action.playerID = playerId;
        action.gender = playerGender;
        actions.Add(action);
    }

    #region ExportToCsv
    public void ExportToCsv()
    {
        if (actions.Count <= 0) return;

        exportData += GetClassVarName(actions[0]) + "\n";

        for (int i = 0; i < actions.Count; i++)
        {
            exportData += GetClassVarvalue(actions[i]) + "\n";
        }

        WriteStringToCSV(exportData, StandaloneFileBrowser.SaveFilePanel("Save File", "", "DataSaved", "csv"));
    }

    void WriteStringToCSV(string content, string filePath)
    {
        try
        {
            // V�rifie si le r�pertoire existe et le cr�e si n�cessaire
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // �crit le texte dans le fichier
            File.WriteAllText(filePath, content);

            Debug.Log($"Fichier �crit avec succ�s � : {filePath}");
        }
        catch (UnauthorizedAccessException)
        {
            Debug.LogError("Acc�s non autoris�. V�rifiez les permissions pour le chemin : " + filePath);
        }
        catch (DirectoryNotFoundException)
        {
            Debug.LogError("R�pertoire introuvable : " + filePath);
        }
        catch (IOException e)
        {
            Debug.LogError("Erreur d'�criture de fichier : " + e.Message);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erreur inattendue : " + e.Message);
        }
    }
    #endregion

    #region GetClassReferences
    public string GetClassVarName(object target)
    {
        string result = "";

        // Get all variables in the class
        Type type = target.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        for (int i = 0; i < fields.Length; i++)
        {
            // Get current value & convert to string
            object value = fields[i].GetValue(target);
            string stringValue = value != null ? value.ToString() : "null";

            // Afficher ou utiliser la valeur convertie
            result = result + (i == 0 ? fields[i].Name : ";" + fields[i].Name);
        }

        return result;
    }
    public string GetClassVarvalue(object target)
    {
        string result = "";

        // Get all variables in the class
        Type type = target.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        for (int i = 0; i < fields.Length; i++)
        {
            // Get current value & convert to string
            object value = fields[i].GetValue(target);
            string stringValue = value != null ? value.ToString() : "";

            // Afficher ou utiliser la valeur convertie
            result = result + (i == 0 ? stringValue : ";" + stringValue);
        }

        return result;
    }
    #endregion
}