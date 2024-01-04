using Assets.DataAccess.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour, ISceneTransition
{
    public int id;
    public void Transition()
    {
        SceneManager.LoadScene(id);
    }
}
