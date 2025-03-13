using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public ParticleSystem particles;

    public void onClick()
    {
        particles.Play();
    }
}
