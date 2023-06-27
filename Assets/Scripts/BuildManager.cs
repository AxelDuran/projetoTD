using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    private GameObject turrentToBuild;

    private void Awake()
    {
        if (turrentToBuild != null)
        {
            Debug.LogError("Mais de um build managers na cena");
            return;
        }
        instance = this;
    }

    public GameObject standartTurret;

    private void Start()
    {
        turrentToBuild = standartTurret;
    }

    private GameObject turreToBuild;
    public GameObject GetTurretToBuild()
    {
        return turrentToBuild;
    }
}
