using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private GameObject currentMonke;

    void Update()
    {
        if(currentMonke != null)
        {
            Ray camray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(camray, out RaycastHit hitInfo, 100f))
            {
                if (hitInfo.collider.tag == "Ground")
                {
                    currentMonke.transform.position = new Vector3(hitInfo.point.x, currentMonke.transform.position.y, hitInfo.point.z);
                }
            }

            if(Input.GetMouseButtonDown(0))
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