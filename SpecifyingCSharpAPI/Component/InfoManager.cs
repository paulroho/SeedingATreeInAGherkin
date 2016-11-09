﻿using System.Collections.Generic;
using System.Linq;
using SeedingATree.Domain;

namespace SpecifyingCSharpAPI.Component
{
    public class InfoManager
    {
        private OrgContext context;

        public InfoManager(OrgContext context)
        {
            this.context = context;
        }

        public IList<Org> GetDirectChildren(string orgShortName)
        {
            var orgStructure = context.OrgStructure;
            var org = orgStructure[orgShortName];
            return orgStructure.Orgs.Where(o => o.Parent == org).ToList();
        }
    }
}