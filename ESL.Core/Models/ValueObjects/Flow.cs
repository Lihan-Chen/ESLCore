using ESL.Core.Models.BusinessEntities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Models.ValueObjects
{
    public abstract class Flow : ValueObject
    {
        public int? Value { get; private set; }

        public string? Unit { get; private set; }

        public Flow(int? value, string? unit)
        {
            Value = value;
            Unit = unit;
        }

        public Flow ToFlow(Flow from, Flow to)
        {
            if (from == null) throw new ArgumentNullException(nameof(from));

            if (to == null) throw new ArgumentNullException(nameof(to));

            if (from.Unit != to.Unit)
            {
                switch (from.Unit)
                {
                    case "CFS": // verified
                        switch (to.Unit)
                        {
                            case "CFS":
                                return from;
                            case "mL/min":
                                return CreateFlow(from.Value * 1699010.8, to.Unit);
                            case "MGD":
                                return CreateFlow(from.Value * 0.646317, to.Unit);
                            case "lbs/day":
                                return CreateFlow(from.Value * 5393775.79, to.Unit);
                            default:
                                throw new ArgumentException("Cannot convert between different units.");
                        }
                    case "mL/min":
                        switch (to.Unit)
                        {
                            case "CFS":
                                return CreateFlow(from.Value / 1699010.8, to.Unit);
                            case "mL/min":
                                return from;
                            case "MGD":
                                return CreateFlow(from.Value / 2628758.18, to.Unit); //ok
                            case "lbs/day":
                                return CreateFlow(from.Value * 2.36, to.Unit);
                            default:
                                throw new ArgumentException("Cannot convert between different units.");
                        }
                    case "MGD":
                        switch (to.Unit)
                        {
                            case "CFS":
                                return CreateFlow(from.Value * 1.547, to.Unit);
                            case "mL/min":
                                return CreateFlow(from.Value * 2628758.18, to.Unit);
                            case "MGD":
                                return from;
                            case "lbs/day":
                                return CreateFlow(from.Value * 8340000, to.Unit);
                            default:
                                throw new ArgumentException("Cannot convert between different units.");
                        }
                    case "lbs/day":
                        switch (to.Unit)
                        {
                            case "CFS":
                                return CreateFlow(from.Value / 5393775.79, to.Unit);
                            case "mL/min":
                                return CreateFlow(from.Value / 3.17515, to.Unit);
                            case "MGD":
                                return CreateFlow(from.Value / 8340000, to.Unit);
                            case "lbs/day":
                                return from;
                            default:
                                throw new ArgumentException("Cannot convert between different units.");
                        }
                    default:
                        throw new ArgumentException("Cannot convert between different units.");
                }
            }

            return from;
        }

        protected abstract Flow CreateFlow(double? value, string? unit);
    }
}
