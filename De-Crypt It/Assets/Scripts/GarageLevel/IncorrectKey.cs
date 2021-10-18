using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncorrectKey : MonoBehaviour
{

    private Renderer renderer;
    public GameObject Key;
    public static bool isWrongKeyCollected;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        renderer.material.color = Color.green;
        if (Input.GetMouseButtonDown(0))
        {
            Key.active = false;
            isWrongKeyCollected = true;
        }

    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
