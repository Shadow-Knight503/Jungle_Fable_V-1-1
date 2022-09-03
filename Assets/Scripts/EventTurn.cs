using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTurn : MonoBehaviour {
    public PlayerMove Movement;

    float No_Turns;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter (Collider Col) {
        if (Col.tag == "RlPlayer" || Col.tag == "AiPlayer") {    
            Movement.enabled = false;
            No_Turns = Mathf.Abs(Mathf.Round(((Movement.EndPt.x - Movement.CrtPos.x) / Movement.PosFor)));
            Movement.enabled = true;
            if (Movement.Turned == false) {Movement.Turned = true;}
            else {Movement.Turned = false;}
            if (No_Turns >= 1f) {
                Movement.UpMove();
                Invoke("MoveInit", Movement.Delay);
            } else if (No_Turns == 0f) {
                Movement.OnEnd = true;
            } 
            if (No_Turns == 1f && Movement.Reverse) {
                Movement.OnEnd = true;
            
            }
        }
    }

    void MoveInit() {
        Movement.Move((int) (No_Turns - 1f));
    }
}
