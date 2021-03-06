// <copyright file="PassiveStateMachineTest.cs" company="Appccelerate">
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

namespace Appccelerate.StateMachine
{
    /// <summary>
    /// Tests the <see cref="PassiveStateMachine{TState,TEvent}"/> class.
    /// </summary>
    public class PassiveStateMachineTest : StateMachineTestBase<PassiveStateMachine<States, Events>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PassiveStateMachineTest"/> class.
        /// </summary>
        public PassiveStateMachineTest()
            : base(new PassiveStateMachine<States, Events>("Test Machine"))
        {
        }
    }
}