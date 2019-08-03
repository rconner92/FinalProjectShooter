using UnityEngine;
using System.Collections;

public class ParticleControl : MonoBehaviour 
{

    
    public GameController gameController;
    public ParticleSystem ps;
    public float defaultVelocity;
    public float VelocityMultiplyer;
    void Start () 
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    void Update ()
    {
        ParticleSystem.MainModule main = ps.main;
        if (gameController.score >= 300)
        {
             main.simulationSpeed = defaultVelocity * VelocityMultiplyer;
        }

        
    }
}


 /* public void ParticleSpeed (ParticleSystem ps, float defaultVelocity, float VelocityMultiplyer){
 
     ParticleSystem.MainModule main = ps.main;
 
     main.simulationSpeed = defaultVelocity * VelocityMultiplyer;
 
     Debug.Log ("Particle simSpeed : " + main.simulationSpeed);
 
 }*/