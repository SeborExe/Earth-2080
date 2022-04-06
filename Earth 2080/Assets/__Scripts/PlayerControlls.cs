using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private void Update()
    {
        float horizontalThrow = Input.GetAxis("Horizontal");
        Debug.Log(horizontalThrow);

        float verticalThrow = Input.GetAxis("Vertical");
        Debug.Log(verticalThrow);
    }
}
