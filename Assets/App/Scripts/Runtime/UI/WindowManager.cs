using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WindowManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private List<WindowItem> windows = new List<WindowItem>();

    [Header("References")]
    [SerializeField] private RSE_OpenPanel rseOpenPanel;
    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    public int currentWindowIndex = 0;
    private int newWindowIndex;

    private WindowItem currentWindow;
    private WindowItem nextWindow;

    [System.Serializable]
    public class WindowItem
    {
        public string windowName = "New Window";
        public GameObject windowObject;
        //public WindowAnimator windowAnimator;
    }

    private void OnEnable() => rseOpenPanel.action += OpenPanel;
    private void OnDisable() => rseOpenPanel.action -= OpenPanel;

    void Awake()
    {
        if (windows.Count == 0)
            return;

        InitializeWindows();
    }

    public void InitializeWindows()
    {
        for (int i = 0; i < windows.Count; i++)
        {
            if (i != currentWindowIndex)
            {
                windows[i].windowObject.SetActive(false);
            }
        }
    }

    public void OpenWindow(string newWindow)
    {
        for (int i = 0; i < windows.Count; i++)
        {
            if (windows[i].windowName == newWindow)
            {
                newWindowIndex = i;
                break;
            }
        }

        if (newWindowIndex != currentWindowIndex)
        {
            StopCoroutine("DisablePreviousWindow");

            currentWindow = windows[currentWindowIndex];

            currentWindowIndex = newWindowIndex;
            nextWindow = windows[currentWindowIndex];
            nextWindow.windowObject.SetActive(true);

            //if (currentWindow.windowAnimator != null) currentWindow.windowAnimator.WindowFadeOut();
            //if (nextWindow.windowAnimator != null) nextWindow.windowAnimator.WindowFadeIn();

            StartCoroutine("DisablePreviousWindow");
        }
    }

    public void OpenPanel(string newPanel)
    {
        OpenWindow(newPanel);
    }

    IEnumerator DisablePreviousWindow()
    {
        yield return new WaitForSecondsRealtime(0);

        for (int i = 0; i < windows.Count; i++)
        {
            if (i == currentWindowIndex)
                continue;

            windows[i].windowObject.SetActive(false);
        }
    }
}