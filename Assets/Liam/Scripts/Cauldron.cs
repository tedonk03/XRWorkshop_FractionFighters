using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private Recipe currentRecipe;
    private Ingredient currentIngredient;
    [SerializeField]
    private float ingredientAmount;
    private Manager manager;

    public void CauldronBubble()
    {
        FindObjectOfType<AudioManager>().Play("bubbling");
    }

    public void ResetCauldron()
    {
        //currentRecipe = null;
        currentIngredient = null;
        ingredientAmount = 0f;
    }

    public void SetRecipe(Recipe recipe)
    {
        currentRecipe = recipe;
    }

    public void SetManager(Manager _manager)
    {
        manager = _manager;
    }

    //Could put these method inside recipe?? just parse the info from this object
    public bool CheckIngredients(int currentComponentIndex)
    {
        if(currentRecipe.components[currentComponentIndex].ingredient.id == currentIngredient.id)
        {
            if(currentRecipe.components[currentComponentIndex].answer == ingredientAmount)
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
            if(ingrt.id == currentRecipe.components[currentRecipe.currentIngrIndex].ingredient.id)
            {
                FindObjectOfType<AudioManager>().Play("explosion");
                Debug.Log("Correct Ingredient");
                currentIngredient = ingrt;
                ingredientAmount += ingrt.fractionValue;
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("fail");
                Debug.Log("Wrong ingredient! Try again!");
                currentIngredient = null;
                ingredientAmount = 0f;
            }

            Destroy(other.gameObject);
        }
    }


}
