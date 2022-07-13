using CustomStore.Core.DomainObjects;

namespace CustomStore.Catalog.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public int Code { get; private set; }

        public Category(string name, int code)
        {
            Name = name;
            Code = code;

            Validate();
        }

        protected Category() { }

        public void Validate()
        {
            AssertionConcern.ValidateEmpty(Name, "Name cannot be empty");
            AssertionConcern.ValidateLessThan(Code, 0, "Code should be positive");
        }
    }
}
