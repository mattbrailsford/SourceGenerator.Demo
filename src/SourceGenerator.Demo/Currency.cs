using System.Threading.Tasks;

namespace SourceGenerator.Demo
{
    public class Currency : Entity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public Task<Currency> SetNameAsync(string name)
        {
            Name = name;
            return Task.FromResult(this);
        }

        public Task<Currency> SetCodeAsync(string code)
        {
            Code = code;
            return Task.FromResult(this);
        }
    }
}