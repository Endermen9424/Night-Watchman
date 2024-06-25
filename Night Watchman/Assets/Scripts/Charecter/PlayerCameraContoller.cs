using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraContoller : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] float maxLookUp = -60f;
    [SerializeField] float minLookUp = 60f;
    [SerializeField] float maxLookLeft = -85f;
    [SerializeField] float maxLookRight = 85f;
    [SerializeField] float sensitivity = 1f;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update() {
        float rotateX = Input.GetAxis("Mouse X") * sensitivity;
        float rotateY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 rotcamera = Camera.transform.rotation.eulerAngles;
        Vector3 rotplayer = transform.rotation.eulerAngles;

        rotcamera.x = (rotcamera.x > 180) ? rotcamera.x -360 : rotcamera.x;
        rotcamera.x = Mathf.Clamp(rotcamera.x, maxLookUp, minLookUp);
        rotcamera.x -= rotateY;

        rotplayer.y = (rotplayer.y > 180) ? rotplayer.y -360 : rotplayer.y;
        rotplayer.y = Mathf.Clamp(rotplayer.y, maxLookLeft, maxLookRight);
        rotplayer.y += rotateX;

        Camera.transform.rotation = Quaternion.Euler(rotcamera);
        transform.rotation = Quaternion.Euler(rotplayer);
    }
}
