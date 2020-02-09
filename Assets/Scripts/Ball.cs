using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public static Ball Instance;
    Vector3 startPoint;
    float startTime;
    float endTime;
    public float Speed = 0.05f;

    Rigidbody rigidbody;
    AudioSource audioSource;
    private void Start()
    {
        if (Instance == null)
            Instance = this;

        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameManager.Instance.GameStarted)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    startPoint = touch.position;
                    startPoint.z = 0.1f;
                    startTime = Time.time;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 endPos = touch.position;
                    endPos.z = 0.1f;
                    Vector3 dir = (endPos - startPoint).normalized;
                    float distance = (endPos - startPoint).magnitude;
                    transform.Translate(new Vector3(distance * dir.x * Time.deltaTime * Speed, 0, 0));
                }
            }

            else
            {
                if (Input.GetMouseButtonDown(0))
                {

                    startPoint = Input.mousePosition;
                    startPoint.z = 0.1f;
                    startTime = Time.time;
                }
                else if (Input.GetMouseButton(0))
                {
                    Vector3 endPos = Input.mousePosition;
                    endPos.z = 0.1f;
                    Vector3 dir = (endPos - startPoint).normalized;
                    float distance = (endPos - startPoint).magnitude;
                    distance = ThreshouldDistance(distance);
                    transform.Translate(new Vector3(distance * dir.x * Time.deltaTime * Speed, 0, 0));
                }
            }
        }
    }

    private static float ThreshouldDistance(float distance)
    {
        if (distance > 100)
            distance = 100;
        else if (distance < -100)
            distance = -100;
        return distance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            UIManager.Instance.PlayerSteps();
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            VFX.Instance.CreateVFX(rot, pos, VFXNames.jumpVFX);
        }
        else if (collision.gameObject.tag == "Hall")
        {
            UIManager.Instance.GameOver();
            audioSource.Stop();
        }
    }

    public void AddForce(float forceValue)
    {
        rigidbody.AddForce(forceValue, 0, 0);
    }
}
