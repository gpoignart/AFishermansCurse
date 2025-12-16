using System.Collections.Generic;

public class SaveData
{
    public string currentTimeOfDayName;
    public int daysCount;
    public int nightsCount;
    public bool isFirstDay;
    public bool isFirstNight;
    public bool isFishingTutorialEnabled;
    public bool isMapSelectionExplanationEnabled;
    public bool isRecipeBookUnlocked;
    public List<IngredientSaveData> ingredients = new();
    public List<PlayerEquipmentSaveData> playerEquipments = new();
    public List<RecipeSaveData> recipes = new();
}

public class IngredientSaveData
{
    public string ingredientName;
    public int playerQuantityPossessed;
}

public class PlayerEquipmentSaveData
{
    public string playerEquipmentName;
    public int level;
}

public class RecipeSaveData
{
    public string recipeName;
    public bool hasAlreadyBeenUsed;
}
