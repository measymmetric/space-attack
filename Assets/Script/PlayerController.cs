using System.Collections;
using UnityEngine;

[System.Serializable]

public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour

{

    public float speed;
    public float tilt;
    public Boundary boundary;
    public Rigidbody rb;
    public AudioSource audio;


    public GameObject shot;
    public Transform shotspawn;
    public float fireRate;

    private float nextFire;

    //GameObject sheild;

    //private void Start()
    //{
    //    sheild = transform.Find("sheild").gameObject;
    //}

    void Update()
    {
        if
            (Input.GetButton("Fire") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //          GameObject clone = 
            Instantiate(shot, shotspawn.position, shotspawn.rotation);  // as GameObject
            audio.Play();
        }
    }

    //void ActivateSheild()
    //{
    //    sheild.SetActive(true);
    //}

    //void DeactivateSheild()
    //{
    //    sheild.SetActive(false);
    //}

    void FixedUpdate()

    {

        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
