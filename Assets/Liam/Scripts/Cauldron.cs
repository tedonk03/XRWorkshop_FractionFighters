using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private Recipe currentRecipe;
    private Ingredient currentIngredient;
    [SerializeField]
    private float ingredientAmount;
    private Testing test;

    //Counter to keep track of which ingredient in the recipe the player is currently trying to deal with


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

    public void SetManager(Testing _test)
    {
        test = _test;
    }

    //Could put these method inside recipe?? just parse the info from this object
    public bool CheckIngredients()
    {
        if(currentRecipe.components[0].ingredient.id == currentIngredient.id)
        {
            if(currentRecipe.components[0].answer == ingredientAmount)
            {
                Debug.Log("Correct amount put into the cauldron");
                return true;
            }
            else
            {
                Debug.Log("Incorrect amount");
                return false;
            }
        }
        else
        {
            return false;
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

            Destroy(other.gameObject);
        }
    }


}