using UnityEngine;

public abstract class TransitionSO : ScriptableObject
{
    public Sprite backgroundSprite;
    public string text;
    public float duration;

    public abstract void Initialize();
}
