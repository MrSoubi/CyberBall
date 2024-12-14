using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class CustomUIButton : MonoBehaviour, IPointerDownHandler
{
    [Header("Settings")]
    [SerializeField] private RectTransform swayObject;
    [SerializeField] private CanvasGroup normal;
    [SerializeField] private CanvasGroup pressed;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip clip;

    //[Header("References")]

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    [Header("Output")]
    [SerializeField] private UnityEvent onClick;

    private void Awake()
    {
        if(normal != null) normal.alpha = 1.0f;
        if(pressed != null) pressed.alpha = 0.0f;
    }

    public void OnPointerDown(PointerEventData data)
    {
        onClick?.Invoke();
    }
}