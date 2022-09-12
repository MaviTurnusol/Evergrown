using Godot;
using System;

public class Ridman : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public static int a;
    public static Vector2 posy;
    public static Node2D bulet;
    public static PackedScene BossBullet;
    public static bool canwalk;
    public static bool sex = false;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Timer timer = this.GetNode<Timer>("attackTimer");
        timer.WaitTime = 1;
        timer.Connect("timeout",this,"on_timeout");
        timer.Start();
    }

    public override void _Process(float delta)
    {
        var rng = new RandomNumberGenerator();
        rng.Randomize();
        a = rng.RandiRange(0, 1);

        if(sex == true)
        {
                for(int n = 0; n < 8; n++)
                {
                    Vector2 posy = new Vector2(Position.x+(n+10),  Position.y+(n+10));
                    BossBullet = (PackedScene)GD.Load("res://BossBullet.tscn");
                    Node2D bulot = (Node2D)BossBullet.Instance();
                    bulot.Position = posy;
                    bulot.RotationDegrees = n*45;
                    AddChild(bulot);
                }
            sex = false;
        }
    }
    public static void on_timeout()
    {
        sex = true;
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.

}
