using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceCheck : MonoBehaviour {
    public bool OnGround;
    public int DiceSide;
    public bool Logged = false; 
    public TextMeshProUGUI DiceTxt;
    public DiceScript Dice;
    public PlayerMove Movement;
    public CamScrpt Cam;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void LogChange() {
        Logged = false;
    }

    public void OnTriggerStay(Collider Col) {
        if (Col.tag == "Ground" && !Logged && Dice.Rb.IsSleeping() && Dice.Landed && Dice.Thrown) {
            DiceTxt.text = DiceSide.ToString();
            OnGround = true;
            Logged = true;
            Cam.Focus_Obj = "Player";
            if (Movement.OnEnd) {
                Movement.UpMove();
                Invoke("MoveMod", Movement.Delay);
            } else {
                Cam.Focus_Obj = "Player";
                Movement.Move(DiceSide);
                Movement.TurnNo = 1;
            }
        }
    }

    void MoveMod() {
        Movement.Move(DiceSide - 1);
    }

    public void OnTriggerExit(Collider Col) {
        if (Col.tag == "Ground") {
            OnGround = false;
        }
    }
}
