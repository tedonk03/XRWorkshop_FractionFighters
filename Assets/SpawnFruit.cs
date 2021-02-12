using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public GameObject fruitPrefab;
    public Transform spawnPos;
    public IngredientID ingredientType;

    private void OnMouseDown()
    {
        Spawn();
    }

    public void Spawn()
    {
        // destroy all existing one

        var fruits = GameObject.FindGameObjectsWithTag("Ingredient");

        //Debug.Log(fruits.Length + "fruits found");
        foreach (var fruit in fruits)
        {
            if (fruit.GetComponent<Ingredient>().id == ingredientType)
                Destroy(fruit);
        }

        var randomRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        GameObject.Instantiate(fruitPrefab, spawnPos.position, randomRotation);
    }
}
