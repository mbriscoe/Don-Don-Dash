using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeMonkey.HealthSystemCM;

public class PlayerController : MonoBehaviour, IGetHealthSystem
{
    public AdManager adManager;
    private HealthSystem healthSystem;
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip pickupGoodSound;
    public AudioClip pickupBadSound;

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private Animator playerAnim;

    private void Awake() {
        healthSystem = new HealthSystem(100);
        healthSystem.OnDead += HealthSystem_OnDead;
        adManager.InitializeAds();
    }

    void Start() {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    void Update() {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && isOnGround && !(GameManager.instance.gameOver))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Damage();
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 0.5f);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("PickupGood"))
        {
            Heal();
            Destroy(collision.gameObject);
            playerAudio.PlayOneShot(pickupGoodSound, 1.0f);
        }
        else if (collision.gameObject.CompareTag("PickupBad"))
        {
            Damage();
            Destroy(collision.gameObject);
            playerAudio.PlayOneShot(pickupBadSound, 1.0f);
        }
    }

    IEnumerator GameOver() {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("GameOver");
    }

    private void Damage() {
        healthSystem.Damage(10);
    }

    private void Heal() {
        healthSystem.Heal(10);
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e) {
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        GameManager.instance.gameOver = true;

        explosionParticle.Play();
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, 1.0f);
        StartCoroutine(GameOver());

        adManager.ShowAd();
    }

    public HealthSystem GetHealthSystem() {
        return healthSystem;
    }
}