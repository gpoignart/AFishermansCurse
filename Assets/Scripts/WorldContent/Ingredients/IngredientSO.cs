using UnityEngine;

public abstract class IngredientSO : ScriptableObject
{
    public string ingredientName;
    public int playerQuantityPossessed;
    public Sprite sprite;
    public Color color;

    public abstract void Initialize();
}
