using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Practice11GENERICS
{
    public class Oceanarium : IEnumerable<Animal>
    {
        public Animal[] Animals { get; set; }
        public Oceanarium(Animal[] animals)
        {
            this.Animals = animals;
        }
        public IEnumerator<Animal> GetEnumerator()
        {
            if (Animals == null)
            {
                throw new System.ArgumentNullException("Animals array cannot be null");
            }
            foreach (Animal animal in Animals)
            {
                yield return animal;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
      

