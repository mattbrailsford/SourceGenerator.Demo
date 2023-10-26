using System.Threading.Tasks;

namespace SourceGenerator.Demo
{
    public class Country : Entity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        //public Country SetName(string name)
        //{
        //    Name = name;
        //    return this;
        //}

        //public Country SetCode(string code)
        //{
        //    Code = code;
        //    return this;
        //}

        public Task<Country> SetNameAsync(string name)
        {
            Name = name;
            return Task.FromResult(this);
        }

        public Task<Country> SetCodeAsync(string code)
        {
            Code = code;
            return Task.FromResult(this);
        }
    }

    //public static partial class CountryExtensions
    //{
    //    public static async Task<Country> SetNameAsync(this Task<Country> task, string name)
    //        => await (await task).SetNameAsync(name);

    //    public static async Task<Country> SetCodeAsync(this Task<Country> task, string code)
    //        => await (await task).SetCodeAsync(code);

    //}
}