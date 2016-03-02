using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform followedObject;
    private Vector3 toPosition;



    void LateUpdate()
    {
       // toPosition = followedObject.position + Vector3.up * distanceUp - followedObject.forward * distanceAway;
        toPosition = followedObject.position + Vector3.up * distanceUp;
        transform.position = toPosition;
        transform.LookAt(followedObject);
    }
}
