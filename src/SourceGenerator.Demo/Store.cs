using System.ComponentModel;
using System.Threading.Tasks;

namespace SourceGenerator.Demo
{
    public partial class Store : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Test { get; private set; }
        public bool IsEnabled { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Task<Store> SetNameCoreAsync(string name, bool sync)
        {
            Name = name;
            return Task.FromResult(this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Task<Store> SetDescriptionCoreAsync(string description, bool sync)
        {
            Description = description;
            return Task.FromResult(this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Task<Store> SetIsEnabledCoreAsync(bool isEnabled, bool sync)
        {
            IsEnabled = isEnabled;
            return Task.FromResult(this);
        }
    }
}