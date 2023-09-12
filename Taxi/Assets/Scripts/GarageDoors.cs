using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoors : MonoBehaviour
{
    [SerializeField] private Animator animator;


    private void OnTriggerStay(Collider other)
    {
        animator.SetBool("Open", true); UnityEngine.Debug.Log("AnimacjaOtwierania"); 
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Open", false);
        UnityEngine.Debug.Log("AnimacjaZamykania");
    }
}
