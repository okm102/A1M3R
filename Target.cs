using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyTarget());        //Initiate coroutine DestroyTarget
    }

    IEnumerator DestroyTarget()                 //IEnumerator is used to be able to stop and resume the iteration at any time
    {
        yield return new WaitForSeconds(1);                     //wait 1 second before new target is spawned
        Trainer.targetsMissed = Trainer.targetsMissed + 1;      //variable targetsMissed keeps updating in game, +1 each miss
        if (Trainer.gameOver == false)                          //If the bool gameOver is still false
        {
            Trainer.instance.SpawnTargets();                    //keep spawning targets

        }
        Destroy(gameObject);                                    //destroys target
    }

  
    private void OnMouseDown()                                  //When LMC is clicked on the target
    {
        
        
            
        Trainer.targetsHit = Trainer.targetsHit + 1;            //targetsHit integer increases by 1
        Destroy(gameObject);                                    //The target is destroyed
        if (Trainer.gameOver == false)                          //If bool gameOver is false
        {
            Trainer.instance.SpawnTargets();                    //keep spawning targets
        }
                
            
        
        
    }
    
    

}


