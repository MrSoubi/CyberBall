using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_DictBallCount", menuName = "RSO/RSO_DictBallCount")]
public class RSO_DictBallCount : ScriptableObject
{
    public Dictionary<string, int> Value = new Dictionary<string, int>();
}