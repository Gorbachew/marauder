using UnityEngine;

public class MainController : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rb;
    private Characteristics charact;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        charact = GetComponent<Characteristics>();
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            float heading = Mathf.Atan2(joystick.Horizontal, joystick.Vertical);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, heading * Mathf.Rad2Deg, 0f), 0.1f);
            rb.velocity = new Vector3(joystick.Horizontal * charact.maxSpeed, rb.velocity.y, joystick.Vertical * charact.maxSpeed);

            if (charact.isTired)
                charact.maxSpeed = 1;
            else
                charact.maxSpeed = 4;
                charact.speed = rb.velocity.magnitude;
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
            charact.speed = 0;
        }
    }
}