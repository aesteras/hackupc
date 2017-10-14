using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour {

    public List<PlayerCharacter> players;
    public int currentPlayer;
    public bool passTurnPressed;
    public GameObject vitoryText;

    public GameObject[] blues = new GameObject[3];
    public GameObject[] reds = new GameObject[3];

    public enum COMBAT_STATES
    {
        SELECT_ATTACKER,
        SELECT_DEFENDER,
        CHANGING_TURN,
        GAME_OVER
    }

    public COMBAT_STATES currentState;
    CombatUnit unitToMove = null;
    CombatUnit unitToAttack = null;

    bool tempPlayerOneLost = false;
    bool tempPlayerTwoLost = false;

    // Use this for initialization
    void Start () {
        this.players = new List<PlayerCharacter>(2);
        PlayerCharacter playerOne = new PlayerCharacter();
        PlayerCharacter playerTwo = new PlayerCharacter();
        playerOne.init(1,this);
        playerTwo.init(2,this);
        this.players.Add(playerOne);
        this.players.Add(playerTwo);
        this.currentPlayer = 1;
        this.passTurnPressed = false;
        currentState = COMBAT_STATES.SELECT_ATTACKER;
        //posar un text de victoria amb el nº del jugador guanyador

	}
	
	// Update is called once per frame
	void Update ()
    {
        playTurn();

    }



    void playTurn() {
        if (currentState == COMBAT_STATES.CHANGING_TURN)
        {
            unitToAttack.getHitBy(unitToMove);
            this.unitToMove = null;
            this.unitToAttack = null;
            resetUnitsMovement();
            currentPlayer = (currentPlayer % 2) + 1;
            currentState = COMBAT_STATES.SELECT_ATTACKER;
            if (gameIsOver())
            {
                currentState = COMBAT_STATES.GAME_OVER;
                if (tempPlayerOneLost)
                {
                    vitoryText.GetComponent<UnityEngine.UI.Text>().text = "RED PLAYER WINS!";
                }
                else
                {
                    vitoryText.GetComponent<UnityEngine.UI.Text>().text = "BLUE PLAYER WINS!";
                }
                vitoryText.SetActive(true);
                //canviar el text del guanyador
            }
        }

        if (currentState == COMBAT_STATES.SELECT_ATTACKER)
        {
            if(!passTurnPressed && movementsAvailable())
            {
                unitToMove = selectUnit();
                if (unitToMove != null && unitToMove.playerOwner == this.currentPlayer) {
                    currentState = COMBAT_STATES.SELECT_DEFENDER;
                    Debug.Log("canviant a defender");
                }
            }
        }
        if (currentState == COMBAT_STATES.SELECT_DEFENDER)
        {
            unitToAttack = selectUnit();
            if (unitToAttack != null && unitToAttack.playerOwner != this.currentPlayer) {
                currentState = COMBAT_STATES.CHANGING_TURN;
            }
        }

        //Debug.Log("Player " + currentPlayer + " 's turn.");
        //while (!passTurnPressed && movementsAvailable() && !gameIsOver()) {
        //    CombatUnit unitToMove = null;
        //    while (unitToMove==null) {
        //        unitToMove = selectUnit();
        //        if (unitToMove==null || unitToMove.playerOwner != this.currentPlayer) { unitToMove = null; }
        //    }
        //    CombatUnit unitToAttack = null;
        //    while (unitToAttack==null) {
        //        unitToAttack = selectUnit();
        //        if (unitToMove == null || unitToAttack.playerOwner == this.currentPlayer) { unitToAttack = null; }
        //    }
        //    unitToAttack.getHitBy(unitToMove);
        //}
        //currentPlayer = (currentPlayer % 2) + 1;
        //if (!gameIsOver()) { playTurn(); }
    }

    CombatUnit selectUnit() {

        CombatUnit temp;

        //per cada touch que existeix a la pantalla
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //cambiar el infinit
                {
                    Debug.Log("HIT !");
                    temp = hit.transform.GetComponent<CombatUnit>();
                    if (!temp.isDead) {
                        Debug.Log("TOCAT!");
                        return temp;
                    }
                }
            }
        }
        
        //per fer proves
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //cambiar el infinit
            {
                Debug.Log("HIT !");
                temp = hit.transform.GetComponent<CombatUnit>();
                if (!temp.isDead) { return temp; }
            }

        }

        return null;

    }

    bool movementsAvailable() {
        int p = this.currentPlayer - 1;
        if (!players[p].units[0].isDead && !players[p].units[0].wasMoved ||
            !players[p].units[1].isDead && !players[p].units[1].wasMoved ||
            !players[p].units[2].isDead && !players[p].units[2].wasMoved) {
            return true;
        }
        return false;
    }

    void resetUnitsMovement() {
        int p = this.currentPlayer - 1;
        for (int i = 0; i < 3; ++i) {
            players[p].units[i].resetMovement();
        }
    }

    bool gameIsOver() {
        tempPlayerOneLost = true;
        tempPlayerTwoLost = true;
        for (int i = 0; i < 3; ++i) {
            if (!this.players[0].units[i].isDead) { tempPlayerOneLost = false; }
            if (!this.players[1].units[i].isDead) { tempPlayerTwoLost = false; }
        }
        // if (tempPlayerOneLost && tempPlayerTwoLost) { /*result = "tie";*/ return true; }
        if (tempPlayerOneLost) { Debug.Log("playerTwo won"); return true; }
        if (tempPlayerTwoLost) { Debug.Log("playerOne won"); return true; }
        return false;
    }

}
