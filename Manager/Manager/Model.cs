using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class Model
    {
        public enum ModelState
        {
            Free
        }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public ModelState State { get; set; }

        public Model(string Name)
        {
            this.Date = DateTime.Now;
            this.Name = Name;
        }
    }
}
