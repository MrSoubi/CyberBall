using SFB;
using UnityEngine;
public class ProfileManager : MonoBehaviour
{
    public struct ExtensionFilter
    {
        public string Name;
        public string[] Extensions;

        public ExtensionFilter(string filterName, params string[] filterExtensions)
        {
            Name = filterName;
            Extensions = filterExtensions;
        }
    }

    //[Header("Settings")]

    //[Header("References")]

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    public void OpenFile()
    {
        StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
    }

    private string[] OpenFile(string title, string extension)
    {
        var extensions = string.IsNullOrEmpty(extension) ? null : new[] { new ExtensionFilter("", extension) };
        return OpenFile(title, extension);
    }
}