using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class StudentUser : AUser
    {
        StudentUser(string firstName, string lastName) : base(firstName, lastName)
        {

        }

        public override float ApplyDiscount(float price)
        {
            return price * 0.4f;
        }
    }
}