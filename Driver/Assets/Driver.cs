using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float SteerSpeed = 1f;
    [SerializeField] float MoveSpeed = 20f;
    [SerializeField] float SlowSpeed = 15f;
    [SerializeField] float BoostSpeed = 30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float SteerAmount = Input.GetAxis("Horizontal") * SteerSpeed * Time.deltaTime;
        float MoveAmount = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -SteerAmount);
        transform.Translate(0, MoveAmount, 0);
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        MoveSpeed = SlowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Booster")
        {
            Debug.Log("Boosted");
            MoveSpeed = BoostSpeed;
        }
    }
}
