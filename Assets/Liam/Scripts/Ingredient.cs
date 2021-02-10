using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientID
{
    I1,
    I2,
    I3,
    I4,
    I5,
    I6
}

public class Ingredient : MonoBehaviour
{
    public const float WHOLE = 1.0f;
    public const float HALF = 0.5f;
    public const float THIRD = 0.33f;
    public const float QUARTER = 0.25f;

    public Sprite icon;
    public IngredientID id;
    public string name;

    [SerializeField]
    private float fractionValue = WHOLE;

    public void Split(float splitAmount)
    {
        fractionValue *= splitAmount;
    }
}
