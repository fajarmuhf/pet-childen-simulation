using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private float speed;
    [SerializeField] private float rotationLimit;

    protected float vertRot;

    public virtual void Rotate()
    {
        vertRot -= GetVerticalValue();
        vertRot = Mathf.Clamp(vertRot,-rotationLimit,rotationLimit);

        RotateVertical();
        RotateHorizontal();
    }

    protected float GetVerticalValue() => Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

    protected float GetHorizontalValue() => Input.GetAxis("Mouse X") * speed * Time.deltaTime;

    protected virtual void RotateVertical() => cameraHolder.localRotation = Quaternion.Euler(vertRot,0,0);

    protected virtual void RotateHorizontal() => transform.Rotate(Vector3.up * GetHorizontalValue());
}
