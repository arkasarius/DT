using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum SelectionState { ATTACK, ITEM, SPECIAL }
public class CombatManager : MonoBehaviour
{

    public TMP_Text CombatText;
    public Image L_Image, C_Image, R_Image;
    public Sprite S_attack, S_item, S_special;
    public SelectionState Sstate;
    public AudioSource audioSource;


    private void Start()
    {
        Sstate = SelectionState.ATTACK;

    }

    public void OnPressLeft() 
    {
        switch (Sstate)
        {
            case SelectionState.ATTACK:
                Sstate = SelectionState.SPECIAL;
                break;
            case SelectionState.ITEM:
                Sstate = SelectionState.ATTACK;
                break;
            case SelectionState.SPECIAL:
                Sstate = SelectionState.ITEM;
                break;
            default:
                break;
        }
        UpdateUI();
        audioSource.Play();
    }

    public void OnPressRight() 
    {
        switch (Sstate)
        {
            case SelectionState.ATTACK:
                Sstate = SelectionState.ITEM;
                break;
            case SelectionState.ITEM:
                Sstate = SelectionState.SPECIAL;
                break;
            case SelectionState.SPECIAL:
                Sstate = SelectionState.ATTACK;
                break;
            default:
                break;
        }
        UpdateUI();
        audioSource.Play();
    }

    void UpdateUI()
    {
        switch (Sstate)
        {
            case SelectionState.ATTACK:
                L_Image.sprite = S_special;
                C_Image.sprite = S_attack;
                R_Image.sprite = S_item;
                CombatText.text = "Attack";
                print("attack!");
                break;
            case SelectionState.ITEM:
                L_Image.sprite = S_attack;
                C_Image.sprite = S_item;
                R_Image.sprite = S_special;
                CombatText.text = "ITEM";
                print("Item!");
                break;
            case SelectionState.SPECIAL:
                L_Image.sprite = S_item;
                C_Image.sprite = S_special;
                R_Image.sprite = S_attack;
                CombatText.text = "Special";
                print("Special!");
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnPressLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnPressRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnpressSpace();
        }

    }

    private void OnpressSpace()
    {
        audioSource.Play();
        print("Space!");
    }
}
