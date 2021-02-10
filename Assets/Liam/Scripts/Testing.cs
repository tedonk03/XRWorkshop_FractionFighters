using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Ingredient[] ingredients;
    private Recipe theRecipe;
    public RecipeDisplay recipeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRecipe();
        foreach(RecipeComponent c in theRecipe.components)
        {
            Debug.Log("Ingredient: " + c.ingredient + " Equation: " + c.equation);
        }

        recipeDisplay.SetRecipe(theRecipe);
        recipeDisplay.DisplayRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRecipe()
    {
        Recipe newRecipe = new Recipe();
        newRecipe.GenerateComponents(6, ingredients);
        theRecipe = newRecipe;
    }
}
