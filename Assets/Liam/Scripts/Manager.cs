using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Ingredient[] ingredients;
    private Recipe theRecipe;
    public RecipeDisplay recipeDisplay;
    public Cauldron cauldron;
    //public int currentComponent;
    private AudioManager audio;
    public Menu mainMenu;

    public GameObject vfxOK;
    public GameObject vfxFail;
    public GameObject vfxRecipeSuccess;
    public Transform spawnPos;


    private void Awake()
    {
        audio = FindObjectOfType<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateRecipe();
        cauldron.CauldronBubble();

        foreach (RecipeComponent c in theRecipe.components)
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

    public void OpenMainMenu()
    {
        audio.Play("click");
        mainMenu.ToggleMenu(true);
        foreach(Sound s in audio.sounds)
        {
            s.source.Stop();
        }
    }

    public void CloseMainMenu()
    {
        audio.Play("click");
        mainMenu.ToggleMenu(false);
    }

    public void QuitApplication()
    {
        audio.Play("click");
        Application.Quit();
    }

    public void StartGame()
    {
        //Delete all existing ingredients if any, reset the recipe and set starting camera angle
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Ingredient"))
        {
            Destroy(obj);
        }

        audio.Play("bgm");

        mainMenu.ToggleMenu(false);
        GenerateRecipe();
        GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = new Quaternion(0, -164f, 0, 0);
    }

    public void GenerateRecipe()
    {
        Recipe newRecipe = new Recipe();
        newRecipe.GenerateComponents(Random.Range(2, 7), ingredients);
        newRecipe.GenerateRecipeName();
        theRecipe = newRecipe;
        //currentComponent = 0;
        theRecipe.currentIngrIndex = 0;
    }

    public void ConfirmAnswer()
    {
        audio.Play("click");
        //Check if the ingredient is correct
        if (cauldron.CheckIngredients(theRecipe.currentIngrIndex))
        {
            //Move to next ingredient in the recipe
            if (theRecipe.currentIngrIndex + 1 < theRecipe.components.Count)
            {
                recipeDisplay.HideBorder(theRecipe.currentIngrIndex);
                Debug.Log("Moving to next component");
                theRecipe.currentIngrIndex++;
                cauldron.ResetCauldron();

                GameObject.Instantiate(vfxOK, spawnPos.position, Quaternion.identity);
                audio.Play("correct");
                //Next component
                recipeDisplay.HighlightCurrentComponent(theRecipe.currentIngrIndex);
            }
            else
            {
                //Recipe is complete
                GameObject.Instantiate(vfxRecipeSuccess, spawnPos.position, Quaternion.identity);
                audio.Play("success");
                Debug.Log("Recipe is done");
                NextRecipe();
            }
        }
        else
        {
            GameObject.Instantiate(vfxFail, spawnPos.position, Quaternion.identity);
            audio.Play("explosion");
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

