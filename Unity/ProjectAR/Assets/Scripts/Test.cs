using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Test iniciated");
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Input.touchCount; ++i) //per cada touch que existeix a la pantalla
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.Log("TAP !");
                if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //cambiar el infinit
                {
                    Debug.Log("HIT !");

                    if (hit.transform.name == "CubeTest")
                    {
                        Debug.Log("HIT BOMB!");
                    }
                }
            }
        }


        //per fer proves
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("TAP !");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //cambiar el infinit
            {
                Debug.Log("HIT !");

                if (hit.transform.name == "CubeTest")
                {
                    Debug.Log("HIT BOMB!");
                }
            }

        }

    }
}
