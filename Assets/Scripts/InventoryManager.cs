using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    // Allow to call InventoryManager.Instance anywhere (singleton)
    public static InventoryManager Instance { get; private set; }

    // Internal attributes
    private Dictionary<PlayerEquipment, int> equipmentLevel = new Dictionary<PlayerEquipment, int>();
    private Dictionary<Ingredient, int> ingredientsPossessed = new Dictionary<Ingredient, int>();

    // READ-ONLY ATTRIBUTES, CAN READ THEM ANYWHERE
    public Dictionary<PlayerEquipment, int> EquipmentLevel => equipmentLevel;
    public Dictionary<Ingredient, int> IngredientsPossessed => ingredientsPossessed;

    // Make this class a singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Keep the game context active for all scenes
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Initialize attributes
        foreach (PlayerEquipment equipment in System.Enum.GetValues(typeof(PlayerEquipment)))
        {
            equipmentLevel[equipment] = 1;
        };

        foreach (Ingredient ingredient in System.Enum.GetValues(typeof(Ingredient)))
        {
            ingredientsPossessed[ingredient] = 1;
        };
    }

    // Add ingredient to inventory
    public void AddIngredient(Ingredient ingredient, int amount)
    {
       Debug.Log("Add ingredient");
       ingredientsPossessed[ingredient] += amount;
    }

    // Remove ingredient from inventory, return true if possible, false otherwise
    public bool RemoveIngredient(Ingredient ingredient, int amount)
    {
        if (ingredientsPossessed[ingredient] < amount)
        {
            return false;
        }

        ingredientsPossessed[ingredient] -= amount;
        return true;
    }

    // Upgrade equipment
    public void UpgradeEquipment(PlayerEquipment equipment)
    {
        equipmentLevel[equipment] ++;
    }
}
