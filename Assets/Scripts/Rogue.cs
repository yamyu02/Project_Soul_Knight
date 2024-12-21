using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rogue : Character
{
    [SerializeField]
    public Animator Ani;

    private int _charge;
    public Rogue(int Health, int Armor) : base(Health, Armor)
    {

    }

    void Start()
    {
        SetHealth(6);
        SetArmor(4);
        this._charge = 1;
}
    void Update()
    {
        Call();
        Roll(); 
        CheckCharge();
    }

    private void Awake()
    {
        Ani = GetComponent<Animator>();

    }

    private void Roll()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (this._charge > 0)
            {
                SetiFrame(true);
                Debug.Log("Rolling");
                SetMoveForce(15);
                Ani.SetBool("Roll", true);

                this._charge--; 
                StartCoroutine(ResetMoveForceAfterTime(0.4f));
            }
        }

        else
        {
            Ani.SetBool("Roll", false);
            
        }
    }
    //Help from AI
    private IEnumerator ResetMoveForceAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetMoveForce(6);
        SetiFrame(false);
    }

    private bool _regenerating = false;
    private void CheckCharge()
    {
        if (this._charge <1 && this._regenerating == false)
        {
            Debug.Log("Regenerating!!");
            StartCoroutine(RegenrateCharge(1.5f));
            this._regenerating = true;
        }
    }

    private IEnumerator RegenrateCharge(float delay)
    {
        yield return new WaitForSeconds(delay);
        this._charge++;
        this._regenerating = false;
    }

}
