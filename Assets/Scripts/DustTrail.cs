using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{

    [SerializeField] ParticleSystem slideEffect;

    [SerializeField] AudioClip boardingFX;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            slideEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(boardingFX);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GetComponent<AudioSource>().Stop();
            slideEffect.Stop();
        }
    }
}
