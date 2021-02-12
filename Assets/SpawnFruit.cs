using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public GameObject fruitPrefab;
    public Transform spawnPos;

    private void OnMouseDown()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject.Instantiate(fruitPrefab, spawnPos.position, Quaternion.identity);
    }
}
