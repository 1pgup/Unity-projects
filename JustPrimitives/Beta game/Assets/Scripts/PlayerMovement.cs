using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{

    public float JumpForce;
    public float Rotation;
    private bool _isGround = false;
    private float impulse;
    [SerializeField]
    public float rotationSpeed;
    Rigidbody2D rb;
    [SerializeField] AudioClip audioClip1;
    [SerializeField] AudioClip audioClip2;
    AudioSource audioSource;

    bool musicIsPlaying = false;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(musicIsPlaying == false)
        {
            audioSource.PlayOneShot(audioClip2,0.4f);
            musicIsPlaying = true;
        }
        DontDestroyOnLoad(audioSource);
        DontDestroyOnLoad(audioClip2);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, GetComponent<BoxCollider2D>().size.y / 2 + 0.05f, LayerMask.GetMask("Middleground"));

        if (Input.GetKey("space") && _isGround)
            {
                audioSource.PlayOneShot(audioClip1,0.7f);
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
               //rb.AddTorque(impulse, ForceMode2D.Impulse);
                _isGround = false;
                Rotation -= 90f;

            }

        if (hit.collider == null)
        {
            Quaternion target = Quaternion.Euler (0, 0, Rotation);
            transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * rotationSpeed);
            Debug.Log(Rotation);
        }
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            _isGround = true;
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, Rotation);
        }
        if (other.gameObject.tag == "dammage")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
    }
}
