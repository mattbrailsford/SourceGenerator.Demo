using Microsoft.CodeAnalysis;
using System.Linq;

namespace SourceGenerator.Demo.Analyzer
{
    public class FluentAsyncMethodReciever : SyntaxReceiver
    {
        public override bool CollectMethodSymbol { get; } = true;

        protected override bool ShouldCollectMethodSymbol(IMethodSymbol methodSymbol)
        {
            if (methodSymbol.ReturnType.Name == "Task")
            {
                var returnType = methodSymbol.ReturnType as INamedTypeSymbol;
                var actualReturnType = returnType.TypeArguments.FirstOrDefault();

                var entityType = methodSymbol.IsExtensionMethod
                    ? methodSymbol.Parameters[0].Type
                    : methodSymbol.ContainingType;

                if (actualReturnType != null && actualReturnType.Name == entityType.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
