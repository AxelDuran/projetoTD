using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;
    private Renderer rend;
  [SerializeField]  private Color startColor;
    private void Start()
    {
        rend = GetComponent<Renderer>();    
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("nao pode construir aqui! - mostrar na UI");
            return;
        }

        // construir turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    private void OnMouseEnter()
    {
        if (turret != null)
        {
          
            return;
        }
        rend.material.color = hoverColor;        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
