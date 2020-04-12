using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum SelectionState { ATTACK, ITEM, SPECIAL }
public enum CombatAction { STARTING, PLAYER, ENEMY, VICTORY, DEFEAT }



public class CombatManager : MonoBehaviour
{

    public TMP_Text CombatText;
    public Image L_Image, C_Image, R_Image;
    public Sprite S_attack, S_item, S_special;
    public SelectionState Sstate;
    public AudioSource audioSource;
    public int turn = 0;
    public CombatAction combatAction;
    public GameObject canvas;

    public GameObject[] unidades;

    public Slider slider_enemy,slider_player;



    private void Start()
    {
        canvas.SetActive(false);
        StartCoroutine(setup());

    }
    IEnumerator setup()
    {
        unidades = GameObject.FindGameObjectsWithTag("UNIT");
        GameObject temp;
        for (int i = 0; i < (unidades.Length - 1); i++)
        {
            for (int j = 0; j < unidades.Length - i - 1; j++)
            {
                if (unidades[j].GetComponent<Stats>().SP  < unidades[j + 1].GetComponent<Stats>().SP)
                {
                    temp = unidades[j];
                    unidades[j] = unidades[j + 1];
                    unidades[j + 1] = temp;
                }
            }
        }
        yield return new WaitForSeconds(1f);
        Sstate = SelectionState.ATTACK;
        FirstTurn();
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
                //print("attack!");
                break;
            case SelectionState.ITEM:
                L_Image.sprite = S_attack;
                C_Image.sprite = S_item;
                R_Image.sprite = S_special;
                CombatText.text = "ITEM";
                //print("Item!");
                break;
            case SelectionState.SPECIAL:
                L_Image.sprite = S_item;
                C_Image.sprite = S_special;
                R_Image.sprite = S_attack;
                CombatText.text = "Special";
                //print("Special!");
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (combatAction == CombatAction.PLAYER)
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


    }

    private void OnpressSpace()
    {
        audioSource.Play();
        Stats playerStats = unidades[0].GetComponent<Stats>();
        print(unidades[1].GetComponent<Stats>().Damage(playerStats.AP));
        slider_enemy.value = (float)unidades[1].GetComponent<Stats>().HP / (float)unidades[1].GetComponent<Stats>().MAXHP;
        NextTurn();
    }


    public void FirstTurn()
    {
        turn = 0;
        Stats Character = unidades[turn].GetComponent<Stats>();
        if (Character.NAME == "Muffin")
        {
            PlayerTurn();
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }
    public void NextTurn()
    {
        turn++;
        if (turn > unidades.Length - 1)
        {
            turn = 0;
        }
        Stats Character = unidades[turn].GetComponent<Stats>();
        if (Character.NAME == "Muffin")
        {
            PlayerTurn();
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    public void PlayerTurn()
    {
        print("turn del player");
        combatAction = CombatAction.PLAYER;
        canvas.SetActive(true);
    }

    IEnumerator EnemyTurn()
    {
        print("enemy turn");
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
        combatAction = CombatAction.ENEMY;
        print(unidades[0].GetComponent<Stats>().Damage(unidades[1].GetComponent<Stats>().AP));
        print((float)unidades[0].GetComponent<Stats>().HP / (float)unidades[0].GetComponent<Stats>().MAXHP);
        slider_player.value = (float)unidades[0].GetComponent<Stats>().HP / (float)unidades[0].GetComponent<Stats>().MAXHP;
        NextTurn();
    }

}

