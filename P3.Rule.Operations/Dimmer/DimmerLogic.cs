﻿using System.Collections.Generic;
using System.Linq;
using Automatica.Core.Base.IO;
using Automatica.Core.EF.Models;
using Automatica.Core.Rule;

namespace P3.Rule.Operations.Dimmer
{
    public class DimmerLogic : Automatica.Core.Rule.Rule
    {
        private readonly RuleInterfaceInstance _input;
        private readonly RuleInterfaceInstance _output;

        public DimmerLogic(IRuleContext context) : base(context)
        {
            _input = context.RuleInstance.RuleInterfaceInstance.Single(a =>
                a.This2RuleInterfaceTemplate == DimmerLogicFactory.RuleInput);
            
            _output = context.RuleInstance.RuleInterfaceInstance.Single(a =>
                a.This2RuleInterfaceTemplate == DimmerLogicFactory.RuleOutput);
        }

        protected override IList<IRuleOutputChanged> InputValueChanged(RuleInterfaceInstance instance,
            IDispatchable source, object value)
        {
            if (instance == _input)
            {
                return ValueChanged(_output, value);
            }

            return new List<IRuleOutputChanged>();
        }

        public override object GetDataForVisu()
        {
            return base.GetDataForVisu();
        }
    }
}
