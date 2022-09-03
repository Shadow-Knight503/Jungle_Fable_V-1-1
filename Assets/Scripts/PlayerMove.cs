using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour {
    public Rigidbody Rb;
    public float ForwardForce = 5f;
    public float PosFor; 
    public float Delay = 2f;
    public float Speed;
    public bool Turned = false;
    public bool OnEnd = false;
    public bool Reverse = false;
    public bool Turn = true;
    public string CamObj = "Dice";
    public int TurnNo = 0;
    public int NoRolled; 
    public Vector3 EndPt;
    public Vector3 StrPt;
    public Vector3 CrtPos;
    public CamScrpt Cam;
    public DiceScript Dice;
    public GameObject Pawn;
    int Hjj;

    // Start is called before the first frame update
    void Start() {
        Pawn = GameObject.FindWithTag("RlPlayer");
        StrPt = Pawn.transform.position;
        EndPt = Pawn.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        CrtPos = Pawn.transform.position;
        if (Speed < 1f) {
            Speed += 0.01f;
        }
        if (CrtPos == EndPt && TurnNo == 0) {
            Invoke("PlayMove", 1f);
        }
        if (CrtPos == EndPt && TurnNo == 1) {
            Invoke("AiMove", 1f);
        }
        Pawn.transform.position = Vector3.Lerp(StrPt, EndPt, Speed);
    }

    void AiMove() {
        Cam.Focus_Obj = "Ai";
        Pawn = GameObject.FindWithTag("AiPlayer");
        
        Move(3);
        TurnNo = 0;
    }

    void PlayMove() {
        Cam.Focus_Obj = "Dice";
        
    }

    public void Move(int Num) {
        NoRolled = Num;
        
        if (Turned) {
            NoRolled = -Num;
            if (OnEnd) {
                NoRolled = -(Num - 1);
            }
        } else if (OnEnd) {
            NoRolled = Num - 1;
        }
        if (OnEnd) {
            UpMove();
            Invoke("MoveDets", Delay);
            OnEnd = false;
        } else {
            MoveDets();
        }
    }

    void MoveDets() {
        if (Reverse) {
            NoRolled = -NoRolled;
        }
        StrPt = Pawn.transform.position;
        EndPt = Pawn.transform.position + new Vector3 (PosFor * NoRolled, 0, 0);
        Speed = 0;
    }

    public void UpMove() {
        if (Reverse) {
            EndPt = Pawn.transform.position + new Vector3 (0, 0, -PosFor);
        } else { 
            EndPt = Pawn.transform.position + new Vector3 (0, 0, PosFor);
        }
        if (Turned) {
            Pawn.transform.Rotate(0f, 180f, 0f, Space.Self);
        } else {
            Pawn.transform.Rotate(0f, -180f, 0f, Space.Self);
        }
        StrPt = Pawn.transform.position;
        Speed = 0;
    }
}
