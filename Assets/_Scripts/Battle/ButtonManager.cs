using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private bool physical;
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("HackBtn") == 0)
        {
            player.GetComponent<FighterAction>().SelectAttack("hack");
        }
        else if (btn.CompareTo("MagicBtn") == 0)
        {
            player.GetComponent<FighterAction>().SelectAttack("magic");
        }
       /* else
        {
            Debug.Log("Run Button Pressed");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
