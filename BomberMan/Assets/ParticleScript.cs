using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "UndestructibleBlock" || other.tag == "DestructibleBox") {
            Destroy(this.gameObject);
            Debug.Log(other.name);
        }
    }
}
