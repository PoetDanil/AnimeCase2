using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesClick : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    
    public IEnumerator ParticleSpawn(Vector3 position) { 
        ParticleSystem _newParticle;
        
        _newParticle = Instantiate(particles, position: position, rotation: Quaternion.identity);
        _newParticle.Play();
       
        yield return new WaitForSeconds(0.7f);
       
        Destroy(_newParticle.gameObject);
    }
}