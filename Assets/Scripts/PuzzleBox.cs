using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour
{
    private Camera cam;
    private GameObject[] emptyPuzzleBoxes;
    Vector2 startPos;
    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        emptyPuzzleBoxes = GameObject.FindGameObjectsWithTag("EmptyBox");
        startPos = transform.position;
    }
    private void OnMouseDrag()
    {
        Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        transform.position = newPos;
    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            foreach(var emptyBox in emptyPuzzleBoxes)
            {
                if(gameObject.name==emptyBox.name)
                {
                    var distance = Vector3.Distance(emptyBox.transform.position, transform.position);
                    if(distance<=2)
                    {
                        transform.position = emptyBox.transform.position;
                    }
                    else
                    {
                        transform.position = startPos;
                    }
                }
            }
        }
    }
}