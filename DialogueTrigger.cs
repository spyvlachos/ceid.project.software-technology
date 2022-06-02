using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour

{

    


    [Header("DialoguePartner Icon")]
    [SerializeField] private GameObject dialoguePartnerIcon;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool maincharInRange;

    private void Awake()
    {
        maincharInRange = false;
        dialoguePartnerIcon.SetActive(false);
    }

    private void Update()
    {
        if (maincharInRange)
        {
            dialoguePartnerIcon.SetActive(true);
            if (Input.GetKeyDown("z"))
            {
                DialogueManager.GetInstance().EnterDialogue(inkJSON);
            }
        }
        else
        {
            dialoguePartnerIcon.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            maincharInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            maincharInRange = false;
        }


    }
}
