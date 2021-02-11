using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeComponent
{
    private float[] fractionChoices = { 0.5f, 0.25f, 0.125f };

    //private Ingredient ingredients;
    public Ingredient ingredient;
    public float answer;
    public string equation;

    //Generate the equation to be displayed on the recipe display as well as the answer for it
    public void GenerateEquation()
    {
        float divider = fractionChoices[Random.Range(0, fractionChoices.Length)];

        int denominator = (int)(1 / divider);

        //TODO: Add subtraction later
        int numerator = Random.Range(1, denominator + 1);

        //TODO: Difficulty that changes types/frequency of equations to be produced
        //E.G. only use denom + numer by itself for easy and full equation for hard

        //Calculate the answer for the equation in terms of the float value of the ingredient needed
        answer = numerator * divider;

        //Set the text for the equation
        equation = numerator + " / " + denominator;
    }

    public void SetIngredient(Ingredient _ingredient)
    {
        ingredient = _ingredient;
    }
}
