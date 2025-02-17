﻿// --------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
// --------------------------------------------------------------------------------------------

using k8s.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.BridgeToKubernetes.Common.Kubernetes;
using Newtonsoft.Json;

namespace Microsoft.BridgeToKubernetes.Common.Models.LocalConnect
{
    /// <summary>
    /// Object model that contains information related to a patched deployment
    /// </summary>
    internal class DeploymentPatch : PatchEntityBase
    {
        [JsonConstructor]
        public DeploymentPatch(V1Deployment deployment, JsonPatchDocument<V1Deployment> reversePatch)
        {
            this.Deployment = deployment;
            this.ReversePatch = reversePatch;
        }

        public override KubernetesResourceType KubernetesType => KubernetesResourceType.Deployment;
        public override string Namespace => this.Deployment?.Namespace();
        public override string Name => this.Deployment?.Name();

        /// <summary>
        /// The deployment that was patched
        /// </summary>
        [JsonProperty("deployment")]
        public V1Deployment Deployment { get; private set; }

        /// <summary>
        /// The operations to perform to reverse the patch
        /// </summary>
        [JsonProperty("reversePatch")]
        public JsonPatchDocument<V1Deployment> ReversePatch { get; private set; }
    }
}