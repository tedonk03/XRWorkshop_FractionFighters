using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    //List or hashmap of ingredients?
    //Amount required - display to player & actual amount required
    public List<RecipeComponent> components = new List<RecipeComponent>();
    public bool CheckRecipe()
    {
        //Checks against what's in the pot
        return true;
    }

    public void GenerateComponents(int amount, Ingredient[] ingrList)
    {
        for(int i = 0; i < amount; i++)
        {
            RecipeComponent newComponent = new RecipeComponent();
            newComponent.GenerateEquation();
            newComponent.SetIngredient(ingrList[Random.Range(0, ingrList.Length - 1)]); //Randomly assign an ingredient to it
            
            components.Add(newComponent);
        }
    }
}
