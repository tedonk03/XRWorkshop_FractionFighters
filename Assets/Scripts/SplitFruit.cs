using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitFruit : MonoBehaviour
{
    public GameObject[] splitPrefabs;
    public GameObject splitVFX;


    private Camera mainCamera;
    private float cameraZdistance;

    private float downClickTime;
    private readonly float clickDeltaTime = 0.2f;

    private Floater floaterScript;

    void Start()
    {
        mainCamera = Camera.main;

        cameraZdistance = mainCamera.WorldToScreenPoint(transform.position).z;
        
        floaterScript = GetComponent<Floater>();

    }

    private void OnMouseDrag()
    {
        floaterScript.DisableFloating();
        MoveObject();
        
    }
    private void OnMouseDown()
    {
        downClickTime = Time.time;
    }

    public void MoveObject()
    {
        var screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZdistance);
        var newPos = mainCamera.ScreenToWorldPoint(screenPos);
        transform.position = newPos;
    }

    private void OnMouseUp()
    {
        Debug.Log("mouse up");
        floaterScript.EnableFloating();
        if (Time.time - downClickTime <= clickDeltaTime)
        {
            Split();
        }
    }

    public void Split()
    {
        Debug.Log("Split");
        if (splitPrefabs.Length == 0)
            // safe check
            return;

        AudioManager.Instance.Play("split");

        // instantiate prefabs, depends on split mode
        var childIndex = 0; // TODO: replace this later, if we have a list of possible fractions
        GameObject.Instantiate(splitVFX, this.transform.position, Quaternion.identity);

        var randomAngle = Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        GameObject.Instantiate(splitPrefabs[childIndex], this.transform.position, randomAngle);
        
        // destroy the parent
        Destroy(this.gameObject);
    }
}
