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
      for(int i = 0; i < 5; i++)
      {
        // Randomizer
        var roomrng = new RandomNumberGenerator();
        roomrng.Randomize();
        int a = roomrng.RandiRange(0, 1);
        rums = (PackedScene)GD.Load(list[a]);

        TileMap rmSpawn = (TileMap)rums.Instance();
        Vector2 rmPos = new Vector2(0, 600*i);
        rmSpawn.Position = rmPos;
          
          for(int n = 0; n < 4; n++)
          {
            roomrng.Randomize();
            a = roomrng.RandiRange(0, 1);
            rums = (PackedScene)GD.Load(list[a]);

            rmSpawn = (TileMap)rums.Instance();
            rmPos.x = n * 1024;
            rmSpawn.Position = rmPos;
            AddChild(rmSpawn);
          }
      }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
  }
}
