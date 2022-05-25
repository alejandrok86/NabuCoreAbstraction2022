using Octavo.Gate.Nabu.CORE.Entities.Error;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Error
{
    public class ErrorDetailDOL : BaseDOL
    {
        public ErrorDetailDOL() : base ()
        {
        }

        public ErrorDetailDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ErrorDetail Get(int? pErrorDetailID)
        {
            return null;
        }

        public ErrorDetail[] List()
        {
            return null;
        }

        public ErrorDetail Insert(ErrorDetail pErrorDetail)
        {
            return null;
        }

        public ErrorDetail Update(ErrorDetail pErrorDetail)
        {
            return null;
        }

        public ErrorDetail Delete(ErrorDetail pErrorDetail)
        {
            return null;
        }
    }
}
