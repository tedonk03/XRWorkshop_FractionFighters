using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public string recipeName;
    //Amount required - display to player & actual amount required
    public List<RecipeComponent> components = new List<RecipeComponent>();
    public bool CheckRecipe()
    {
        //Checks against what's in the pot
        return true;
    }

    public void GenerateRecipeName()
    {
        //TODO: Create a way to randomly generate a name or grab a name from an array of names
        //TEMP CODE
        recipeName = "Magic Soup";
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
