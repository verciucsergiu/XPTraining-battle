using System;

namespace Battle
{
    public class Soldier
    {
        public Soldier(string name)
        {
            ValidateNameisNotBlank(name);

            Name = name;
        }

        private void ValidateNameisNotBlank(string name)
        {
            if (IsBlank(name))
            {
                throw new ArgumentException("name can not be blank");
            }
        }


        public string Name { get; }
        
        public FightResult Fight(Soldier other)
        {
            return new FightResult();
        }

        private bool IsBlank(string name) => string.IsNullOrEmpty(name?.Trim());
    }
}