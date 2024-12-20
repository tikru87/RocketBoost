using UnityEngine;
using UnityEngine.InputSystem;

public class Effects : MonoBehaviour
{
    ParticleSystem thusterParticles;
    AudioSource audioSource;
    Flying flying;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        flying = GetComponent<Flying>();
        thusterParticles = GetComponentInChildren<ParticleSystem>();
        thusterParticles.Stop();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMotor();
    }

    void ProcessMotor()
    {
        if (flying.isThrusting)
        {
            thusterParticles.Play();
            if (!audioSource.isPlaying)
            {
                audioSource.volume = 1f;
                audioSource.Play();
            }
        }
        else
        {
            thusterParticles.Stop();
            audioSource.volume = 0.1f;
            audioSource.Stop();
        }
    }
}
