using Godot;
using System;

public class BossBullet : Node2D
{
    float speed = 400;

    public float range = 400;

    private float distancetravelled = 0;


    public override void _Ready()
    {
        var area = GetNode<Area2D>("Area2D");
        area.Connect("area_entered",this,"Oncollision");
        area.Connect("body_entered",this,"Oncollision");
    }
    public override void _Process(float delta)
    {
        float moveAmount = speed * delta;
        Position += Transform.x.Normalized() * moveAmount;

        distancetravelled += moveAmount;
        if (distancetravelled>range)
        {
            QueueFree();
        }
    }

    public void Oncollision(Node with)
    {
       // with.GetParent<Ridman>().Damage(1);
        QueueFree();
    }
}