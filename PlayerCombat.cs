using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class PlayerCombat : MonoBehaviour
{
    public NavMeshAgent _agent;
    public bool isAttacking = false;
    public Enemy targetEnemy;


    [SerializeField] private float attackSpeed = 3f;
    [SerializeField]private float distance;
    
    
    

 
    // Update is called once per frame
    void Update()
    {
        PlayerAttack();
    }


    void PlayerAttack()
    {
        if (Input.GetMouseButton(0))
        {
            Ray attackEnemy = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(attackEnemy, out var hitInfo) && hitInfo.collider.CompareTag("Enemy"))
            {
                _agent.destination = hitInfo.point;
                targetEnemy = hitInfo.collider.gameObject.GetComponent<Enemy>();
                
                

            }
            
        }
        if (IsInRange() && targetEnemy.currentHealth > 0)
        {
            
            StartCoroutine(Attacking());

        }
        


        
    }


    public bool IsInRange()
    {
        if (targetEnemy == null) {
            return false;
        }
        else
        {
            distance = Vector3.Distance(_agent.transform.position, targetEnemy.transform.position);
        }
        
 
        if (distance < 3)
        {
            return true;
        }
        return false;
    }


    


    IEnumerator Attacking()
    {
       
        if (!isAttacking)
        {
            isAttacking = true;
            yield return new WaitForSeconds(attackSpeed);
            targetEnemy.currentHealth -= 1;
            Debug.Log("player attacked");
            Debug.Log(targetEnemy.currentHealth);
            isAttacking = false;
        }
        
        
        

    }









}
