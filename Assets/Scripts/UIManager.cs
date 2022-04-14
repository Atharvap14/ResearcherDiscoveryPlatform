using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   // Functionalities of Buttons defined in Result View have been written
   
    // Back Button changes the scene to previous scene
    public void Back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    // This function ranks the data in database based on h-index
    public void hindex()
    {
        RankingFilteringModule.rank(RankingFilteringModule.criteria.indice_h);
    }

    // This function ranks the data in database based on i10-index
    public void i10index()
    {
        RankingFilteringModule.rank(RankingFilteringModule.criteria.indice_i10);
    }

    // This function ranks the data in database based on total citations
    public void cit()
    {
        RankingFilteringModule.rank(RankingFilteringModule.criteria.citations);
    }

    // This function ranks the data in database based on number of articles in public access
    public void publicacess()
    {
        RankingFilteringModule.rank(RankingFilteringModule.criteria.publicavail);
    }
}
