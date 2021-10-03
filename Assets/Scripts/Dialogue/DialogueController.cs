using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    
    [HideInInspector] public SO_Dialogue dialogue;
    [Header("REFERENCES")]
    [SerializeField] private RawImage portrait;
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private GameObject dialogueCompleteIcon;
    [SerializeField] private TextMeshProUGUI noSpeakerText, speakerText;
    private Transform portraitCamera;
    private PlayerController player;

    [Space(10)]
    
    public String[] sentences;
    private int index;
    public float typeSpeed = 0.02f;
    public int lettersBetweenVoice;
    private Coroutine typing;
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.LockInput(true);
    }

    private void OnDestroy()
    {
        player.LockInput(false);
    }

    IEnumerator Type()
    {
        int count = 0;
        
        foreach (char letter in sentences[index])
        {
            textDisplay.text += letter;
            count++;

            if (Char.IsLetterOrDigit(letter))
            {
                if (count >= lettersBetweenVoice)
                {
                    AudioManager.instance.Play(sentences[index]);
                    count = 0;
                }
            }
            else
            {
                if (!letter.Equals(' ') && !letter.Equals('\''))
                {
                    yield return new WaitForSeconds(typeSpeed * 10);
                }
                else if (letter.Equals(','))
                {
                    yield return new WaitForSeconds(typeSpeed * 5);
                }
            }
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        List<String>sentencesList = new List<string>();

        foreach (var sentence in dialogue.sentences)
        {
            sentencesList.Add(sentence.text);
        }

        sentences = sentencesList.ToArray();
        
        UpdateDialogueFormat();

        textDisplay.text = "";
        typing = StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            NextSentence();
        }
        
        if (textDisplay.text == sentences[index])
        {
            dialogueCompleteIcon.SetActive(true);
        }
        else
        {
            dialogueCompleteIcon.SetActive(false);
        }
    }

    public void NextSentence()
    {
        if (textDisplay.text == sentences[index]) //se o texto estiver 100% digitado na tela
        {
            if (index < sentences.Length - 1) //ir para a próxima linha de diálogo
            {
                index++;
                UpdateDialogueFormat();
                textDisplay.text = "";
                typing = StartCoroutine(Type());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            textDisplay.text = sentences[index];
            StopCoroutine(typing);
        }
    }

    public void UpdateDialogueFormat()
    {
        if (dialogue.sentences[index].speaker == null) //if there's no speaker
        {
            SpeakerGUISetActive(false);
        }
        else
        {
            SpeakerGUISetActive(true);
            
            //set names, portraits and voices
            speakerName.SetText(dialogue.sentences[index].speaker.name);

            StartCoroutine(TakePortraitPhoto());
            
            portrait.texture = dialogue.sentences[index].speaker.portrait;
        }
    }

    private void SpeakerGUISetActive(bool active)
    {
        portrait.gameObject.SetActive(active);
        speakerName.gameObject.SetActive(active);
        
        noSpeakerText.gameObject.SetActive(!active); //text formated to no speakers

        textDisplay = active ? speakerText : noSpeakerText; //text being autotyped is set to "Speaker" or "No Speaker"
    }

    IEnumerator TakePortraitPhoto()
    {
        var speakerPortraitCam = FindObjectsOfType<Camera>(true)
            .First(cam => cam.targetTexture.Equals(dialogue.sentences[index].speaker.portrait)).gameObject;
            
        speakerPortraitCam.SetActive(true);

        yield return new WaitForEndOfFrame();
        
        speakerPortraitCam.SetActive(false);
    }
}
