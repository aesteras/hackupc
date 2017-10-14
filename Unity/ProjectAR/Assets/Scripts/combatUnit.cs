using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatUnit : MonoBehaviour {

    public enum unityType
    {
        SOLDIER,
        HORSE,
        ARCHER
    }

    int playerOwner;
    int life = 10;
    bool wasUsed; //was it already used in this turn?
    unityType currentType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void getHitBy(unityType type)
    {
        if (currentType == unityType.HORSE && type == unityType.ARCHER
            || currentType == unityType.ARCHER && type == unityType.SOLDIER)
        {   //DANY EXTRA

        }
        else //normal damage
        {

        }
    }

}
