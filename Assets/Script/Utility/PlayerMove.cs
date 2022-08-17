using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float smoothInputSpeed;

    private CharacterController player;
    private Vector3 moveDir;
    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    // Start is called before the first frame update
    void Awake() => player = GetComponent<CharacterController>();

    // Update is called once per frame
    public void Move()
    {
        moveDir = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        currentInputVector = Vector2.SmoothDamp(currentInputVector,new Vector2(moveDir.x,moveDir.z),ref smoothInputVelocity,smoothInputSpeed);
        moveDir = new Vector3(currentInputVector.x,0,currentInputVector.y);
        player.Move(moveDir * speed* Time.deltaTime);
    }
}
