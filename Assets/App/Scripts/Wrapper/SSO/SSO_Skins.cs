using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SSO_Skins", menuName = "SSO/SSO_Skins")]
public class SSO_Skins : ScriptableObject
{
    public List<SkinData> skinsData = new();
}

[System.Serializable]
public struct SkinData
{
    public avatar_selected enumAvatar;
    [PreviewField]public Sprite sprite;
}