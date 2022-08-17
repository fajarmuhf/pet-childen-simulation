using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private PlayerRotate _rotate;
    private PlayerMove _move;
    private PlayerRotateSmooth _rotateSmooth;
    private PlayerRotateSmooth _currentRotate;

    //float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rotate = GetComponent<PlayerRotate>();
        _rotateSmooth = GetComponent<PlayerRotateSmooth>();
        _currentRotate = _rotateSmooth;
        _move = GetComponent<PlayerMove>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _move.Move();
        _currentRotate.Rotate();
    }
}