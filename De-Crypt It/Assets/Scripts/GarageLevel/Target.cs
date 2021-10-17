using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer renderer;
    public GameObject TheKey;
    public static bool isKeyCollected;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        if (isKeyCollected == true)
        {
            TheKey.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /**if (Input.GetMouseButtonDown(0))
        {
            TheKey.active = false;
            isKeyCollected = true;
        }**/
    }

    private void OnMouseOver()
    {
        renderer.material.color = Color.green;
        if (Input.GetMouseButtonDown(0))
        {
            TheKey.active = false;
            isKeyCollected = true;
        }
        
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
