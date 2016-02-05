// <copyright file="Program.cs" company="Appccelerate">
//   Copyright (c)  2008-2016
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>

namespace Appccelerate.StateMachine.Performance
{
    using System;
    using System.Diagnostics;

    public static class Program
    {
        public static void Main()
        {
            RunInitializationMeasurement();
        }

        private static void RunInitializationMeasurement()
        {
            var initializations = 1000000;

            Console.WriteLine("running initialization measurement");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < initializations; i++)
            {
                var phone = new Phone();
            }

            stopwatch.Stop();

            Console.WriteLine($"ran {initializations} initializations in {stopwatch.ElapsedMilliseconds} milliseconds");
        }
    }
}