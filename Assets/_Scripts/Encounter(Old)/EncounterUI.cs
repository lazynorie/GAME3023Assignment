using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterUI : MonoBehaviour
{
    [SerializeField] private EncounterInstance encounter;
    [SerializeField] private TMPro.TextMeshProUGUI encounterText;
    [SerializeField] public HPBar hpBar;
    [SerializeField] private GameObject abilityPanel;

    [SerializeField] private float timeBetWeenCharacters = 0.1f;
    
    private IEnumerator animateTextCoroutine = null;

    public void SetData(PlayerCharacter player)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        animateTextCoroutine = AnimateTextCoroutine("You have encountered an opponent!",timeBetWeenCharacters);
        StartCoroutine(animateTextCoroutine);
        /*encounter.onTurnBegin.AddListener(AnnounceTurnBegin);
        encounter.onPlayerTurnBegin.AddListener(EnablePlayerUI);
        encounter.onEnemyTurnBegin.AddListener(DisablePlayUI);*/
       // encounter.player.onAbilityCast.AddListener(PlayerAbility);
      //  encounter.enemy.onAbilityCast.AddListener(EnemyAbility);
    }




    void AnnounceTurnBegin(ICharacter whoseTurn)
    {
        if (animateTextCoroutine != null)
        {
            StopCoroutine(animateTextCoroutine);
        }

        animateTextCoroutine = AnimateTextCoroutine("It's " + whoseTurn.name + " 's turn", timeBetWeenCharacters);
        StartCoroutine(animateTextCoroutine);

    }
    void EnablePlayerUI(ICharacter whoseTurn)
    {
        abilityPanel.SetActive(true);
    }

    void DisablePlayUI(ICharacter whoseTurn)
    {
        abilityPanel.SetActive(false);
    }

    // Update is called once per frame
    IEnumerator AnimateTextCoroutine(string message, float betWeenCharacters)
    {
       // abilityPanel.SetActive(false);
        encounterText.text = ""; 
        for (int currentCharacter = 0; currentCharacter < message.Length;currentCharacter ++)
        {
            encounterText.text += message[currentCharacter];
            yield return new WaitForSeconds(timeBetWeenCharacters);
        }
      //  abilityPanel.SetActive(true);
        animateTextCoroutine = null;
    }
}
