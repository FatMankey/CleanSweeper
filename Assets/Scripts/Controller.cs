using UnityEngine;

public class Controller : MonoBehaviour {
    public delegate void MoveRhoomba(Transform transform);

    public static event MoveRhoomba Rhoomba;

    public delegate void Point();

    public delegate void Movement(string Dir);

    public static event Movement _movement;
    public bool pressme;

    public static event Point point;

    public Rhoomba[] rhoombas;
    public GameObject[] Pointtaggers;

    private static Controller _instance;

    public static Controller Instance {
        get {
            if (_instance != null) return _instance;
            var go = new GameObject("Controller");
            go.AddComponent<Controller>();

            return _instance;
        }
    }

    enum Directions {
        UP,DOWN,LEFT,RIGHT,NONE
    }
    private void Awake() {
        _instance = this;
        Pointtaggers = new GameObject[12];
        var x = 0;
        foreach (var varGameObject in GameObject.FindGameObjectsWithTag("Point"))
        {
            Pointtaggers[x] = varGameObject;
            x++;
        }

        x = 0;
    }


    void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Pointtaggers == null) return;
            SendDirections(Directions.UP);
            
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            if (Pointtaggers == null) return;
            SendDirections(Directions.DOWN);
        }

        if (pressme) {
            _movement("Up");
        }

    }

    void SendDirections(Directions Dir) {
        
        if (Dir == Directions.UP) {
           // point();
            _movement("Up");
            pressme = true;
        }

        if (Dir == Directions.LEFT) {
            _movement("Left");
            pressme = true;
        }

        if (Dir == Directions.DOWN) {
            _movement("Left");
            pressme = true;
        }

        if (Dir == Directions.RIGHT) {
            _movement("Right");
            pressme = true;
        }
        else {
            pressme = false;
        }
    }
}