using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadParticle : MonoBehaviour
{
    public static ParticleSystem DeadSimulation;
    private void Awake()
    {
        DeadSimulation = this.GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    public static void SimulateDeadParticle()
    {
        DeadSimulation.Play();
    }
}
