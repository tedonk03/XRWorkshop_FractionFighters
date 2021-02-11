using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public string recipeName;
    //Amount required - display to player & actual amount required
    public List<RecipeComponent> components = new List<RecipeComponent>();
    public int currentIngrIndex = 0;

    public void GenerateRecipeName()
    {
        string[] foodNames = { "Slimey Soup", "Superb Stew", "Lazy Lasgna", "Bitter Bread", "Nasty Noodles" };
        recipeName = foodNames[Random.Range(0, foodNames.Length)];
    }

    public void GenerateComponents(int amount, Ingredient[] ingrList)
    {
        for(int i = 0; i < amount; i++)
        {
            RecipeComponent newComponent = new RecipeComponent();
            newComponent.GenerateEquation();
            newComponent.SetIngredient(ingrList[Random.Range(0, ingrList.Length)]); //Randomly assign an ingredient to it
            
            components.Add(newComponent);
        }
    }
}
