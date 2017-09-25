using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public GameObject target;
    public float moveSpeed = 0.05f;
    public VJHandler jsMovement;

    private Vector3 direction;
    private float xMin, xMax, yMin, yMax;

    void Update() {

        direction = jsMovement.InputDirection; //InputDirection can be used as per the need of your project
        direction.z = direction.y;
        direction.y = 0;

        if (direction.magnitude != 0 && target) {
            target.transform.position += direction * moveSpeed;
        }
    }

    void Start() {
        //Initialization of boundaries
        xMax = Screen.width - 50; // I used 50 because the size of player is 100*100
        xMin = 50;
        yMax = Screen.height - 50;
        yMin = 50;
    }
}