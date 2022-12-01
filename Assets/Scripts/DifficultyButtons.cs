using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    [SerializeField] public static int difficulty = 2;
    public Button easy, normal, hard;
    // Start is called before the first frame update
    public void OnPress(Button button)
    {
        Dictionary<Button, Action> setDifficulty = new Dictionary<Button, Action>
        {
            {easy, () => SetValue(1)},
            {normal, () => SetValue(2)},
            {hard, () => SetValue(3)}
        };


        setDifficulty[button]();   
    }
    public void SetValue(int diff)
    {
        difficulty = diff;
    }
}
