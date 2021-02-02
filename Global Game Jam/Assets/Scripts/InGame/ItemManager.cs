using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{

    [SerializeField]
    private GameObject paper = null;

    [SerializeField]
    private Text cellphones = null;

    [SerializeField]
    private Text books = null;

    [SerializeField]
    private Text creditCard = null;

    private int cellRequired = 4;
    private int bookRequired = 3;
    private int creditRequired = 4;

    public int cellAmount;
    public int booksAmount;
    public int creditAmount;

    private int cellRemains;
    private int bookRemains;
    private int creditRemains;

    private float timer;

    public List<int> objectTaken;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cellRemains = cellRequired - cellAmount;
        bookRemains = bookRequired - booksAmount;
        creditRemains = creditRequired - creditAmount;

        cellphones.text = cellRemains.ToString();
        books.text = bookRemains.ToString();
        creditCard.text = creditRemains.ToString();

        SeePaper();
        WinCondition();
    }


    private void SeePaper()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (paper.activeSelf)
            {
                paper.SetActive(false);
            }
            else if (!paper.activeSelf)
            {
                paper.SetActive(true);
            }


        }
    }

    public void CollectItens(int layer)
    {
        if (layer == 10)
        {

            cellAmount += 1;

        }
        if (layer == 11)
        {

            booksAmount += 1;
        }
        if (layer == 12)
        {

            creditAmount += 1;
        }

    }

    private void WinCondition()
    {
        if (cellAmount == 3 && booksAmount == 4 && creditAmount == 4)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                SceneManager.LoadSceneAsync(2);
            }


        }
    }






}
