using Microsoft.CodeAnalysis;
using System.Text.RegularExpressions;

namespace SourceGenerator.Demo.Analyzer
{
    public class MethodPatternReciever : SyntaxReceiver
    {
        private string pattern;
        public MethodPatternReciever(string pattern) => this.pattern = pattern;

        public override bool CollectMethodSymbol { get; } = true;

        protected override bool ShouldCollectMethodSymbol(IMethodSymbol methodSymbol)
            => Regex.IsMatch(methodSymbol.Name, this.pattern);
    }
}
