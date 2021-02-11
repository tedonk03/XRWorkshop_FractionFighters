using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private Recipe currentRecipe;
    private Ingredient currentIngredient;
    private float ingredientAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCauldron()
    {
        currentRecipe = null;
        currentIngredient = null;
        ingredientAmount = 0f;
    }

    public void SetRecipe(Recipe recipe)
    {
        currentRecipe = recipe;
    }

    public bool CheckIngredients()
    {
        if(currentRecipe.components[0].ingredient.id == currentIngredient.id)
        {
            if(currentRecipe.components[0].answer == ingredientAmount)
            {
                Debug.Log("Correct amount put into the cauldron");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if the object dropped in is an ingredient
        if(other.CompareTag("Ingredient"))
        {
            Ingredient ingrt = other.GetComponent<Ingredient>();
            if(ingrt.id == currentRecipe.components[0].ingredient.id)
            {
                Debug.Log("Correct Ingredient");
                currentIngredient = ingrt;
                ingredientAmount += ingrt.fractionValue;
            }
            else
            {
                Debug.Log("Wrong ingredient! Try again!");
                currentIngredient = null;
                ingredientAmount = 0f;
            }
        }
    }


}
