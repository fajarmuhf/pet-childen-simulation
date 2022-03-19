using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateSmooth : PlayerRotate
{
    [SerializeField] private float smoothTime;
    [SerializeField] private Transform horiRotHelper;

    private float verOld;
    private float vertAngularVelocity;
    private float horiAngularVelocity;

    // Start is called before the first frame update
    void Start() => horiRotHelper.localRotation = transform.localRotation;

    public override void Rotate()
    {
        verOld = vertRot;
        base.Rotate();
    }
    // Update is called once per frame
    protected override void RotateHorizontal()
    {
        horiRotHelper.Rotate(Vector3.up * GetHorizontalValue(), Space.Self);

        transform.localRotation = Quaternion.Euler(
            0f,
            Mathf.SmoothDampAngle(transform.localEulerAngles.y,horiRotHelper.localEulerAngles.y,ref horiAngularVelocity,smoothTime),
            0f);
    }

    protected override void RotateVertical()
    {
        vertRot = Mathf.SmoothDampAngle(verOld,vertRot,ref vertAngularVelocity,smoothTime);
        base.RotateVertical();
    }
}
