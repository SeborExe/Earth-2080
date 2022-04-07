using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    [SerializeField] float controllSpeed = 20f;
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = 2.5f;
    [SerializeField] float controlRawFactor = -20f;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xoffset = xThrow * Time.deltaTime * controllSpeed;
        float newXpos = transform.localPosition.x + xoffset;
        float newXposClamped = Mathf.Clamp(newXpos, -10.5f, 10.5f);

        float yoffset = yThrow * Time.deltaTime * controllSpeed;
        float newYpos = transform.localPosition.y + yoffset;
        float newYposClamped = Mathf.Clamp(newYpos, -5, 8);

        transform.localPosition = new Vector3(newXposClamped, newYposClamped, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRawFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
