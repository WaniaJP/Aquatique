using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialoguePNJ : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public KeyCode interactKey;
    public UnityEvent InteractAction;
    private string[][] dialogueMemePale = {
        new string[] { "Bonjour jeune homme, vous ne semblez pas venir d’ici…Je me trompe ? ", 
            "Huuum, c’est bien ce qui me semblait. D’où venez-vous ?",
            "De la surface ? Un humain ? Voilà qui est bien étrange…",
            "Regagnez la surface vous dîtes ? Huuum… Je ne sais pas comment faire.",
            "Vous devriez aller voir mon mari, Pépé Pale, il pourra sûrement vous aider.",
            "*Mémé Pale vous tend une carte*",
            "Prend cette carte, elle t’aidera dans ta quête.",
            "Je ne sais pas où se trouve Pépé Pale pour l’instant mais trouve le chef Pou, il pourra surement t’aider.", 
            "Dis lui que tu viens de la part de Mémé Pale, il t’aidera avec plaisir, il a une dette envers moi.",
            "Bon courage jeune homme."
        },
        new string[] { "Oh Pépé ! Petit coquin ! Fufufu ",
            "Merci beaucoup étranger. Cette lettre a égayé ma journée.",
            "Passe lui le bonjour et dis lui que je l’attends bien au chaud sous la couette." 
        },
        new string[] { "Mon mari a réussi à t’aider ? Il est vraiment formidable, n’est-ce pas ? Tu aurais dû le voir quand il était jeune…viril et intelligent",
            "Oh pardon. Je m’égare à nouveau.",
            "Tu parlais de quelque chose de bizarre dans la paroie Est ?",
            "C’est vrai qu’il y a bien un endroit au nord de ton laboratoire qui me semble assez suspect. Inspecte la roche et tu trouveras ce que tu cherches.",
            "Bonne continuation mon petit ! " 
        }
                 // Ajoutez autant de tableaux de dialogues que nécessaire
    };
    private string[][] dialoguePepePale = {
        new string[] { "Bonjour voyageur,",
            "Reviens me voir plus tard, je suis occupé pour le moment.",
        },
        new string[] { "Bonjour voyageur, ",
            "MÉMÉ PALE ?? Elle me manque tellement, si tu savais…",
            "J’aimerais tant la serrer dans mes bras mais malheureusement je suis trop occupé avec mes recherches…",
            "Mais j’y pense ! Tu pourrais lui délivrer un message toi !",
            "*Pépé Pale vous donne une lettre adressée à Mémé Pale*",
            "Tiens donne lui cette lettre et je t’aiderais en échange."
        },
        new string[] { "Elle a aimé ? Vraiment ? Je l’aime tellement si tu savais…",
            "Chaque journée loin d’elle me cause bien du tort, tu sais…",
            "Je pourrais parler d’elle toute la journée…et toute la nuit aussi…",
            "Blabla…Mémé Pale…Blablabla…Amour…Manque…Blablabla", 
            "Oh pardon. Je me suis égaré…Que puis-je faire pour toi ?",
            "Huuum, un humain tu dis ? C’est étrange, d’après les récits, les terrestres ne ressemblaient pas vraiment à toi.",
            "Oh je vois, tu as subi des modifications dans un laboratoire, ceci explique cela…",
            "C’est assez étonnant que tu sois resté endormi si longtemps…",
            "Comment ? Tu ne sais pas quand nous sommes ?",
            "Eh bien, je ne sais pas en quelle année tu as disparu mais ça doit bien faire 200 ans que nous n’avons pas entendu parlé des humains",
            "Tu veux retourner à la surface, c’est bien ça ? Comme tu as sûrement dû le constater, la surface est inatteignable depuis cette région.",
            "Quoique… Il y a peut être un moyen…",
            "Je viens de découvrir un récit très intéressant dans de vieilles ruines.",
            "D’après lui, nos ancêtres auraient scellé un passage dans la roche à l’aide de gemmes afin de réduire les déchets.",
            "Il existe une gemme pour chaque peuple, va trouver Thalassin Perlefonds, il doit posséder celle des tritons.",
            "Balade toi dans les villages Tritons, tu finiras par le trouver.",
            "Si jamais tu croises Mémé Pale, dis-lui que je l’aime et que je reviens bientôt.",
            "Aaaaah, ma tendre Mémé Pale…"
        },
        new string[] { 
            "Il ne veut pas ? Ce n’est pas très étonnant… Si Mémé Pale était là, elle te dirait de la voler, mais bon…"
        },
        new string[] { 
            "Comment as-tu fait ? Nan attends, je ne veux pas savoir. Plus que deux.",
            "Tu devrais demander de l’aide à Calypso pour celle des gourmets."
        },
        new string[] { 
            "Et de deux ! Plus qu’une ! Tu es rapide pour un humain !",
            "La dernière gemme se trouve dans le royaume des enchanteresses. Va trouver la reine Silphydra Océanara, elle t’aidera…peut-être",
            "Bon j’y crois pas trop, mais bon…"
        },
        new string[] { "Tu as ressuscité ?? Incroyable ! Je ne sais pas ce qu’ils t’ont fait mais tout ceci est fantastique !",
            "En revanche, l’attaque de la meute ne l’est pas du tout… Je me demande si…",
            "Je sais ! Va voir Néhérida Tisselune, c’est une enfant prodigieuse, elle t’aidera.",
            "Tu la trouveras chez les enchanteresses."
        },
        new string[] { 
            "Tu l’as fait ! Tu as réussi !! Je n’en reviens pas !",
            "Hum Hum",
            "D’après mes informations, le chemin se trouve le long de la paroie Est ",
            "Va voir Mémé Pale, elle a peut être remarqué quelque chose…et dis lui que je l’aime.",
            "Adieu l’ami !"
        }
        // Ajoutez autant de tableaux de dialogues que nécessaire
    };
    private string[][] dialogueChefPou = {
        new string[] { "Bonjour étranger !",
            "Je ne suis pas disponible pour le moment",
            "Veuillez m'excuser"
        },
        new string[] { "Bonjour étranger ! Qu’est-ce qui te ferait plaisir ? ", 
            "Comment ? Mémé Pale ? Une mission ? Cela me semble bien complexe.",
            "Tu as besoin de l’aide de Pépé Pale, c’est ça ?",
            "Je ne sais pas où il est, en revanche, je sais qui pourra t’aider",
            "As-tu déjà entendu parler de Calypso Gloutentacule ?.",
            "Oh je vois, Mémé ne t’as rien raconté sur cette région et ses habitants, c’est ça ?",
            "Oh Oh ! Laisse moi t’en dire plus !",
            "Ici, tu te trouves dans la ville des gourmets. Nous sommes connus pour nos plats divins et notre sens du commerce.", 
            "A l’est et à l’ouest, tu trouveras deux villages Tritons.",
            "Au Sud Ouest se trouve le village des enchanteresses.",
            "Elles n’aiment pas beaucoup les étrangers mais elles pourront peut être t’aider.",
            "Essaie de ne pas t’aventurer trop profondément, on ne sait jamais ce qu’on peut trouver dans les profondeurs de l’océan.",
            " Voilà ! Si tu as besoin de quelque chose d’autre, n’hésite pas !"
        },
        new string[] { "Oh ! Te revoilà ! Que puis-je faire pour toi ?",
            "Une omelette ? Pour Calypso ? Bien sûr !",
            "Ho Ho ! Je ne savais pas que ma cuisine était si réputée !",
            "*Le Chef Pou vous donne une omelette*" ,
            "Tiens voilà !"
        },
        new string[] { "Si tu as besoin d'un ravitaillement, tu sais où me trouver !"
        },
        new string[] { "Tu as encore besoin d’une omelette ?",
            "C’est comme si c’était fait !",
            "*Le Chef Pou vous redonne une omelette*" ,
            "Et voilà le travail ! "
        }
                 // Ajoutez autant de tableaux de dialogues que nécessaire
    };
    private string[][] dialogueCalypso = {
        new string[] { "Ne me parle pas étranger !",
            "A moins que tu ais de bonne raisons de venir me déranger ?",
            "Hmm... c'est bien ce que je pensais"
        },
        new string[] { "Qu’est ce que tu regardes créature ?",
            "Tu cherches quelqu’un…Hum…Tu as de quoi payer ?",
            "Non je ne parle pas d’argent. Je veux goûter la célèbre omelette du chef Pou !",
            "Revient me voir quand tu en auras." 
        },
        new string[] { "*Vous donnez l'omelette à Calyspo Gloutentacule*",
            "Merci créature. Tu veux trouver qui ?",
            "Ouais, je peux t’aider. Laisse moi regarder avec mes informateurs." ,
            "Allo ? Pépé Pale. Hum. Oui. Merci.",
            "Il se trouve au village triton à l’ouest. Maintenant dégage."
        },
        new string[] { "*Tu veux de mon aide ?*",
            "Et tu as de quoi payer ?",
            "Tu connais le prix créature, pas d'omelette, pas d'aide."
        },
        new string[] { "*Vous redonnez l'omelette à Calyspo Gloutentacule*",
            "La gemme des gourmets ? Le trésor des rois, rien que ça !",
            "Tout le monde sait que c’est la princesse Encreva Furtiflimb qui l’a",
            "Où est-elle ? Surement dans la grande grotte au Sud Est, c’est son endroit préféré."
        }
                 // Ajoutez autant de tableaux de dialogues que nécessaire
    };
    private string[][] dialogueThalassin = {
        new string[] { "Quelle créature immonde es-tu ?",
            "Non, enfait je n'ai pas le temps de m'y intéresser.",
            "Hors de ma vue !"
        },
        new string[] { "Ouh ! Tu serais parfait pour ma collection d’abomination !",
            "COMMENT ?! MA GEMME ?! Jamais ! ",
            "Dégage de là sale monstre !"
        }
                 // Ajoutez autant de tableaux de dialogues que nécessaire
    };
    private string[][] dialogueEncreva = {
        new string[] { "Oh ! Un nouvel ami ?",
            "Non ? Comment ça, non ? Joue avec moi ! Maintenant !",
            "Tu ne veux pas ?? Méchant !"
        },
        new string[] { "Oh ! Un nouvel ami ?",
            "Non ? Comment ça, non ? Joue avec moi ! Maintenant !",
            "Tu ne veux pas ?? Méchant !",
            "Si tu joues avec moi et que tu gagnes, je te donne ce que tu veux ",
            "Joue avec moi s’il te plaiit !",
            "Ouiii ! Tu as 10 secondes pour te cacher dans la grotte, si je te trouve tu perds.",
            "C’est partiiii"
        },
        new string[] { "T’es trop fort toi, dis donc ! Je suis sûre que t’as triché !",
            "Heureusement pour toi, une princesse tient toujours parole !",
            "Mon collier ? Cette vieille babiole de ma mère ? Bien sûr, tiens ! ",
            "Reviens jouer quand tu veux copain !"
        }
                 // Ajoutez autant de tableaux de dialogues que nécessaire
    };
    private string[][] dialogueSilphydra = {
        new string[] { "Tu n'es pas le bienvenue ici étranger.."
        },
        new string[] { "Notre gemme ? Toi, un étranger, tu oses réclamer notre précieuse gemme ?",
            "Heureusement pour toi, nous l’avons perdu, sinon je t’aurais fait tuer pour cet affront !",
            "Un chasseur de prime nous l’a volé puis a été tué par une bande de monstres…comme toi.",
            "Haha, tu penses pouvoir la récupérer ? Va au Sud de l’immense grotte près du village triton",
            "Nous verrons si tu auras encore envie de l’avoir…"
        }
                 // Ajoutez autant de tableaux de dialogues que nécessaire
    };
    private string[][] dialogueNéhérida = {
        new string[] { "Hello l’ami ! Tu n’aurais pas un projet de couture pour moi ? J’ai besoin de m’entraîner !",
            "Hesite pas à faire appel à mes services si jamais tu as besoin d'une couturière !"
        },
        new string[] { "Hello l’ami ! Tu n’aurais pas un projet de couture pour moi ? J’ai besoin de m’entraîner !",
            "Ouuuuh, un déguisement pour t’infiltrer dans une meute sanguinaire ? Ca a l’air amusant !",
            "Donne moi un instant.",
            "*coupe coupe* *tchac tchac* *criiish* *coupe coupe*",
            "Et voilà le travail ! Je te le donne à condition que tu vantes mes mérites si jamais on te complimente dessus",
            "Bon courage l’ami, reviens me voir quand tu veux !"
        }
                 // Ajoutez autant de tableaux de dialogues que nécessaire
    };
    
    public float textSpeed;
    private bool isInRange_MemePale;
    private bool isInRange_PepePale;
    private bool isInRange_ChefPou;
    private bool isInRange_Calypso;
    private bool isInRange_Thalassin;
    public bool isInRange_Encreva;
    private bool isInRange_Silphydra;
    private bool isInRange_Néhérida;
    public bool isDialogueActive;
    private bool quetepart0;
    private bool quetepart1;
    private bool quetepart2;
    private bool quetepart3;
    private bool quetepart4;
    private bool quetepart5;
    private bool quetepart6;
    private bool quetepart7;
    private bool quetepart8;
    private bool quetepart9;
    private bool quetepart10;
    private bool quetepart11;
    private bool quetepart12;
    private bool quetepart13;
    private bool quetepart14;
    private bool quetepart15;
    private bool quetepart16;
    private bool quetepart17;
    private bool quetepart18;
    private bool quetepart19;
    private bool quetepart20;
    private int index_MemePale;
    private int index_PepePale;
    private int index_ChefPou;
    private int index_Calypso;
    private int index_Thalassin;
    private int index_Encreva;
    private int index_Silphydra;
    private int index_Néhérida;
    private int currentDialogindex_MemePale; // Suivre l'index du tableau de dialogue actuel
    private int currentDialogindex_PepePale;
    private int currentDialogindex_ChefPou;
    private int currentDialogindex_Calypso;
    private int currentDialogindex_Thalassin;
    private int currentDialogindex_Encreva;
    private int currentDialogindex_Silphydra;
    private int currentDialogindex_Néhérida;
    public GameObject dialoguebox;
    
    [SerializeField]
    private Defi_Cache_Cache defiCacheCache;

    // Start is called before the first frame update
    public void Start()
    {
        quetepart1 = true;
        quetepart2 = true;
        quetepart3 = true;
        quetepart4 = true;
        quetepart5 = true;
        quetepart6 = true;
        quetepart7 = true;
        quetepart8 = true;
        quetepart9 = true;
        quetepart10 = true;
        quetepart11 = true;
        quetepart12 = true;
        quetepart13 = true;
        quetepart14 = true;
        quetepart15 = false;
        quetepart16 = false;
        quetepart17 = false;
        quetepart18 = false;
        quetepart19 = false;
        quetepart20 = false;
        isInRange_MemePale = false;
        isInRange_PepePale = false;
        isInRange_ChefPou = false;
        isInRange_Calypso = false;
        isInRange_Thalassin = false;
        isInRange_Encreva = false;
        isInRange_Silphydra = false;
        isInRange_Néhérida = false;
        isDialogueActive = false;
        textComponent.text = string.Empty;
        dialoguebox.SetActive(false);
        index_MemePale = 0;
        index_PepePale = 0;
        currentDialogindex_MemePale = 0; // Initialisez l'index du tableau de dialogue actuel
        currentDialogindex_PepePale = 0; // Initialisez l'index du tableau de dialogue actuel
        currentDialogindex_ChefPou = 0;
        currentDialogindex_Calypso = 0;
        currentDialogindex_Thalassin = 0;
        currentDialogindex_Encreva = 0;
        currentDialogindex_Silphydra = 0;
        currentDialogindex_Néhérida = 0;
    }

    // Update is called once per frame
    void Update(){
        if (isDialogueActive == false){
             if (Input.GetKeyDown(interactKey)){
                if(isInRange_MemePale||isInRange_PepePale||isInRange_ChefPou||isInRange_Calypso||isInRange_Thalassin||isInRange_Encreva||isInRange_Silphydra||isInRange_Néhérida){
                    Debug.Log("lalalal");
                    dialoguebox.SetActive(true);
                    isDialogueActive = true;
                    StartCoroutine(TypeLine());
                }
            }
        }
        else{
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)){
                if(isInRange_MemePale){
                    if (textComponent.text == dialogueMemePale[currentDialogindex_MemePale][index_MemePale]){
                        NextLine();
                    }
                    else{
                        StopAllCoroutines();
                        textComponent.text = dialogueMemePale[currentDialogindex_MemePale][index_MemePale];
                    }
                }else if(isInRange_PepePale){
                    if (textComponent.text == dialoguePepePale[currentDialogindex_PepePale][index_PepePale]){
                        NextLine();
                    }
                    else{
                        StopAllCoroutines();
                        textComponent.text = dialoguePepePale[currentDialogindex_PepePale][index_PepePale];
                    }
                }
                else if(isInRange_ChefPou){
                    if (textComponent.text == dialogueChefPou[currentDialogindex_ChefPou][index_ChefPou]){
                        NextLine();
                    }
                    else{
                        StopAllCoroutines();
                        textComponent.text = dialogueChefPou[currentDialogindex_ChefPou][index_ChefPou];
                    }
                }
                else if(isInRange_Calypso){
                    if (textComponent.text == dialogueCalypso[currentDialogindex_Calypso][index_Calypso]){
                        NextLine();
                    }
                    else{
                        StopAllCoroutines();
                        textComponent.text = dialogueCalypso[currentDialogindex_Calypso][index_Calypso];
                    }
                }
                else if(isInRange_Thalassin){
                    if (textComponent.text == dialogueThalassin[currentDialogindex_Thalassin][index_Thalassin]){
                        NextLine();
                    }
                    else{
                        StopAllCoroutines();
                        textComponent.text = dialogueThalassin[currentDialogindex_Thalassin][index_Thalassin];
                    }
                }
                else if(isInRange_Encreva){
                    if (textComponent.text == dialogueEncreva[currentDialogindex_Encreva][index_Encreva]){
                        NextLine();
                    }
                    else{
                        StopAllCoroutines();
                        textComponent.text = dialogueEncreva[currentDialogindex_Encreva][index_Encreva];
                    }
                }
                else if(isInRange_Silphydra){
                    if (textComponent.text == dialogueSilphydra[currentDialogindex_Silphydra][index_Silphydra]){
                        NextLine();
                    }
                    else{
                        StopAllCoroutines();
                        textComponent.text = dialogueSilphydra[currentDialogindex_Silphydra][index_Silphydra];
                    }
                }
                else if(isInRange_Néhérida){
                    if (textComponent.text == dialogueNéhérida[currentDialogindex_Néhérida][index_Néhérida]){
                        NextLine();
                    }
                    else{
                        StopAllCoroutines();
                        textComponent.text = dialogueNéhérida[currentDialogindex_Néhérida][index_Néhérida];
                    }
                }
            }
        }
    }

    public IEnumerator TypeLine(){
        textComponent.text = string.Empty;
        if(isInRange_MemePale){
            foreach (char c in dialogueMemePale[currentDialogindex_MemePale][index_MemePale].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }else if(isInRange_PepePale){
            foreach (char c in dialoguePepePale[currentDialogindex_PepePale][index_PepePale].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }else if(isInRange_ChefPou){
            foreach (char c in dialogueChefPou[currentDialogindex_ChefPou][index_ChefPou].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else if(isInRange_Calypso){
            foreach (char c in dialogueCalypso[currentDialogindex_Calypso][index_Calypso].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else if(isInRange_Thalassin){
            foreach (char c in dialogueThalassin[currentDialogindex_Thalassin][index_Thalassin].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else if(isInRange_Encreva){
            foreach (char c in dialogueEncreva[currentDialogindex_Encreva][index_Encreva].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else if(isInRange_Silphydra){
            foreach (char c in dialogueSilphydra[currentDialogindex_Silphydra][index_Silphydra].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else if(isInRange_Néhérida){
            foreach (char c in dialogueNéhérida[currentDialogindex_Néhérida][index_Néhérida].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    void NextLine(){
        if(isInRange_MemePale){
            if (index_MemePale < dialogueMemePale[currentDialogindex_MemePale].Length - 1){
                index_MemePale++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }else{
                EndDialogue();
            }
        }else if (isInRange_PepePale){
            if(index_PepePale < dialoguePepePale[currentDialogindex_PepePale].Length - 1){
                index_PepePale++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }else{
                EndDialogue();
            }
         }else if (isInRange_ChefPou){
            if(index_ChefPou < dialogueChefPou[currentDialogindex_ChefPou].Length - 1){
                index_ChefPou++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }else{
                EndDialogue();
            }
         }else if (isInRange_Calypso){
            if(index_Calypso < dialogueCalypso[currentDialogindex_Calypso].Length - 1){
                index_Calypso++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }else{
                EndDialogue();
            }
         }else if (isInRange_Thalassin){
            if(index_Thalassin < dialogueThalassin[currentDialogindex_Thalassin].Length - 1){
                index_Thalassin++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }else{
                EndDialogue();
            }
         }else if (isInRange_Encreva){
            if(index_Encreva < dialogueEncreva[currentDialogindex_Encreva].Length - 1){
                index_Encreva++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }else{
                EndDialogue();
            }
         }else if (isInRange_Silphydra){
            if(index_Silphydra < dialogueSilphydra[currentDialogindex_Silphydra].Length - 1){
                index_Silphydra++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }else{
                EndDialogue();
            }
         }else if (isInRange_Néhérida){
            if(index_Néhérida < dialogueNéhérida[currentDialogindex_Néhérida].Length - 1){
                index_Néhérida++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }else{
                EndDialogue();
            }
         }
        
    }

    void EndDialogue(){
        textComponent.text = string.Empty;
        isDialogueActive = false;
        dialoguebox.SetActive(false);
        // Passez au tableau de dialogue suivant (si disponible)
        if(isInRange_MemePale){
            index_MemePale = 0;  
            if(quetepart20==true){
                //interagir avec la roche et fin de jeu
            }
            else if(quetepart6==true && quetepart7==false){
                quetepart7 = true;
                currentDialogindex_PepePale++;
            }
            else if(quetepart0==false&& quetepart1==false){
                quetepart1 = true;
                currentDialogindex_ChefPou++;
            }
        }else if(isInRange_PepePale){
            index_PepePale = 0;
            if(quetepart19==true){
                quetepart20=true;
                currentDialogindex_MemePale++; 
            } 
            else if(quetepart17==true && quetepart18==false){
                quetepart18=true;
                currentDialogindex_Néhérida++; 
            } 
            else if(quetepart15==true && quetepart16==false){
                quetepart16=true;
                currentDialogindex_Silphydra++; 
            } 
            else if(quetepart10==true && quetepart11==false){
                quetepart11=true;
                currentDialogindex_Calypso++; 
            } 
            else if(quetepart9==true && quetepart10==false){
                quetepart10=true;
                //if on a volé la gemme
                currentDialogindex_PepePale++; 
            } 
            else if(quetepart7==true && quetepart8==false){
                quetepart8=true;
                currentDialogindex_Thalassin++;
            }
            else if(quetepart5==true && quetepart6==false){
                quetepart6=true;
                currentDialogindex_MemePale++;
            }
        }else if(isInRange_ChefPou){
            index_ChefPou = 0;
            if(quetepart12 == true && quetepart13==false){
                quetepart13=true;
                currentDialogindex_Calypso++;
            }
            else if(quetepart3 == true && quetepart4==false){
                quetepart4=true;
                currentDialogindex_Calypso++;
                currentDialogindex_ChefPou++;
            }
            else if(quetepart1 == true && quetepart2==false){
                quetepart2=true;
                currentDialogindex_Calypso++;
            }
        }else if(isInRange_Calypso){
            index_Calypso = 0;
            if(quetepart13 == true && quetepart14==false){
                quetepart14=true;
                currentDialogindex_Encreva++;
            }
            else if(quetepart11 == true && quetepart12==false){
                quetepart12=true;
                currentDialogindex_ChefPou++;
            }
            else if(quetepart4 == true && quetepart5==false){
                quetepart5=true;
                currentDialogindex_PepePale++;
            }
            else if(quetepart2 == true && quetepart3==false){
                quetepart3=true;
                currentDialogindex_ChefPou++;
            }
        }
        else if(isInRange_Thalassin){
            index_Thalassin = 0;
            if(quetepart8== true && quetepart9==false){
                quetepart9=true;
                currentDialogindex_PepePale++;
            }
        }
        else if(isInRange_Encreva){
            index_Encreva = 0;
            if(quetepart14==true && quetepart15==false){
                quetepart15 = true;
                Debug.Log(currentDialogindex_Encreva);
                //Cache cache pour gagner la deuxieme gemme
                currentDialogindex_Encreva++;
                currentDialogindex_PepePale++;
                defiCacheCache.cacheCacheActif = true;
                Debug.Log("tetststg");
                
                if (defiCacheCache.cacheCacheGagne) {
                    Debug.Log("lacbon");
                    currentDialogindex_Encreva++;
                }
            }
        }
        else if(isInRange_Silphydra){
            index_Silphydra = 0;
            if(quetepart16==true && quetepart17==false){
                quetepart17=true;
                //if pp meurt de la meute
                currentDialogindex_PepePale++;
            }
        }else if(isInRange_Néhérida){
            index_Néhérida = 0;
            if(quetepart18==true && quetepart19==false){
                quetepart19=true;
                //if pp a recupéré la troisième gemme
                currentDialogindex_PepePale++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Meme Pale")){
            isInRange_MemePale = true;
        }
        else if (collision.gameObject.CompareTag("Pepe Pale"))
        {
            isInRange_PepePale = true;
        }
        else if (collision.gameObject.CompareTag("Chef Pou"))
        {
            isInRange_ChefPou = true;
        }
        else if (collision.gameObject.CompareTag("Calypso Gloutentacule"))
        {
            isInRange_Calypso = true;
        }
        else if (collision.gameObject.CompareTag("Thalassin Perlefonds"))
        {
            isInRange_Thalassin = true;
        }
        else if (collision.gameObject.CompareTag("Encreva Furtiflimb"))
        {
            Debug.Log("inrange");
            isInRange_Encreva = true;
        }
        else if (collision.gameObject.CompareTag("Silphydra Océanara"))
        {
            isInRange_Silphydra = true;
        }
        else if (collision.gameObject.CompareTag("Néhérida Tisselune"))
        {
            isInRange_Néhérida = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Meme Pale")){
            isInRange_MemePale = false;

        }else if (collision.gameObject.CompareTag("Pepe Pale")){
            isInRange_PepePale = false;
        }
        else if (collision.gameObject.CompareTag("Chef Pou"))
        {
            isInRange_ChefPou = false;
        }
        else if (collision.gameObject.CompareTag("Calypso Gloutentacule"))
        {
            isInRange_Calypso = false;
        }
        else if (collision.gameObject.CompareTag("Thalassin Perlefonds"))
        {
            isInRange_Thalassin = false;
        }
        else if (collision.gameObject.CompareTag("Encreva Furtiflimb"))
        {
            isInRange_Encreva = false;
        }
        else if (collision.gameObject.CompareTag("Silphydra Océanara"))
        {
            isInRange_Silphydra = false;
        }
        else if (collision.gameObject.CompareTag("Néhérida Tisselune"))
        {
            isInRange_Néhérida = false;
        }
    }
}
