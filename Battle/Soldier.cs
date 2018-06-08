using System;
using Battle.Weapons;

namespace Battle
{
    public class Soldier
    {
        private Weapon _weapon;
        public string Name { get; }
        public Guid Id { get; set; }

        public Weapon Weapon
        {
            get => _weapon;
            set =>  _weapon = value ?? throw new ArgumentNullException();
        }

        public Soldier(string name)
        {
            ValidateNameisNotBlank(name);
            Name = name;
            
            Weapon = new BareFist();
        }

        private static void ValidateNameisNotBlank(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name can not be blank");
            }
        }

        public bool Fight(Soldier defender)
        {
            return this.Weapon >= defender.Weapon;
        }
    }
}