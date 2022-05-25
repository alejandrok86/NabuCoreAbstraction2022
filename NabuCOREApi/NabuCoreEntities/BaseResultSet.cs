using System;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    public class BaseResultSet : BaseType
    {
        public List<BaseResultRow> rows { get; set; }

        public BaseResultSet()
        {
            rows = new List<BaseResultRow>();
        }

        public BaseResultSet(BaseString[] pPipeSeparatedResults)
        {
            try
            {
                string pipeSeparator = "|";
                foreach (BaseString pipeSeparatedResult in pPipeSeparatedResults)
                {
                    if (pipeSeparatedResult.ErrorsDetected == false)
                    {
                        BaseResultRow row = new BaseResultRow();
                        string[] fields = pipeSeparatedResult.Value.Split(pipeSeparator.ToCharArray());
                        foreach (string field in fields)
                            row.columns.Add(new BaseResultColumn(field.Replace("'", "")));
                        rows.Add(row);
                    }
                }
            }
            catch (Exception exc)
            {
                this.ErrorsDetected = true;
                this.ErrorDetails.Add(new Error.ErrorDetail(-1, exc.Message));
                this.StackTrace = exc.StackTrace;
            }
        }
    }
}
