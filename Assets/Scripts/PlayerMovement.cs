using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private GameObject GameOverPannel;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite SpriteAleteo;
    [SerializeField] private Sprite SpriteCaida;
    [SerializeField] private Sprite SpriteNeutro;

    public float JumpForce = 5;
    [SerializeField] private AudioClip CoinSound;
    [SerializeField] private AudioClip ImpactSound;
    InputAction Jump;
    InputAction Crouch;
    public Rigidbody2D rb;

    private AudioSource _audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Jump = InputSystem.actions.FindAction("Jump");
        Crouch = InputSystem.actions.FindAction("Crouch");
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Crouch.WasPressedThisFrame())
        {
            Restart();
        }


        if (Jump.WasPressedThisFrame())
        {
            _spriteRenderer.sprite = SpriteAleteo;
            rb.linearVelocityY = JumpForce;
            _audioSource.PlayOneShot(_audioSource.clip);
        }

        if (rb.linearVelocityY > 1)
        {
            _spriteRenderer.sprite = SpriteAleteo;
        }
        else
        {
            if (rb.linearVelocityY < -1)
            {
                _spriteRenderer.sprite = SpriteCaida;
            }
            else
            {
                _spriteRenderer.sprite = SpriteNeutro;
            }
        }

        rb.MoveRotation(Math.Clamp(rb.linearVelocityY * 3, -30, 30));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Point"))
        {
            GameManager.Instance.AddPoints(1);
            _audioSource.PlayOneShot(CoinSound);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _audioSource.PlayOneShot(ImpactSound);
        GameOverPannel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        GameManager.Instance.ResetScore();
    }

}



