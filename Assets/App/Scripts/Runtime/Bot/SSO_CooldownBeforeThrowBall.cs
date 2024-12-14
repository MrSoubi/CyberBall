using UnityEngine;

[CreateAssetMenu(fileName = "SSO_CooldownBeforeThrowBall", menuName = "ScriptableObject/SSO_CooldownBeforeThrowBall")]
public class SSO_CooldownBeforeThrowBall : ScriptableObject
{
    public float MaxTime;
    public float MinTime;
}