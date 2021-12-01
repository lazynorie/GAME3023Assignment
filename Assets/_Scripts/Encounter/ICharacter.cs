using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacter : MonoBehaviour
{
    public Ability[] abilities;

    public abstract void TakeTurn();
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
