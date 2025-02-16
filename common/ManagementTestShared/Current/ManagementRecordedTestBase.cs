// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class ManagementRecordedTestBase<TEnvironment> : RecordedTestBase<TEnvironment> where TEnvironment: TestEnvironment, new()
    {
        private static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);

        protected ResourceGroupCleanupPolicy CleanupPolicy { get; set; }

        private ArmClient _cleanupClient;

        protected ManagementRecordedTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected ManagementRecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation)
        {
            return operation.WaitForCompletionAsync();
        }

        protected ValueTask<Response> WaitForCompletionAsync(Operation operation)
        {
            return operation.WaitForCompletionResponseAsync();
        }

        protected ArmClient GetResourceManagementClient()
        {
            var options = InstrumentClientOptions(new ArmClientOptions());
            CleanupPolicy = new ResourceGroupCleanupPolicy();
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<ArmClient>(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);
        }

        protected async Task CleanupResourceGroupsAsync()
        {
            if (CleanupPolicy != null && Mode != RecordedTestMode.Playback)
            {
                _cleanupClient ??= new ArmClient(
                    TestEnvironment.SubscriptionId,
                    TestEnvironment.Credential,
                    new ArmClientOptions());
                var sub = _cleanupClient.GetSubscriptions().GetIfExists(TestEnvironment.SubscriptionId);
                foreach (var resourceGroup in CleanupPolicy.ResourceGroupsCreated)
                {
                    await sub.Value?.GetResourceGroups().Get(resourceGroup).Value.DeleteAsync();
                }
            }
        }

        protected async Task<string> GetFirstUsableLocationAsync(ProviderCollection providersClient, string resourceProviderNamespace, string resourceType)
        {
            var provider = (await providersClient.GetAsync(resourceProviderNamespace)).Value;
            return provider.Data.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == resourceType)
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();
        }

        protected void SleepInTest(int milliSeconds)
        {
            if (Mode == RecordedTestMode.Playback)
                return;
            Thread.Sleep(milliSeconds);
        }
    }
}
