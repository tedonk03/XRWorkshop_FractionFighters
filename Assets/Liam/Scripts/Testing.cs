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
        recipeDisplay.HighlightCurrentComponent(theRecipe.currentIngrIndex);

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
        newRecipe.GenerateComponents(2, ingredients);
        newRecipe.GenerateRecipeName();
        theRecipe = newRecipe;
        currentComponent = 0;
    }

    public void ConfirmAnswer()
    {
        if(cauldron.CheckIngredients(theRecipe.currentIngrIndex))
        {
            //Move to next ingredient in the recipe
            if(theRecipe.currentIngrIndex + 1 < theRecipe.components.Count)
            {
                Debug.Log("Moving to next component");
                theRecipe.currentIngrIndex++;
                cauldron.ResetCauldron();
                //Next component
                recipeDisplay.HighlightCurrentComponent(theRecipe.currentIngrIndex);
            }
            else
            {
                //Recipe is complete
                Debug.Log("Recipe is done");
                NextRecipe();
            }
        }
        else
        {
            cauldron.ResetCauldron();
        }
    }

    public void NextRecipe()
    {
        GenerateRecipe();

        recipeDisplay.SetRecipe(theRecipe);
        recipeDisplay.DisplayRecipe();
        recipeDisplay.HighlightCurrentComponent(theRecipe.currentIngrIndex);

        cauldron.SetRecipe(theRecipe);
    }
}
