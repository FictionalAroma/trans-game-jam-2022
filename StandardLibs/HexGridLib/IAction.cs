using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Events
{
    public enum ActionType
    {
        Speech,
        Narration,
        Choice,
    }

    public interface IAction
    {
        public ActionType Type { get; set; }
        public IEnumerator<IAction> GetNextAction();
    }

    public abstract class BaseAction : IAction
    {
        public ActionType Type { get; set; }

        public virtual IEnumerator<IAction> GetNextAction() { yield return this; }
    }

    public interface ICompositeAction : IAction
    {
        public List<IAction> ChildActions { get; set; }


    }
}
