using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuzzleBox : MonoBehaviour
{
    private Camera cam;
    private GameObject[] puzzleEmptyBox;
    private Vector3 startPos;
    private bool isMatched;
    private GameManager managerGame;
    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        managerGame = GameObject.Find("GameManager").GetComponent<GameManager>();
        puzzleEmptyBox = GameObject.FindGameObjectsWithTag("EmptyBox");
        startPos = transform.position;
    }
    private void OnMouseDrag()
    {
        if(!isMatched)
        {
            var newPos = cam.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0f;
            transform.position = newPos; 
        }
    }
    private void OnMouseUp()
    {
        foreach (var emptyBox in puzzleEmptyBox)
        {
            if (emptyBox.name == transform.name)
            {
                var distancePuzzle = Vector3.Distance(emptyBox.transform.position, transform.position);
                if (distancePuzzle <= 2)
                {
                    managerGame.ScoreUpdate();
                }
            }
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            foreach (var emptyBox in puzzleEmptyBox)
            {
                if(emptyBox.name==transform.name)
                {
                    var distancePuzzle = Vector3.Distance(emptyBox.transform.position, transform.position);
                    if (distancePuzzle <= 2)
                    {
                        transform.position = emptyBox.transform.position;
                      //  managerGame.ScoreUpdate();
                        isMatched = true;      
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