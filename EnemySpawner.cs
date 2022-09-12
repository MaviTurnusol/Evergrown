using Godot;
using System;

public class EnemySpawner : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    static bool sex = false;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Timer timer = this.GetNode<Timer>("Timer");
        timer.WaitTime = 10;
        timer.Connect("timeout",this,"on_timeout");
        timer.Start();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(sex == true)
        {
        PackedScene Marbius = (PackedScene)GD.Load("res://RedPanda.tscn");
        KinematicBody2D enemy1 = (KinematicBody2D)Marbius.Instance();

        var rng = new RandomNumberGenerator();
        rng.Randomize();
        int a = rng.RandiRange(0, 4);

        enemy1.Position = new Vector2(500*a, 300*a);
        GD.Print("I hate niggers");
        sex = false;
        }
    }

    public static void on_timeout()
    {
        sex = true;
    }
}
