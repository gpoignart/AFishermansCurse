using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    // Allow to call RecipeManager.Instance anywhere (singleton)
    public static RecipeManager Instance { get; private set; }

    [SerializeField] private Recipe[] recipes;

    // READ-ONLY ATTRIBUTES
    public Recipe[] Recipes => recipes;

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

    private void Start()
    {
        InitializeRecipes();
    }

    private void InitializeRecipes()
    {
        recipes = new Recipe[]
        {
            new Recipe
            {
                name = "Carp Skillet",
                description = "Upgrades Fishing Rod to level 2.",
                ingredients = new RecipeIngredient[]
                {
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[0], quantity = 10 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[1], quantity = 10 }
                },
                hasAlreadyBeenUsed = false,
                isFinalRecipe = false,
                upgradesEquipment = PlayerEquipment.FishingRod,
                upgradesToLevel = 2
            },

            new Recipe
            {
                name = "Trout Skillet",
                description = "Upgrades Flashlight to level 2.",
                ingredients = new RecipeIngredient[]
                {
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[2], quantity = 10 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[3], quantity = 10 }
                },
                hasAlreadyBeenUsed = false,
                isFinalRecipe = false,
                upgradesEquipment = PlayerEquipment.Flashlight,
                upgradesToLevel = 2
            },

            new Recipe
            {
                name = "Fisherman’s Mix",
                description = "Upgrades Boat to level 2.",
                ingredients = new RecipeIngredient[]
                {
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[0], quantity = 5 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[1], quantity = 5 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[2], quantity = 5 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[3], quantity = 5 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[4], quantity = 1 }
                },
                hasAlreadyBeenUsed = false,
                isFinalRecipe = false,
                upgradesEquipment = PlayerEquipment.Boat,
                upgradesToLevel = 2
            },

            new Recipe
            {
                name = "Golden Carp Fillet",
                description = "Upgrades Fishing Rod to level 3.",
                ingredients = new RecipeIngredient[]
                {
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[0], quantity = 10 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[1], quantity = 10 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[4], quantity = 5 }
                },
                hasAlreadyBeenUsed = false,
                isFinalRecipe = false,
                upgradesEquipment = PlayerEquipment.FishingRod,
                upgradesToLevel = 3
            },

            new Recipe
            {
                name = "Golden Trout Fillet",
                description = "Upgrades Flashlight to level 3.",
                ingredients = new RecipeIngredient[]
                {
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[2], quantity = 10 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[3], quantity = 10 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[4], quantity = 5 }
                },
                hasAlreadyBeenUsed = false,
                isFinalRecipe = false,
                upgradesEquipment = PlayerEquipment.Flashlight,
                upgradesToLevel = 3
            },

            new Recipe
            {
                name = "Catfish Night Stew",
                description = "Upgrades Boat to level 3.",
                ingredients = new RecipeIngredient[]
                {
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[0], quantity = 5 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[1], quantity = 5 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[2], quantity = 5 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[3], quantity = 5 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[5], quantity = 3 }
                },
                hasAlreadyBeenUsed = false,
                isFinalRecipe = false,
                upgradesEquipment = PlayerEquipment.Boat,
                upgradesToLevel = 3
            },

            new Recipe
            {
                name = "Elixir of the Cursed",
                description = "Heals any curse.",
                ingredients = new RecipeIngredient[]
                {
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[4], quantity = 10 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[5], quantity = 5 },
                    new RecipeIngredient { ingredientSO = GameManager.Instance.IngredientSOs[6], quantity = 3 }
                },
                hasAlreadyBeenUsed = false,
                isFinalRecipe = true
            }
        };
    }
}

[System.Serializable]
public class Recipe
{
    public string name;
    public string description;
    public RecipeIngredient[] ingredients;

    public bool hasAlreadyBeenUsed;

    public bool isFinalRecipe;

    // Upgrade equipment
    public PlayerEquipment upgradesEquipment;
    public int upgradesToLevel;
}

[System.Serializable]
public class RecipeIngredient
{
    public IngredientSO ingredientSO;
    public int quantity;
}
