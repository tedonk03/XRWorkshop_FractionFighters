using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientID
{
    APPLE,
    PUMPKIN,
    BUTTER,
    CHEESE,
}

public class Ingredient : MonoBehaviour
{
    public const float WHOLE = 1.0f;
    public const float HALF = 0.5f;
    public const float THIRD = 0.33f;
    public const float QUARTER = 0.25f;

    public Material icon;
    public IngredientID id;
    public string name;

    public float fractionValue = WHOLE;

    //public void Split(float splitAmount)
    //{
    //    fractionValue *= splitAmount;
    //}
}
