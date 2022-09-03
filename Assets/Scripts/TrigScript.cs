using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigScript : MonoBehaviour {
    public GameObject TriggerTrap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOff() {
        TriggerTrap.SetActive(false);
    }
}
