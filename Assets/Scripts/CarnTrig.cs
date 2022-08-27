using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnTrig : MonoBehaviour {
    public PlayerMove Movement;
    public int UpperLmt;
    public int LowerLmt;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnTriggerStay(Collider Col) {
        if (Col.tag == "Player" && Movement.CurtPos == Movement.EndPt) {
            Invoke("MoveDelay", 0.2f);
        }
    }

    void MoveDelay() {
        Movement.Reverse = true;
        Movement.Move(Random.Range(LowerLmt, UpperLmt));
    }
}
