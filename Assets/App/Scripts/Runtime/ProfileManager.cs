using SFB;
using UnityEngine;
using UnityEngine.Events;
public class ProfileManager : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] private RSE_FilePath rseFilePath;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    [Header("Output")]
    [SerializeField] private UnityEvent onProfileSelectedAndValid;

    private string _path;

    public void OpenFile()
    {
        string result = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        if(result != null)
        {
            rseFilePath.Call(result);
            onProfileSelectedAndValid?.Invoke();
        }
    }

    public string WriteResult(string[] paths)
    {
        string path = "";

        if (paths.Length == 0)
        {
            return null;
        }

        foreach(var p in paths)
        {
            path += p + "\n";
        }

        path = path.Remove(path.Length - 1);

        return path;
    }
}