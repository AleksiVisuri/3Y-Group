using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Elevator : MonoBehaviour, IInteraction
{
    //Allun iltasekoilua
    // Pelaajan sy�tt�m� numerosarja hissiin
    [SerializeField] private TMP_InputField passCodeInputField;
    [SerializeField] private CodeTag codeTag;
    static bool isActive = false;
    //public TextMeshProUGUI playerInput;

    [SerializeField] Animator elevatorAnimator;




    // Kun pelaaja interactaa hissin kanssa, h�n sy�tt�� 4-numeroisen
    // sarjan numeroita hissikoodiksi, jos t�m� on oikein (ja sama mit� koodilapussa),
    // pystyy pelaaja kulkemaan hissill�
    public void Interact()
    {

        if (!isActive)
        {
            passCodeInputField.gameObject.SetActive(true);
            isActive = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Aktivoitu UI");
        }
        else
        {
            passCodeInputField.gameObject.SetActive(false);
            isActive = false;
            Cursor.lockState = CursorLockMode.Locked;
            CheckCode();
            Debug.Log("Deaktivoitu UI");
        }
        /*passCodeInputField.SetActive(true);
        passCodeInputField.GetComponent("Text");
         
        
        if (playerInput == randomInput && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Check Success");
        }*/

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CheckCode()
    {
        if (codeTag.codeStorage != passCodeInputField.text)
            return;

        //Debug.Log("Hissi avautuu");
        // Aloita hissi-animaatio
        // Sulje ovet
        // Elevator open doors
        elevatorAnimator.SetBool("canOpen", true);

        //ELI kun pelaaja saa koodin auki, hissi avautuu,
        //oottaa 2 sekkaa,(kun osuu collideriin (katso ElevatorTP)) hissi sulkeutuu ja kun pelaaja on teleportattu,
        //toisen hissin ovi avautuu ja kun on ulkona(tarvitaan collider) tyylii ovi suljetaan esim.

        //elevatorAnimator.SetBool("canOpen", false);

        //elevatorAnimator.SetBool("canClose", true);

        //elevatorAnimator.SetBool("canClose", false);
        // Joku pelaajan teleporttaus sek� pieni viive
        // Avaa seuraavan kerroksen ovet
        // Sulje niiden ovet
    }
}
