using System;
using System.Collections.Generic;
using System.Text;

namespace Home11GENERICS
{
    public enum Player
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }
    public class Footballer
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public Player Role { get; set; }
        public Footballer(string name, int number, Player role)
        {
            Name = name;
            Number = number;
            Role = role;
        }
        public override string ToString() => $"{Name} {Number} - Role: {Role}";
    }
}
