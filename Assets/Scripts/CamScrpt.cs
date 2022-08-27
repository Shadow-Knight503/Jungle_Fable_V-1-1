using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScrpt : MonoBehaviour {

    public Transform Player;
    public Transform DicePlat;
    public Vector3 Offset;
    public string Focus_Obj = "Dice";

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    void LateUpdate() {
        if (Focus_Obj == "Dice") {
            transform.position = DicePlat.position + Offset;
        } else if (Focus_Obj == "Player") {
            transform.position = Player.position + Offset;
        }   
    }
}
