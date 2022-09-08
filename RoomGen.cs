using Godot;
using System;

public class RoomGen : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    //RNG
      static string[] list = {"res://Room0.tscn", "res://Room1.tscn"};
      static int lengt = list.Length;
      
    PackedScene rums;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
      var roomrng = new RandomNumberGenerator();
      roomrng.Randomize();
      int i = roomrng.RandiRange(0, 1);
      rums = (PackedScene)GD.Load(list[i]);
      TileMap rmSpawn = (TileMap)rums.Instance();
      AddChild(rmSpawn);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
  }
}
