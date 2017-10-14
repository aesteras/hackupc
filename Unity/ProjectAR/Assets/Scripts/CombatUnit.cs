using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnit : MonoBehaviour
{

    public enum unitType
    {
        SOLDIER,
        KNIGHT,
        ARCHER
    }

    public int playerOwner;
    int life;
    public bool wasMoved; //was it already used in this turn?
    public bool isDead;
    unitType currentType;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void init(int owner, int type)
    {
        this.playerOwner = owner;
        this.life = 10;
        this.wasMoved = false;
        this.isDead = false;
        if (type == 1) { this.currentType = unitType.ARCHER; }
        else if (type == 2) { this.currentType = unitType.KNIGHT; }
        else { this.currentType = unitType.SOLDIER; }
    }

    public void getHitBy(CombatUnit attackingUnit)
    {
        unitType type = attackingUnit.currentType;
        if (currentType == unitType.KNIGHT && type == unitType.ARCHER ||
            currentType == unitType.ARCHER && type == unitType.SOLDIER ||
            currentType == unitType.SOLDIER && type == unitType.KNIGHT) {
            // extra damage
            this.life -= 4;
        } else {
            // normal damage
            this.life -= 20;
        }
        if (this.life < 1) {
            this.isDead = true;
            transform.Find("cross").gameObject.SetActive(true);
        }
    }

    public void move() {
        this.wasMoved = true;
    }

    public void resetMovement() {
        this.wasMoved = false;
    }

}
