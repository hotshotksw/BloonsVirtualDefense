using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class TowerPlacer : MonoBehaviour
{
    private GameObject currentMonke;
    public GameObject Controller;
    public InputActionReference triggerInputActionReference;

    void Update()
    {
        if(currentMonke != null)
        {
            //Ray camray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Controller.transform.position, Controller.transform.forward, Color.yellow);
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 10f))
            {
                if (hitInfo.collider.tag == "Ground")
                {
                    currentMonke.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
                }
            }

            if(triggerInputActionReference.action.ReadValue<float>() != 0)
            {
                currentMonke = null;
            }
        }
    }

    public void SetTowerToPlace(GameObject tower)
    {
        currentMonke = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
}

/*
    public Color hoverColor;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
*/