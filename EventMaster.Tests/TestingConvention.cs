using Fixie;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EventMaster.Tests
{
    public class TestingConvention : Convention
    {
        public TestingConvention()
        {
            Classes
                .NameEndsWith("Tests");

            Methods
                .Where(m => m.IsPublic);
        }
    }
}
