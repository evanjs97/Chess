using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Renderer rend;
    private bool clicked = false;
    private bool willMove = false;
    private Transform moveT;
    private bool moving = false;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !moving)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform != null && hit.transform.gameObject == gameObject)
            {
                print(hit.transform.gameObject.name);
                rend.material.SetColor("_Color", Color.blue);
                clicked = true;

            }
            else if(hit.transform == null || !hit.transform.name.Contains("Square"))
            {
                rend.material.SetColor("_Color", Color.white);  
                clicked = false;
            }else if (hit.transform.name.Contains("Square")){
                willMove = true;
                moveT = hit.transform;
            }
        }
        if (willMove) Move();
    }

    private void Move()
    {

        if (gameObject.transform.position.x != moveT.position.x)
        {
            moving = true;
            Vector3 moveX = new Vector3(moveT.position.x, .5f, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, moveX, Time.deltaTime);
        }else if (gameObject.transform.position.z != moveT.position.z)
        {
            moving = true;
            Vector3 moveZ = new Vector3(gameObject.transform.position.x, .5f, moveT.position.z);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, moveZ, Time.deltaTime);
        }else
        {
            willMove = false;
            moving = false;
        }
    }
}
