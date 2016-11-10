using System;
using System.Collections.Generic;

namespace SeedingATree.Domain
{
    public class OrgStruct
    {
        private readonly Dictionary<string, OrgUnit> _orgUnits;

        public OrgStruct()
        {
            _orgUnits = new Dictionary<string, OrgUnit>();
        }

        public void Add(OrgUnit orgUnit)
        {
            _orgUnits.Add(orgUnit.ShortName, orgUnit);
        }

        public OrgUnit this[string name]
        {
            get
            {
                OrgUnit orgUnit;
                if (!_orgUnits.TryGetValue(name, out orgUnit))
                    throw new ArgumentOutOfRangeException(nameof(name), name, $"There is no OrgUnit namend \"{name}\".");
                return _orgUnits[name];
            }
        }
    }
}