﻿// <auto-generated />

namespace SourceGenerator.Demo
{
    public static partial class StoreExtensions
    {
        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Store> SetNameAsync(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Store> task, string name) 
            => await (await task).SetNameAsync(name);

        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Store> SetDescriptionAsync(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Store> task, string description) 
            => await (await task).SetDescriptionAsync(description);

        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Store> SetIsEnabledAsync(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Store> task, bool isEnabled) 
            => await (await task).SetIsEnabledAsync(isEnabled);

    }
}
