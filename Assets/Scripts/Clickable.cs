using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {
    private Renderer rend;
    // Use this for initialization
    public bool clicked = false;
	void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform != null && hit.transform.gameObject == gameObject)
            {
                print(hit.transform.gameObject.name);
                rend.material.SetColor("_Color", Color.green);
                clicked = true;
         
            }
            else
            {
                if (gameObject.name.Contains("Black_Square")) rend.material.SetColor("_Color", Color.black);
                else if (gameObject.name.Contains("White_Square")) rend.material.SetColor("_Color", Color.white);
                clicked = false;
            }
        }
    }
}
