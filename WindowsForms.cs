using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.Windows.Forms;
using UnityEngine.SceneManagement;

public class WindowsForms : MonoBehaviour {

    public int LoadedScenes = 0;
    bool firstTimeLaunchMenu = true;

    public Form menu = new Form // Само окно.
    {
        Size = new Size(1200, 750)
    };

    //Элементы главного меню.

    static Label label = new Label
    {
        Location = new Point(0, 0),
        Size = new Size(800, 100),
        Text = "ЯТП ИГРА",
        BackColor = System.Drawing.Color.Aqua,
        ForeColor = System.Drawing.Color.CadetBlue,
        Font = new System.Drawing.Font("Comic Sans MS", 50, System.Drawing.FontStyle.Bold),
        
    };

    static Button startButton = new Button
    {
        Location = new Point(0, label.Bottom),
        Size = label.Size,
        Text = "New game"
    };

    static Button recordsButton = new Button
    {
        Location = new Point(0, startButton.Bottom),
        Size = label.Size,
        Text = "Records"
    };

    static Button exitButton = new Button
    {
        Location = new Point(0, recordsButton.Bottom),
        Size = label.Size,
        Text = "Exit"
    };

    // Элементы меню рекордов.

    static Label records = new Label
    {
        Location = new Point(0, 0),
        Size = new Size(800, 400),
        Text = "Records\n1: 4500\n2: 3700\n3: 2400",
        BackColor = System.Drawing.Color.Aqua,
        ForeColor = System.Drawing.Color.CadetBlue,
        Font = new System.Drawing.Font("Comic Sans MS", 40, System.Drawing.FontStyle.Bold)
    };

    static Button backButton = new Button
    {
        Location = new Point(0, records.Bottom),
        Size = label.Size,
        Text = "back"
    };



    void Start()
    {
        menu.Controls.AddRange(new Control[]{ label, startButton, recordsButton, exitButton});

        startButton.Click += (sender, args) =>
        {
            menu.Close();
            SceneManager.LoadScene("Load_Level_Scene");
        };
        recordsButton.Click += (sender, args) =>
        {
            menu.Controls.Clear();
            menu.Controls.AddRange(new Control[] { records, backButton });
        };
        exitButton.Click += (sender, args) => 
        {
            menu.Close();
            UnityEngine.Application.Quit();
        };
        recordsButton.Click += (sender, args) =>
        {
            menu.Controls.Clear();
            menu.Controls.AddRange(new Control[] { records, backButton });
        };
        backButton.Click += (sender, args) =>
        {
            menu.Controls.Clear();
            menu.Controls.AddRange(new Control[] { label, startButton, recordsButton, exitButton });
        };

        if (firstTimeLaunchMenu)
        {
            menu.ShowDialog();
            firstTimeLaunchMenu = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            menu.ShowDialog();
        LoadedScenes = SceneManager.sceneCount;
    }
}
