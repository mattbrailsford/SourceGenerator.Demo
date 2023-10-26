using Microsoft.CodeAnalysis;

namespace SourceGenerator.Demo.Analyzer
{
    // Taken from https://github.com/kant2002/SourceGeneratorsKit
    public class DerivedClassesReceiver : SyntaxReceiver
    {
        private string baseTypeName;
        public DerivedClassesReceiver(string baseTypeName) => this.baseTypeName = baseTypeName;

        public override bool CollectClassSymbol { get; } = true;

        protected override bool ShouldCollectClassSymbol(INamedTypeSymbol classSymbol)
            => classSymbol.IsDerivedFromType(this.baseTypeName);
    }
}
