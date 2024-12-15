using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class LoadingWindow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float loadingDuration;
    //[Header("References")]

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    [SerializeField] private UnityEvent onLoadingCompleted;

    private void OnEnable()
    {
        StartCoroutine("LoadingScreen");
        Debug.Log("Loading Start");
    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(loadingDuration);
        Debug.Log("Loading Completed");
        onLoadingCompleted?.Invoke();
    }
}