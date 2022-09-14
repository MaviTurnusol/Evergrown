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
    static Vector2 dis = new Vector2();
    static int speed = 0;
    public static Vector2 pluer;
    static int sex2 = 0;
    public float health1 = 30;
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
        pluer = GetTree().Root.GetNode("World").GetNode<KinematicBody2D>("Mario").Position;

        var rng = new RandomNumberGenerator();
        rng.Randomize();
        a = rng.RandiRange(0, 2);
        if(sex == true)
        {
            if(a < 1 && a > -1)
            {   speed = 0;
                for(int n = 0; n < 8; n++)
                {
                    BossBullet = (PackedScene)GD.Load("res://BossBullet.tscn");
                    Node2D bulot = (Node2D)BossBullet.Instance();
                    bulot.RotationDegrees = n*45;
                    AddChild(bulot);
                    GD.Print("ates ettim");
                    dis = dis.Normalized() * speed;
                }
                sex = false;
            } else if(a > 0 && a < 2) {
                dis = new Vector2(pluer.x - Position.x, pluer.y - Position.y);
                speed = 1000;
                dis = dis.Normalized() * speed;
                GD.Print("calistim");
                sex = false;
            } else if(a > 1 && a < 3)
            {
                dis = new Vector2(-pluer.x, -pluer.y);
                speed = 200;
                for(int b = 0; b < 3; b++)
                {
                    dis = new Vector2(pluer.x - Position.x, pluer.y - Position.y);
                    BossBullet = (PackedScene)GD.Load("res://BossBullet.tscn");
                    Node2D bulot = (Node2D)BossBullet.Instance();
                    dis.x += b*50;
                    dis.y -= b*50;
                    bulot.LookAt(dis);
                    AddChild(bulot);
                    GD.Print("ates ettim");
                    dis = -dis.Normalized() * speed;
                }
                sex = false;
            } 

        }
        dis = MoveAndSlide(dis);

        if (health1 <= 0)
        {
            QueueFree();
        }
    }
    public static void on_timeout()
    {
        sex = true;
        speed = 0;
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.

}
