using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace SourceGenerator.Demo.Analyzer
{
    [Generator]
    public partial class DemoSourceGenerator : ISourceGenerator
    {
        SyntaxReceiver _fluentAsyncReceiver = new FluentAsyncMethodReciever();
        SyntaxReceiver _coreAsyncReceiver = new MethodPatternReciever("CoreAsync$");

        ISyntaxContextReceiver _agregateSyntaxReceiver;

        public DemoSourceGenerator()
        {
            _agregateSyntaxReceiver = new AggregateSyntaxContextReceiver(_fluentAsyncReceiver, _coreAsyncReceiver);
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => _agregateSyntaxReceiver);
        }

        public void Execute(GeneratorExecutionContext context)
        {
            // Retrieve the populated receiver
            if (!(context.SyntaxContextReceiver is AggregateSyntaxContextReceiver))
            {
                return;
            }

            HandleFluentAsyncMethods(_fluentAsyncReceiver, context);
            HandleCoreAsyncMethods(_coreAsyncReceiver, context);
        }





        private string ConstructTypeParamsString(IMethodSymbol method)
        {
            return method.TypeParameters.Length > 0
                ? $"<{string.Join(",", method.TypeParameters.Select(x => x.Name))}>"
                : string.Empty;
        }

        private string ConstructTypeParamConstraintsString(IMethodSymbol method, int indent = 0)
        {
            var indentStr = string.Empty.PadRight(indent);
            return method.TypeParameters.Length > 0
                ? $"\n{indentStr}{string.Join($"\n{indentStr}", method.TypeParameters.Select(x => x.GetStringifiedConstraints()).Where(x => x != string.Empty))}"
                : string.Empty;
        }

        private string ConstructParamsString(IEnumerable<IParameterSymbol> parameterSymbols, bool sync = false)
            => ConstructParamsString(string.Empty, parameterSymbols, sync);

        private string ConstructParamsString(string seed, IEnumerable<IParameterSymbol> parameterSymbols, bool sync = false)
        {
            return parameterSymbols.Where(x => !sync || x.Type.Name != "CancellationToken").Aggregate(seed, (a, p) => $"{a}, {p.Type.GetFullyQualifiedName()} {p.Name}{(p.HasExplicitDefaultValue ? " = " + p.ExplicitDefaultValue.GetStringifiedDefaultValue(p.Type) : "")}").TrimStart(',', ' ');
        }

        private string ConstructParamsAsArgsString(IEnumerable<IParameterSymbol> parameterSymbols, bool sync = false)
            => ConstructParamsAsArgsString(string.Empty, parameterSymbols, sync);

        private string ConstructParamsAsArgsString(string seed, IEnumerable<IParameterSymbol> parameterSymbols, bool sync = false)
        {
            return parameterSymbols.Aggregate(seed, (a, p) => $"{a}, {(sync && p.Type.Name == "CancellationToken" ? "default" : p.Name)}").TrimStart(',', ' ');
        }
    }
}