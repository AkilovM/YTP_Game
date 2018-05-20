using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.Windows.Forms;
using UnityEngine.SceneManagement;

public class Loading_Level_WForm : MonoBehaviour {

    AsyncOperation async;
    Scene levelScene;
    float time;
    
    public Form menu = new Form
    {
        Size = new Size(1200, 750)
    };

    static Label label = new Label
    {
        Location = new Point(0, 0),
        Size = new Size(800, 100),
        Text = "Загрузка...",
        BackColor = System.Drawing.Color.Aqua,
        ForeColor = System.Drawing.Color.CadetBlue,
        Font = new System.Drawing.Font("Comic Sans MS", 50, System.Drawing.FontStyle.Bold),

    };

    //   // Use this for initialization
    //   void Start () {
    //       menu.Controls.Add(label);
    //       menu.Show();
    //       SceneManager.LoadSceneAsync("First_Level").allowSceneActivation = false;

    //   }

    //// Update is called once per frame
    //void Update () {
    //       //SceneManager.LoadSceneAsync("First_Level");
    //       if (SceneManager.GetSceneByName("First_Level").isLoaded)
    //       {
    //           menu.Close();

    //           //SceneManager.SetActiveScene(SceneManager.GetSceneByName("First_Level"));
    //       }

    //}


    //IEnumerator Start()
    //{
    //    async = SceneManager.LoadSceneAsync("First_Level");
    //    yield return true;
    //    async.allowSceneActivation = false;
    //}

    void Start()
    {
        time = 0;
        menu.Controls.Add(label);
        menu.Show();
        async = SceneManager.LoadSceneAsync("First_Level");
        async.allowSceneActivation = false;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2)
        {
            menu.Close();
            async.allowSceneActivation = true;
        }
    }
}
