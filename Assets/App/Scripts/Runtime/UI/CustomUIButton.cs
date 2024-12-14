using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class CustomUIButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip onButtonHoverClip;
    [SerializeField] private AnimationClip onButtonUnHoverClip;
    [SerializeField] private AnimationClip onButtonPressedClip;
    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    [Header("Output")]
    [SerializeField] private UnityEvent onClick;

    public void OnPointerEnter(PointerEventData data)
    {
        if (onButtonHoverClip != null) animator.Play(onButtonHoverClip.name);
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (onButtonUnHoverClip != null) animator.Play(onButtonUnHoverClip.name);
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (onButtonPressedClip != null) animator.Play(onButtonPressedClip.name);
        StartCoroutine("GenerateOnClickEvent");
    }

    private IEnumerator GenerateOnClickEvent()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        onClick?.Invoke();
    }
}