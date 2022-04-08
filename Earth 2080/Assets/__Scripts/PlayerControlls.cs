using System;
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

    [SerializeField] GameObject[] lasers;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
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
        float newYposClamped = Mathf.Clamp(newYpos, -8, 8);

        transform.localPosition = new Vector3(newXposClamped, newYposClamped, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRawFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            ActiveLasers();
        }
        else
        {
            DesactiveteLasers();
        }
    }

    private void ActiveLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(true);
        }
    }

    private void DesactiveteLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
    }
}
