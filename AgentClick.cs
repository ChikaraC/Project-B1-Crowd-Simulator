using System.Collections.Generic;
using UnityEngine;

public class AgentClick : MonoBehaviour
{
    private Camera myCam;
    public LayerMask clickable;
    public LayerMask ground;
    void Start()
    {
        myCam = Camera.main;
    }
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    AgentSelections.Instance.CtrlClickSelect(hit.collider.gameObject);
                }
                else
                {
                    AgentSelections.Instance.ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    AgentSelections.Instance.DeselectAll();
                }   
            }
        } 
    }
}
