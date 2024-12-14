using System;
using UnityEngine;

[Serializable]
public class GameParametter
{
    public string setting_name;
    
    public int nb_throws;
    
    public bool is_chat_enabled;
    public float default_chat_duration;

    public bool is_avatar_selection_enabled;
    
    public string difficulty;
    public string inclusivity_mode;
    
    public bool is_gender_question_enabled;
}