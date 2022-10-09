using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;

namespace FARTS_Machine.Hooks
{
    internal class BaseHook
    {
        public bool IsAttached = false;
        private Mem _memory;

        public BaseHook()
        {
            this._memory = new Mem();
        }

        public void AttachToProcess()
        {
            int processId = this._memory.GetProcIdFromName("stranger");
            if (processId > 0)
            {
                this._memory.OpenProcess(processId);
                this.IsAttached = true;
            }
        }
    }
}
