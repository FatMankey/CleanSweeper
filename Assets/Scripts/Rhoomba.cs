using System;
using System.Collections.Generic;
using UnityEngine;

public class Rhoomba : MonoBehaviour {
    public List<GameObject> AcceptableUp;
    public List<GameObject> AcceptableDown;
    public List<GameObject> AcceptableLeft;
    public List<GameObject> AcceptableRight;
    public List<GameObject> AcceptablePoints;

    private void Start() {
        // Controller.Rhoomba += move;
        foreach (var var in GameObject.FindGameObjectsWithTag("Point")) {
            AcceptablePoints.Add(var);
        }

        CheckDirections();
        
        
        //  Controller.point += TakeLeft;
        Controller.point += CheckDirections;
        Controller.point += TakeTop;
        Controller.point += CheckDirections;
        Controller._movement += TakeDirection;
        //Controller.point += ResetEverything;

    }

    private void Move(Transform transform) {
        if (transform == null)
        {
            throw new ArgumentNullException(transform.name);
        }

        this.transform.GetComponent<Transform>().gameObject.transform.position = transform.position;
    }

    private void OnDisable() {
        Controller.Rhoomba -= Move;
    }

    #region CheckDir
    //rename of taking to check since that's what happening
    private void CheckUp() {
        AcceptableUp = new List<GameObject>();
        foreach (GameObject uppergGameObject in AcceptablePoints) {
            if (uppergGameObject.transform.position.y > transform.parent.transform.position.y &&
                Math.Abs(uppergGameObject.transform.position.x - transform.parent.transform.position.x) < 0.1) {
                AcceptableUp.Add(uppergGameObject);
            }
        }
    }

    private void CheckDown() {
        AcceptableDown = new List<GameObject>();
        foreach (GameObject uppergGameObject in AcceptablePoints) {
            if (uppergGameObject.transform.position.y < transform.parent.transform.position.y &&
                Math.Abs(uppergGameObject.transform.position.x - transform.parent.transform.position.x) < 0.1) {
                AcceptableDown.Add(uppergGameObject);
            }
        }
    }

    private void CheckLeft() {
        AcceptableLeft = new List<GameObject>();
        foreach (GameObject uppergGameObject in AcceptablePoints) {
            if (uppergGameObject.transform.position.x < transform.parent.transform.position.x &&
                Math.Abs(uppergGameObject.transform.position.y - transform.parent.transform.position.y) < 0.1) {
                AcceptableLeft.Add(uppergGameObject);
            }
        }
    }

    private void CheckRight() {
        AcceptableRight = new List<GameObject>();
        foreach (GameObject uppergGameObject in AcceptablePoints) {
            if (uppergGameObject.transform.position.x > transform.parent.transform.position.x &&
                Math.Abs(uppergGameObject.transform.position.y - transform.parent.transform.position.y) < 0.1) {
                AcceptableRight.Add(uppergGameObject);
            }
        }
    }

    private void CheckDirections() {
        CheckUp();
        CheckDown();
        CheckLeft();
        CheckRight();
    }

    #endregion

    #region TakeMovement

    // Current attempts to move character
    private void TakeLeft() {
        foreach (var var in AcceptableLeft) {
            transform.parent.position =
                Vector2.MoveTowards(transform.parent.position, var.transform.position, 4.3f);
        }
    }

    private void TakeRight() {
        foreach (var var in AcceptableRight) {
            transform.parent.position =
                Vector2.MoveTowards(transform.parent.position, var.transform.position, 4.3f);
        }
    }

    private void TakeTop() {
        AcceptableUp.Sort(delegate(GameObject x, GameObject y) {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return 1;
            if (y == null)
                return -1;
            return x.transform.position.y.CompareTo(y.transform.position.y);
        });
        int i = 0, temp = 0;
        bool used = false;
        foreach (var var in AcceptableUp) {
           
           transform.parent.position =  Vector2.Lerp(transform.parent.position, var.transform.position, Time.deltaTime);
            if (var.transform.position.y < transform.parent.position.y) {
                temp = i;
                used = true;
            }

            //if (Math.Abs(var.transform.position.y - transform.parent.position.y) < 0.1 &&
            //    Math.Abs(var.transform.position.x - transform.parent.position.x) < 0.1) {
            //    AcceptableUp.Remove(var);
            //}
            
            i++;
        }
        if(used == true)
            AcceptableUp.RemoveAt(temp);
        // a bit redundant to use this again...i should reset
        ResetEverything();
        CheckDirections();
    }

    #endregion

#region TakeDir

    void TakeDirection(string Dir) {
        switch (Dir) {
            case "Up":
                TakeTop();
                break;
            case "Down":
                break;
            case "Right":
                TakeRight();
                break;
            case "Left":
                TakeLeft();
                break;
            default:
                CheckDirections();
                break;
        }
    }

#endregion
    private void ResetEverything() {
        AcceptableLeft.Clear();
        AcceptableUp.Clear();
        AcceptableRight.Clear();
        AcceptableDown.Clear();
    }
}