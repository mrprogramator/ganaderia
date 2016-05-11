using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Models
{
    public class SaveChanges
    {
        private string message;

        public SaveChanges(String message)
        {
            this.message = message;
        }

        public String Message
        {
            get
            {
                return message;
            }
        }
    }
}