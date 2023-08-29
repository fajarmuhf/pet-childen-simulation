using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HMDInfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IgnoreCollision()
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Body");
        gameObject.layer = LayerIgnoreRaycast;
    }

    public void ExitIgnoreCollision()
    {
        StartCoroutine(exitCollision());
        
    }

    IEnumerator exitCollision()
    {
        yield return new WaitForSeconds(1);
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
        gameObject.layer = LayerIgnoreRaycast;
    }
}
