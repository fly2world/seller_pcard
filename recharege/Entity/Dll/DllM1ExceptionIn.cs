using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace recharege.Entity.Dll
{
    public class DllM1ExceptionIn
    {
        private string hasRecord;
        private string count;
        private string balance;

        public string HasRecord
        {
            get
            {
                return hasRecord;
            }

            set
            {
                hasRecord = value;
            }
        }

        public string Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public string Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }
    }
}
