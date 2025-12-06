using UnityEngine;

public abstract class RecipeSO : ScriptableObject
{
    public string recipeName;
    public string description;
    public RecipeIngredient[] ingredients;
    public bool hasAlreadyBeenUsed;
    public bool isFinalRecipe;
    public PlayerEquipmentSO upgradesEquipment;
    public int upgradesToLevel;

    public abstract void Initialize();
}

[System.Serializable] // Needed for an intern class
public class RecipeIngredient
{
    public IngredientSO ingredientSO;
    public int quantity;

    // Constructor
    public RecipeIngredient(IngredientSO ingredientSO, int quantity)
    {
        this.ingredientSO = ingredientSO;
        this.quantity = quantity;
    }
}
