// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace System.Net
{
    internal static class ContextFlagsAdapterPal
    {
        private struct ContextFlagMapping
        {
            public readonly Interop.NetSecurityNative.GssFlags GssFlags;
            public readonly ContextFlagsPal ContextFlag;

            public ContextFlagMapping(Interop.NetSecurityNative.GssFlags gssFlag, ContextFlagsPal contextFlag)
            {
                GssFlags = gssFlag;
                ContextFlag = contextFlag;
            }
        }

        private static readonly ContextFlagMapping[] s_contextFlagMapping = new[]
        {
            // GSS_C_INTEG_FLAG is set if either AcceptIntegrity (used by server) or InitIntegrity (used by client) is set
            new ContextFlagMapping(Interop.NetSecurityNative.GssFlags.GSS_C_INTEG_FLAG, ContextFlagsPal.AcceptIntegrity | ContextFlagsPal.InitIntegrity),
            new ContextFlagMapping(Interop.NetSecurityNative.GssFlags.GSS_C_CONF_FLAG, ContextFlagsPal.Confidentiality),
            new ContextFlagMapping(Interop.NetSecurityNative.GssFlags.GSS_C_IDENTIFY_FLAG, ContextFlagsPal.InitIdentify),
            new ContextFlagMapping(Interop.NetSecurityNative.GssFlags.GSS_C_MUTUAL_FLAG, ContextFlagsPal.MutualAuth),
            new ContextFlagMapping(Interop.NetSecurityNative.GssFlags.GSS_C_REPLAY_FLAG, ContextFlagsPal.ReplayDetect),
            new ContextFlagMapping(Interop.NetSecurityNative.GssFlags.GSS_C_SEQUENCE_FLAG, ContextFlagsPal.SequenceDetect)
        };


        internal static ContextFlagsPal GetContextFlagsPalFromInterop(Interop.NetSecurityNative.GssFlags gssFlags)
        {
            ContextFlagsPal flags = ContextFlagsPal.None;
            foreach (ContextFlagMapping mapping in s_contextFlagMapping)
            {
                if ((gssFlags & mapping.GssFlags) == mapping.GssFlags)
                {
                    flags |= mapping.ContextFlag;
                }
            }

            return flags;
        }

        internal static Interop.NetSecurityNative.GssFlags GetInteropFromContextFlagsPal(ContextFlagsPal flags)
        {
            Interop.NetSecurityNative.GssFlags gssFlags = 0;
            foreach (ContextFlagMapping mapping in s_contextFlagMapping)
            {
                if ((flags & mapping.ContextFlag) == mapping.ContextFlag)
                {
                    gssFlags |= mapping.GssFlags;
                }
            }

            return gssFlags;
        }
    }
}
