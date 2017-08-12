using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public Movement location;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            bool isAllowedToWalk = false;

            PlayerController pc = other.GetComponent<PlayerController>();
            MovementAllowed allowedDirectionsContainer = pc.getAllowedDirections();
            try
            {
                Movement[] allowedDirections = allowedDirectionsContainer.getAllowedDirections();
                for (int i = 0; i < allowedDirections.Length; i++)
                {
                    if (allowedDirections[i].Equals(location))
                    {
                        isAllowedToWalk = true;
                    }
                }
                if (!isAllowedToWalk)
                {
                    pc.kill();
                }
            }
            catch(System.NullReferenceException ex)
            {
                // First round does not have colliders
            }
        }
    }
}
