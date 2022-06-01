using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
   [Header("Dialogue UI")]

   [SerializeField] private GameObject dialoguePanel;

   [SerializeField] private TextMeshProUGUI dialogueText; 

   [Header("Choices UI")]

   [SerializeField] private GameObject[] choices;
   
   private TextMeshProUGUI[] choicesText;

   private Story currentStory;

   private bool dialogueIsOpen;

   private static DialogueManager instance;
  
   

   private void Awake()
   {
       instance = this;

   }

   public static DialogueManager GetInstance()
   {
       return instance;
   }

   private void Start()
   {
       dialogueIsOpen = false;
       dialoguePanel.SetActive(false);

       choicesText = new TextMeshProUGUI[choices.Length];
       int numberofChoices = 0;
       foreach (GameObject choice in choices)
       {
           choicesText[numberofChoices] = choice.GetComponentInChildren<TextMeshProUGUI>();
           numberofChoices++;
       }
   }

   private void Update()
   {
       if (!dialogueIsOpen)
       {
           return;
       }

   }



   public void EnterDialogue(TextAsset inkJSON)
   {
       currentStory = new Story(inkJSON.text);
       dialogueIsOpen = true;
       dialoguePanel.SetActive(true);

       ContinueStory();
   
   }

   private void ExitDialogue()
   {
       dialogueIsOpen = false;
       dialoguePanel.SetActive(false);
       dialogueText.text = "";
   }

   private void ContinueStory()
   {
       if (currentStory.canContinue)
       {
           dialogueText.text = currentStory.Continue();           
       }
       else
       {
           ExitDialogue();
       }

   }

   private void DisplayChoices()
   {
       List<Choice> currentChoices = currentStory.currentChoices;

       if (currentChoices.Count > choices.Length)
       {

       }
   }   

    
}
