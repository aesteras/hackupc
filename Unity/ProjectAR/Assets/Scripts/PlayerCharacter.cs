using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    public int number;
    public List<CombatUnit> units;
    
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void init(int number, CombatScript cs) {
        this.number = number;
        this.units = new List<CombatUnit>(3);

        CombatUnit archer;

        CombatUnit knight;

        CombatUnit soldier;

        if (number == 1) {
            archer = cs.blues[0].AddComponent<CombatUnit>();
            knight = cs.blues[1].AddComponent<CombatUnit>();
            soldier = cs.blues[2].AddComponent<CombatUnit>();
        } else{
            archer = cs.reds[0].AddComponent<CombatUnit>();
            knight = cs.reds[1].AddComponent<CombatUnit>();
            soldier = cs.reds[2].AddComponent<CombatUnit>();
        }
        

        archer.init(this.number, 1);
        knight.init(this.number, 2);
        soldier.init(this.number, 3);
        this.units.Add(archer);
        this.units.Add(knight);
        this.units.Add(soldier);
    }

}
