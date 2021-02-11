using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Ingredient[] ingredients;
    private Recipe theRecipe;
    public RecipeDisplay recipeDisplay;
    public Cauldron cauldron;
    public int currentComponent;
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
        recipeDisplay.HighlightCurrentComponent(currentComponent);

        cauldron.SetRecipe(theRecipe);
        cauldron.SetManager(this);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRecipe()
    {
        Recipe newRecipe = new Recipe();
        newRecipe.GenerateComponents(6, ingredients);
        newRecipe.GenerateRecipeName();
        theRecipe = newRecipe;
        currentComponent = 0;
    }

    public void ConfirmAnswer()
    {
        if(cauldron.CheckIngredients())
        {
            //Move to next ingredient in the recipe
            if(currentComponent < theRecipe.components.Count)
            {
                currentComponent++;
                //Next component
                recipeDisplay.HighlightCurrentComponent(currentComponent);
            }
            else
            {
                //Recipe is complete
            }
        }
    }
}
