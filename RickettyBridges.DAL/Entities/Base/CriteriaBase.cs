namespace RickettyBridges.DAL.Entities.Base
{
    using System.Collections.Generic;

    using RickettyBridges.DAL.Enums;

    public class CriteriaBase
    {
        public class SortCriteria
        {
            public bool Ascending { get; set; }
            public string FieldName { get; set; }
        }

        public class ListCriteriaFilter
        {
            public List<ListCriteriaFilter> Children { get; set; }

            public string FieldName { get; set; }

            public LogicalJoin GroupLogicJoin { get; set; }

            public LogicalOperator Operator { get; set; }

            public string Value { get; set; }
        }

        public class ListCriteria
        {
            public List<ListCriteriaFilter> Filter { get; set; }

            public int PageNumber { get; set; }

            public int PageSize { get; set; }

            public List<SortCriteria> Sort { get; set; }
        }
    }
}
