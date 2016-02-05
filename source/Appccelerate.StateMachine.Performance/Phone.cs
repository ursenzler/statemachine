// <copyright file="Phone.cs" company="Appccelerate">
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
    public class Phone
    {
        private enum State
        {
            OffHook,
            Ringing,
            Connected,
            OnHold,
            PhoneDestroyed
        }

        private enum Trigger
        {
            CallDialed,

            HungUp,

            CallConnected,

            LeftMessage,

            PlacedOnHold,

            TakenOffHold,

            PhoneHurledAgainstWall
        }

        private readonly PassiveStateMachine<State, Trigger> phone = new PassiveStateMachine<State, Trigger>();

        public Phone()
        {
            this.phone.In(State.OffHook)
                  .On(Trigger.CallDialed).Goto(State.Ringing);

            this.phone.In(State.Ringing)
                  .On(Trigger.HungUp).Goto(State.OffHook)
                  .On(Trigger.CallConnected).Goto(State.Connected);

            this.phone.In(State.Connected)
                  .On(Trigger.LeftMessage).Goto(State.OffHook)
                  .On(Trigger.HungUp).Goto(State.OffHook)
                  .On(Trigger.PlacedOnHold).Goto(State.OnHold);

            this.phone.DefineHierarchyOn(State.Connected)
                  .WithHistoryType(HistoryType.None)
                  .WithInitialSubState(State.OnHold);

            this.phone.In(State.OnHold)
                  .On(Trigger.TakenOffHold).Goto(State.Connected)
                  .On(Trigger.HungUp).Goto(State.OffHook)
                  .On(Trigger.PhoneHurledAgainstWall).Goto(State.PhoneDestroyed);

            this.phone.Initialize(State.OffHook);
            this.phone.Start();
        }

        public void CallDialed()
        {
            this.phone.Fire(Trigger.CallDialed);
        }

        public void CallConnected()
        {
            this.phone.Fire(Trigger.CallConnected);
        }

        public void PlacedOnHold()
        {
            this.phone.Fire(Trigger.PlacedOnHold);
        }

        public void TakenOffHold()
        {
            this.phone.Fire(Trigger.TakenOffHold);
        }

        public void HungUp()
        {
            this.phone.Fire(Trigger.HungUp);
        }
    }
}