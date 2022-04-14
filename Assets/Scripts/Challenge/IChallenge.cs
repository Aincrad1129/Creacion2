using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChallenge<G,I> 
{

    void Complete(G playersArray,I spawRestarPosition);
    void Restart(G playersArray, I spawnEndPosition );
}
