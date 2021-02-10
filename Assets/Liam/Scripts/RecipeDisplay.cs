using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeDisplay : MonoBehaviour
{
    private Recipe recipe;
    public Image displaySpot; //Not an image but is that expandable scroll thingy
    public TextMeshPro title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetRecipe(Recipe _recipe)
    {
        recipe = _recipe;
    }

    public void DisplayRecipe()
    {
        //For each item in the recipe, instantiate the icon and amount needed for it onto the recipe display
    }
}
