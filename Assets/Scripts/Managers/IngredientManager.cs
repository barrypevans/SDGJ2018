using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{

    public static IngredientManager Instance;

    private void Awake()
    {
        if (null == Instance)
            Instance = this;
        else
            Destroy(this);
    }

    public GameObject[] Ingredients;
    public Dictionary<string, GameObject> IngredientsIDs_To_IngredientPrefab = new Dictionary<string, GameObject>();
    public GameObject[] IngredientSpawns_Left;
    public GameObject[] IngredientSpawns_Right;
    private List<GameObject> m_lst_pIngredientSpawnersAvailable_Left;
    private List<GameObject> m_lst_pIngredientSpawnersAvailable_Right;

    public GameObject CurrentIngredient_Left;
    public GameObject CurrentIngredient_Right;
    public IngredientIndicator IngredientIndicator_Left;
    public IngredientIndicator IngredientIndicator_Right;

    public int IngredientMatchScoreGain;
    public int IngredientMismatchedScoreLoss;
    public int IngredientMissPotScoreLoss;

    public ExpresionManager[] expressionManager;

    // Use this for initialization
    void Start ()
    {
        m_lst_pIngredientSpawnersAvailable_Left = new List<GameObject>(IngredientSpawns_Left);
        m_lst_pIngredientSpawnersAvailable_Right = new List<GameObject>(IngredientSpawns_Right);

        foreach (GameObject g in IngredientSpawns_Left)
            g.GetComponent<IngredientSpawner>().expressionManager = expressionManager[0];
        foreach (GameObject g in IngredientSpawns_Right)
            g.GetComponent<IngredientSpawner>().expressionManager = expressionManager[1];

        foreach (GameObject gameObject in Ingredients)
        {
            IngredientsIDs_To_IngredientPrefab.Add(gameObject.GetComponent<Ingredient>().ID, gameObject);
            this.SpawnIngredientAtRandomSpawnerLeft(gameObject);
            this.SpawnIngredientAtRandomSpawnerRight(gameObject);
        }

        this.SetIngredient();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetIngredient(int iPlayerIndex = -1)
    {
        if (iPlayerIndex == 0 || iPlayerIndex == -1)
        {
            CurrentIngredient_Left = GetRandomIngredient();
            IngredientIndicator_Left.SetIngredient(CurrentIngredient_Left.GetComponent<Ingredient>());
        }
        if (iPlayerIndex == 1 || iPlayerIndex == -1)
        {
            CurrentIngredient_Right = GetRandomIngredient();
            IngredientIndicator_Right.SetIngredient(CurrentIngredient_Right.GetComponent<Ingredient>());
        }
    }

    public GameObject GetRandomIngredient()
    {
        return Ingredients[Random.Range(0, Ingredients.Length)];
    }

    public void SpawnIngredientAtRandomSpawnerLeft(GameObject pIngredientPrefab)
    {
        if (m_lst_pIngredientSpawnersAvailable_Left.Count > 0)
        {
            GameObject pSpawner = m_lst_pIngredientSpawnersAvailable_Left[Random.Range(0, m_lst_pIngredientSpawnersAvailable_Left.Count)];
            m_lst_pIngredientSpawnersAvailable_Left.Remove(pSpawner);
            pSpawner.GetComponent<IngredientSpawner>().SpawnIngredient(pIngredientPrefab);
        }
    }

    public void SpawnIngredientAtRandomSpawnerRight(GameObject pIngredientPrefab)
    {
        if (m_lst_pIngredientSpawnersAvailable_Right.Count > 0)
        {
            GameObject pSpawner = m_lst_pIngredientSpawnersAvailable_Right[Random.Range(0, m_lst_pIngredientSpawnersAvailable_Right.Count)];
            m_lst_pIngredientSpawnersAvailable_Right.Remove(pSpawner);
            pSpawner.GetComponent<IngredientSpawner>().SpawnIngredient(pIngredientPrefab);
        }
    }

    public void MarkSpawnerAvailableAndSpawnIngredientAtRandomSpawner(IngredientSpawner pSpawner, string strIngredientID)
    {
        if (pSpawner.PlayerID == 0)
        {
            m_lst_pIngredientSpawnersAvailable_Left.Add(pSpawner.gameObject);
            SpawnIngredientAtRandomSpawnerLeft(IngredientsIDs_To_IngredientPrefab[strIngredientID]);
        }
        else
        {
            m_lst_pIngredientSpawnersAvailable_Right.Add(pSpawner.gameObject);
            SpawnIngredientAtRandomSpawnerRight(IngredientsIDs_To_IngredientPrefab[strIngredientID]);
        }
    }
}
