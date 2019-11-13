// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace InteropTests.Helpers
{
    public class InteropTestsFixture : IDisposable
    {
        private WebServerProcess _process;

        public string Path { get; set; }

        public async Task EnsureStarted(ITestOutputHelper output)
        {
            if (_process != null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Path))
            {
                throw new InvalidOperationException("Path has not been set.");
            }

            _process = new WebServerProcess(Path, output);

            await _process.WaitForReady();
        }

        public void Dispose()
        {
            _process.Dispose();
        }
    }
}