using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeDisplay : MonoBehaviour
{
    private Recipe recipe;
    
    public TextMeshPro title;
    public RecipeComponentUI[] components;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HighlightCurrentComponent()
    {

    }

    public void SetRecipe(Recipe _recipe)
    {
        recipe = _recipe;
    }

    public void DisplayRecipe()
    {
        title.text = recipe.recipeName;
        //For each item in the recipe, instantiate the icon and amount needed for it onto the recipe display
        //Disable all the recipe components initially
        foreach(RecipeComponentUI comp in components)
        {
            comp.gameObject.SetActive(false);
        }

        //Display the recipe component's icon and equation text onto the recipe display ui for the player to see
        for(int i = 0; i < recipe.components.Count; i++)
        {
            components[i].gameObject.SetActive(true);
            components[i].UpdateComponentUI(recipe.components[i].ingredient.icon, recipe.components[i].equation);
        }
    }
}
