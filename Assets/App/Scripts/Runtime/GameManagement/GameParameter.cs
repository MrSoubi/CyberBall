using System;

[Serializable]
public class GameParameter
{
    public int nb_throws;
    
    public bool is_chat_enabled;
    public float default_chat_duration;

    public bool is_avatar_selection_enabled;
    public avatar avatar_selection;
    
    public difficulty_mode difficulty;
    public inclusivity_mode inclusivity;
    
    public bool is_gender_question_enabled;
    
    public Comment[] comments;
}

[Serializable]
public enum avatar
{
    HOMME1,
    HOMME2,
    HOMME3,
    HOMME4,
    FEMME1,
    FEMME2,
    FEMME3,
    FEMME4,
    HOMMEHYPERSEXUALISE1,
    HOMMEHYPERSEXUALISE2,
    HOMMEHYPERSEXUALISE3,
    HOMMEHYPERSEXUALISE4,
    FEMMEHYPERSEXUALISE1,
    FEMMEHYPERSEXUALISE2,
    FEMMEHYPERSEXUALISE3,
    FEMMEHYPERSEXUALISE4
}

[Serializable]
public enum inclusivity_mode
{
    INCLUSIF, 
    EXCLUSIF
}

[Serializable]
public enum difficulty_mode
{
    NORMAL, 
    HARD
}