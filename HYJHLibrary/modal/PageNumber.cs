using System;
using System.Collections.Generic;
using System.Text;

namespace HYJHLibrary.modal
{
    public class PageNumber
    {
        public int PageIndex
        {
            get; set;
        }


        public string PageText
        {
            get; set;
        }

        public bool IsCurrPage
        {
            get; set;
        }

        public bool Enabled
        {
            get; set;
        }
    }
}
