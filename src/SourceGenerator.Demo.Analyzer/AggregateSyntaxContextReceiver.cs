using Microsoft.CodeAnalysis;

namespace SourceGenerator.Demo.Analyzer
{
    // Taken from https://github.com/kant2002/SourceGeneratorsKit
    public class AggregateSyntaxContextReceiver : ISyntaxContextReceiver
    {
        public AggregateSyntaxContextReceiver(params ISyntaxContextReceiver[] receivers) => this.Receivers = receivers;

        public ISyntaxContextReceiver[] Receivers { get; }

        /// <inheritdoc/>
        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            foreach (var receiver in this.Receivers)
            {
                receiver.OnVisitSyntaxNode(context);
            }
        }
    }
}
