using UnityEngine;

public class RecipeBookGameManager : MonoBehaviour
{
    // Allow to call RecipeBookGameManager.Instance anywhere (singleton)
    public static RecipeBookGameManager Instance { get; private set; }

    // Attributes
    [SerializeField] private GameObject recipeIngredientLineUIPrefab;

    // READ-ONLY ATTRIBUTES
    public GameObject RecipeIngredientLineUIPrefab => recipeIngredientLineUIPrefab;

    // Internal attributes
    private int currentPageIndex = 0; // Index of the actual left page
    private Recipe currentLeftRecipe;
    private bool isCurrentLeftRecipeAvailable;
    private Recipe currentRightRecipe;
    private bool isCurrentRightRecipeAvailable;

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

    private void Start()
    {
        UpdateCurrentRecipes();
        UpdateUI();
    }

    public void OnMakeRecipeLeftButtonPressed()
    {
        MakeRecipe(currentLeftRecipe);
        UpdateCurrentRecipes();
        UpdateUI();
    }

    public void OnMakeRecipeRightButtonPressed()
    {
        MakeRecipe(currentRightRecipe);
        UpdateCurrentRecipes();
        UpdateUI();
    }

    public void OnPreviousButtonPressed()
    {
        currentPageIndex -= 2;
        UpdateCurrentRecipes();
        UpdateUI();
    }

    public void OnNextButtonPressed()
    {
        currentPageIndex += 2;
        UpdateCurrentRecipes();
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Previous button
        if (currentPageIndex > 0) { RecipeBookUIManager.Instance.ShowPreviousButton(); }
        else { RecipeBookUIManager.Instance.HidePreviousButton(); }

        // Next button
        if (currentPageIndex + 2 < RecipeManager.Instance.Recipes.Length) { RecipeBookUIManager.Instance.ShowNextButton(); }
        else { RecipeBookUIManager.Instance.HideNextButton(); }


        // Recipe page
        RecipeBookUIManager.Instance.UpdateLeftPageUI(currentLeftRecipe);
        RecipeBookUIManager.Instance.UpdateRightPageUI(currentRightRecipe);

        // Make Recipe button left
        if (currentLeftRecipe != null)
        {
            if (isCurrentLeftRecipeAvailable)
            {
                RecipeBookUIManager.Instance.MakeRecipeLeftButtonInteractive();
            }
            else
            {
                RecipeBookUIManager.Instance.MakeRecipeLeftButtonNotInteractive();
            }
        }

        // Make Recipe button right
        if (currentRightRecipe != null)
        {
            if (isCurrentRightRecipeAvailable)
            {
                RecipeBookUIManager.Instance.MakeRecipeRightButtonInteractive();
            }
            else
            {
                RecipeBookUIManager.Instance.MakeRecipeRightButtonNotInteractive();
            }
        }
    }

    // Find current recipes
    private void UpdateCurrentRecipes()
    {
        currentLeftRecipe = null;
        isCurrentLeftRecipeAvailable = false;
        currentRightRecipe = null;
        isCurrentRightRecipeAvailable = false;

        if (RecipeManager.Instance.Recipes.Length > currentPageIndex)
        {
            currentLeftRecipe = RecipeManager.Instance.Recipes[currentPageIndex];
            isCurrentLeftRecipeAvailable = checkRecipeAvailable(currentLeftRecipe);
        }

        if (RecipeManager.Instance.Recipes.Length > currentPageIndex + 1)
        {
            currentRightRecipe = RecipeManager.Instance.Recipes[currentPageIndex + 1];
            isCurrentRightRecipeAvailable = checkRecipeAvailable(currentRightRecipe);
        }
    }

    // Check if the player has enough ingredients for a recipe and if the recipe has not been already used
    private bool checkRecipeAvailable(Recipe recipe)
    {
        if (recipe.hasAlreadyBeenUsed) { return false; }
        foreach (var recipeIngredient in recipe.ingredients)
        {
            if (InventoryManager.Instance.IngredientsPossessed[recipeIngredient.ingredientSO.ingredient] < recipeIngredient.quantity)
            {
                return false;
            }
        }
        return true;
    }

    // Update inventory according to the recipe
    private void MakeRecipe(Recipe recipe)
    {
        if (recipe.isFinalRecipe)
        {
            GameManager.Instance.EnterEndEvent();
        }
        else
        {
            // Remove player ingredients
            foreach (var recipeIngredient in recipe.ingredients)
            {
                InventoryManager.Instance.IngredientsPossessed[recipeIngredient.ingredientSO.ingredient] -= recipeIngredient.quantity;
            }

            // Upgrade equipment
            InventoryManager.Instance.EquipmentLevel[recipe.upgradesEquipment] = recipe.upgradesToLevel;

            // Recipe used
            recipe.hasAlreadyBeenUsed = true;
        }
    }
}
