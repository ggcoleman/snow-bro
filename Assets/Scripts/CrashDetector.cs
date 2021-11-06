using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0.5f;

    [SerializeField] ParticleSystem CrashEffect;

    [SerializeField] AudioClip crashSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            var audioSource = GetComponent<AudioSource>();

            FindObjectOfType<PlayerController>().DisableControls();
            if (!CrashEffect.isPlaying)
            {
                CrashEffect.Play();
            }
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(crashSFX);
            }

            Invoke("ReloadScene", reloadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
