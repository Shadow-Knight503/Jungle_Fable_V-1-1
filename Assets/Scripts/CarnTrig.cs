using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnTrig : MonoBehaviour {
    public PlayerMove Movement;
    public int UpperLmt;
    public int LowerLmt;
    public GameObject TriggerTrap;
    int num;
    public bool Logged = true;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnTriggerStay(Collider Col) {
        if (Col.tag == "Player" && Movement.CrtPos == Movement.EndPt && Logged) {
            TriggerTrap.SetActive(true);
            Invoke("MoveDelay", 1f);
            Logged = false;
        }
    }

    void MoveDelay() {
        Movement.Reverse = true;
        Movement.Move(Random.Range(LowerLmt, UpperLmt));
        Logged = true;
    }
}
