using UnityEngine;

public class InventoryViewGameManager : MonoBehaviour
{
    // Allow to call InventoryViewGameManager.Instance anywhere (singleton)
    public static InventoryViewGameManager Instance { get; private set; }

    // Internal states
    private enum InventoryViewGameState
    {
        Inventory,
        RecipeBook
    }
    private InventoryViewGameState currentState;

    // Make this class a singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        // First state
        ChangeState(InventoryViewGameState.Inventory);
    }

    // Exit inventory
    public void OnGoBackButtonPressed()
    {
        GameManager.Instance.ExitInventory();
    }

    // Pass from one state to another
    private void ChangeState(InventoryViewGameState newState)
    {
        // Exit logic for the previous state
        OnStateExit(currentState);

        currentState = newState;

        // Enter logic for the new state
        OnStateEnter(currentState);
    }

    // Handle the game logic when entering states
    private void OnStateEnter(InventoryViewGameState state)
    {
        switch (state)
        {
            case InventoryViewGameState.Inventory:
                Debug.Log("Entering Inventory state");
                UpdateInventoryUI();
                InventoryViewUIManager.Instance.ShowInventoryStateUI();
                break;

            case InventoryViewGameState.RecipeBook:
                Debug.Log("Entering Recipe Book state");
                InventoryViewUIManager.Instance.ShowRecipeBookStateUI();
                break;
        }
    }

    // Handle the game logic when exiting states
    private void OnStateExit(InventoryViewGameState state)
    {
        switch (state)
        {
            case InventoryViewGameState.Inventory:
                Debug.Log("Exiting Inventory state");
                InventoryViewUIManager.Instance.HideInventoryStateUI();
                break;

            case InventoryViewGameState.RecipeBook:
                Debug.Log("Exiting Recipe Book state");
                InventoryViewUIManager.Instance.HideRecipeBookStateUI();
                break;
        }
    }

    private void UpdateInventoryUI()
    {
        // Update the recipe book button UI
        InventoryViewUIManager.Instance.UpdateRecipeBookButtonUI(GameManager.Instance.IsRecipeBookUnlocked);

        // Update the equipment UI
        int fishingRodLevel = InventoryManager.Instance.EquipmentLevel[PlayerEquipment.FishingRod];
        int boatLevel = InventoryManager.Instance.EquipmentLevel[PlayerEquipment.Boat];
        int flashinglightLevel = InventoryManager.Instance.EquipmentLevel[PlayerEquipment.Flashlight];
        InventoryViewUIManager.Instance.UpdateFishingRodUI(fishingRodLevel);
        InventoryViewUIManager.Instance.UpdateBoatUI(boatLevel);
        InventoryViewUIManager.Instance.UpdateFlashlightUI(flashinglightLevel);

        // Update the ingredients UI
        int ingredientOneCount = InventoryManager.Instance.IngredientsPossessed[Ingredient.CarpMeat];
        int ingredientTwoCount = InventoryManager.Instance.IngredientsPossessed[Ingredient.CarpTooth];
        int ingredientThreeCount = InventoryManager.Instance.IngredientsPossessed[Ingredient.TroutMeat];
        int ingredientFourCount = InventoryManager.Instance.IngredientsPossessed[Ingredient.ShinyFin];
        int ingredientFiveCount = InventoryManager.Instance.IngredientsPossessed[Ingredient.GlimmeringScale];
        int ingredientSixCount = InventoryManager.Instance.IngredientsPossessed[Ingredient.ShadowyEye];
        int ingredientSevenCount = InventoryManager.Instance.IngredientsPossessed[Ingredient.MysticEssence];
        InventoryViewUIManager.Instance.UpdateIngredientOneUI(ingredientOneCount);
        InventoryViewUIManager.Instance.UpdateIngredientTwoUI(ingredientTwoCount);
        InventoryViewUIManager.Instance.UpdateIngredientThreeUI(ingredientThreeCount);
        InventoryViewUIManager.Instance.UpdateIngredientFourUI(ingredientFourCount);
        InventoryViewUIManager.Instance.UpdateIngredientFiveUI(ingredientFiveCount);
        InventoryViewUIManager.Instance.UpdateIngredientSixUI(ingredientSixCount);
        InventoryViewUIManager.Instance.UpdateIngredientSevenUI(ingredientSevenCount);
    }
}
