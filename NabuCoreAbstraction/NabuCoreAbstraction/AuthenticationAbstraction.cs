using Octavo.Gate.Nabu.CORE.Entities.Authentication;
using Octavo.Gate.Nabu.CORE.Entities;
using System;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class AuthenticationAbstraction : BaseAbstraction
    {
        public AuthenticationAbstraction() : base()
        {
        }

        public AuthenticationAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Authentication Token
         *********************************************************************/
        public UserAccountSession TokenizedLogin(string pToken, string pLicenseKey, string pLanguage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL authenticationTokenDOL = new CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL(base.ConnectionString, base.ErrorLogFile);
                UserAccountSession userAccountSession = new UserAccountSession();

                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageDOL languageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.Globalisation.Language language = languageDOL.GetBySystemName(pLanguage);
                if(language.LanguageID != null)
                {
                    License accessLicense = GetLicenseByKey(pLicenseKey);
                    if (accessLicense.LicenseID != null)
                    {
                        if (accessLicense.IsActive())
                        {
                            userAccountSession.Language = new Entities.Globalisation.Language(language.LanguageID);
                            userAccountSession.LastAccessDateTime = DateTime.Now;
                            userAccountSession.PrivateKey = "";
                            userAccountSession.SessionStarted = DateTime.Now;
                            userAccountSession.SessionGUID = Guid.NewGuid();
                            userAccountSession.SessionEndStatus = null;
                            userAccountSession.SystemSpecification = null;

                            AuthenticationToken authenticationToken = GetAuthenticationTokenByToken(pToken, (int)language.LanguageID);
                            if (authenticationToken.AuthenticationTokenID != null)
                            {
                                // token exists, so we can proceed
                                userAccountSession.UserDetail = new UserAccount(authenticationToken.Party.PartyID);
                                userAccountSession.UserDetail.AccountStatus = new UserAccountStatus(-1);
                                userAccountSession.UserDetail.AccountName = "NONE";
                                userAccountSession.UserDetail.AccountPassword = "PASSWORD";
                                userAccountSession.UserDetail.AccountStatus.Detail = new Octavo.Gate.Nabu.CORE.Entities.Globalisation.Translation();
                                userAccountSession.UserDetail.AccountStatus.Detail.Alias = "ACTIVE";
                                userAccountSession.UserDetail.ChallengeQuestion = null;
                                userAccountSession.UserDetail.ChallengeQuestionAnswer = null;
                                userAccountSession.UserDetail.IncorrectLoginAttempts = 0;
                                userAccountSession.UserDetail.LastLogonDate = DateTime.Now;
                                userAccountSession.UserDetail.LastPasswordChangedDate = DateTime.Now;
                                userAccountSession.UserDetail.PartyType = new Entities.Core.PartyType(-1);
                                userAccountSession.UserDetail.PINCode = "";
 
                                userAccountSession = InsertUserAccountSession(userAccountSession);
                                if (userAccountSession.UserAccountSessionID != null)
                                {
                                }
                                else
                                {
                                    userAccountSession.ErrorCode = authenticationTokenDOL.GetErrorCodeByAlias("ERR_USERACCOUNTSESSION_CREATE", (int)language.LanguageID);
                                    userAccountSession.ErrorsDetected = true;
                                }
                            }
                            else
                            {
                                // token does not exist, so lets create it
                                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyTypeDOL partyTypeDOL = new CORE.DOL.MSSQL.Core.PartyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                                Entities.Core.PartyType partyType = partyTypeDOL.GetByAlias("UNIDENTIFIED_RESPONDENT", (int)language.LanguageID);
                                if (partyType.PartyTypeID != null)
                                {
                                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyDOL partyDOL = new CORE.DOL.MSSQL.Core.PartyDOL(base.ConnectionString, base.ErrorLogFile);
                                    authenticationToken.Party = new Entities.Core.Party();
                                    authenticationToken.Party.PartyType = new Entities.Core.PartyType(partyType.PartyTypeID);
                                    authenticationToken.Party = partyDOL.Insert(authenticationToken.Party);
                                    if (authenticationToken.Party.PartyID != null)
                                    {
                                        authenticationToken.Token = pToken;
                                        authenticationToken = authenticationTokenDOL.Insert(authenticationToken);
                                        if (authenticationToken.AuthenticationTokenID != null)
                                        {
                                            userAccountSession.UserDetail = new UserAccount(authenticationToken.Party.PartyID);

                                            userAccountSession = InsertUserAccountSession(userAccountSession);
                                            if (userAccountSession.UserAccountSessionID != null)
                                            {
                                            }
                                            else
                                            {
                                                userAccountSession.ErrorCode = authenticationTokenDOL.GetErrorCodeByAlias("ERR_USERACCOUNTSESSION_CREATE", (int)language.LanguageID);
                                                userAccountSession.ErrorsDetected = true;
                                            }
                                        }
                                        else
                                        {
                                            userAccountSession.ErrorCode = authenticationTokenDOL.GetErrorCodeByAlias("ERR_AUTHENTICATIONTOKEN_CREATE", (int)language.LanguageID);
                                            userAccountSession.ErrorsDetected = true;
                                        }
                                    }
                                    else
                                    {
                                        userAccountSession.ErrorCode = authenticationTokenDOL.GetErrorCodeByAlias("ERR_PARTY_CREATE", (int)language.LanguageID);
                                        userAccountSession.ErrorsDetected = true;
                                    }
                                }
                                else
                                {
                                    userAccountSession.ErrorCode = authenticationTokenDOL.GetErrorCodeByAlias("ERR_PARTYTYPE_UNKNOWN", (int)language.LanguageID);
                                    userAccountSession.ErrorsDetected = true;
                                }
                            }
                        }
                        else
                        {
                            userAccountSession.ErrorCode = authenticationTokenDOL.GetErrorCodeByAlias("ERR_LICENSE_INACTIVE", (int)language.LanguageID);
                            userAccountSession.ErrorsDetected = true;
                        }
                    }
                    else
                    {
                        userAccountSession.ErrorCode = authenticationTokenDOL.GetErrorCodeByAlias("ERR_LICENSE_UNKNOWN", (int)language.LanguageID);
                        userAccountSession.ErrorsDetected = true;
                    }
                }
                else
                {
                    userAccountSession.ErrorCode = authenticationTokenDOL.GetErrorCodeByAlias("ERR_GETTING_LANGUAGE", 1);
                    userAccountSession.ErrorsDetected = true;
                }
                if (userAccountSession.ErrorsDetected == false)
                {
                    AuditAbstraction auditAbstraction = new AuditAbstraction(base.ConnectionString, base.DBType, base.ErrorLogFile);
                    Entities.Audit.AuditEvent auditEvent = new Entities.Audit.AuditEvent();
                    auditEvent.AdditionalInformation = "Token [" + pToken + "] License [" + pLicenseKey + "] Language [" + pLanguage + "]";
                    auditEvent.EventOccurredAt = DateTime.Now;
                    auditEvent.AuditEventType = new Entities.Audit.AuditEventType();
                    auditEvent.AuditEventType.Detail = new Entities.Globalisation.Translation();
                    auditEvent.EventDuringSession = new UserAccountSession(userAccountSession.UserAccountSessionID);
                    if (userAccountSession.ErrorsDetected == false)
                    {
                        auditEvent.AuditEventType.AuditEventTypeID = 1;
                        auditEvent.AuditEventType.Detail.Alias = "LOGINSUCCESS";
                    }
                    else
                    {
                        auditEvent.AuditEventType.AuditEventTypeID = 2;
                        auditEvent.AuditEventType.Detail.Alias = "LOGINATTEMPT";
                    }
                    auditAbstraction.InsertAuditEvent(auditEvent);
                }
                return userAccountSession;
            }
            else
                return null;

        }

        public AuthenticationToken GetAuthenticationToken(int pAuthenticationTokenID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL DOL = new CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAuthenticationTokenID, pLanguageID);
            }
            else
                return null;
        }

        public AuthenticationToken GetAuthenticationTokenByToken(string pToken, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL DOL = new CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByToken(pToken, pLanguageID);
            }
            else
                return null;
        }

        public AuthenticationToken[] ListAuthenticationTokens(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL DOL = new CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AuthenticationToken[] ListAuthenticationTokensByPartyID(int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL DOL = new CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForPartyID(pPartyID, pLanguageID);
            }
            else
                return null;
        }

        public AuthenticationToken InsertAuthenticationToken(AuthenticationToken pAuthenticationToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL DOL = new CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAuthenticationToken);
            }
            else
                return null;
        }

        public AuthenticationToken UpdateAuthenticationToken(AuthenticationToken pAuthenticationToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL DOL = new CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAuthenticationToken);
            }
            else
                return null;
        }

        public AuthenticationToken DeleteAuthenticationToken(AuthenticationToken pAuthenticationToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL DOL = new CORE.DOL.MSSQL.Authentication.AuthenticationTokenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAuthenticationToken);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * License
         *********************************************************************/
        public License GetLicense(int pLicenseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.LicenseDOL DOL = new CORE.DOL.MSSQL.Authentication.LicenseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLicenseID);
            }
            else
                return null;
        }

        public License GetLicenseByKey(string pLicenseKey)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.LicenseDOL DOL = new CORE.DOL.MSSQL.Authentication.LicenseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByKey(pLicenseKey);
            }
            else
                return null;
        }

        public License[] ListLicenses()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.LicenseDOL DOL = new CORE.DOL.MSSQL.Authentication.LicenseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public License InsertLicense(License pLicense)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.LicenseDOL DOL = new CORE.DOL.MSSQL.Authentication.LicenseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLicense);
            }
            else
                return null;
        }

        public License UpdateLicense(License pLicense)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.LicenseDOL DOL = new CORE.DOL.MSSQL.Authentication.LicenseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLicense);
            }
            else
                return null;
        }

        public License DeleteLicense(License pLicense)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.LicenseDOL DOL = new CORE.DOL.MSSQL.Authentication.LicenseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLicense);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * User Account
         *********************************************************************/
        ///Es correcto?
        public UserAccountSession EncryptedLogin(string pAccountName, string pUnEncryptedPassword, string pIPAddress, int pLanguageID, bool pUserAccountIDAsExtraSalt)
        {
            return EncryptedLogin(pAccountName, pUnEncryptedPassword, pIPAddress, pLanguageID, 30, 3, true, pUserAccountIDAsExtraSalt);
        }
        ///Es correcto?
        public UserAccountSession EncryptedLogin(string pAccountName, string pUnEncryptedPassword, string pIPAddress, int pLanguageID, int pNumberOfDaysBetweenPasswordChange, int pInvalidAttemptsBeforeAccountLock, bool bAllowConcurrentConnections, bool pUserAccountIDAsExtraSalt)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                UserAccountSession session = new UserAccountSession();

                AuditAbstraction auditAbstraction = new AuditAbstraction(base.ConnectionString, base.DBType, base.ErrorLogFile);

                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountDOL(base.ConnectionString, base.ErrorLogFile);
                session.UserDetail = DOL.GetByName(pAccountName, pLanguageID);
                if (session.UserDetail.ErrorsDetected == false)
                {
                    if (session.UserDetail.PartyID != null)
                    {
                        string encryptedPassword = "";
                        Octavo.Gate.Nabu.CORE.Encryption.EncryptorDecryptor encrypt = new Octavo.Gate.Nabu.CORE.Encryption.EncryptorDecryptor();
                        encrypt.saltValue = encrypt.saltValue += session.UserDetail.PartyID.ToString();
                        encryptedPassword = encrypt.Encrypt(pUnEncryptedPassword);

                        if (session.UserDetail.AccountStatus.Detail.Alias.CompareTo("ACTIVE") == 0)
                        {
                            if (session.UserDetail.IncorrectLoginAttempts < pInvalidAttemptsBeforeAccountLock)
                            {
                                if (session.UserDetail.AccountPassword.CompareTo(encryptedPassword) == 0)
                                {
                                    if (session.UserDetail.LastPasswordChangedDate == null || session.UserDetail.LastPasswordChangedDate.Value.AddDays(pNumberOfDaysBetweenPasswordChange).CompareTo(DateTime.Now) > 0)
                                    {
                                        bool isLicensed = true;
                                        if (session.UserDetail.UserLicense != null)
                                        {
                                            session.UserDetail.UserLicense = GetLicense((int)session.UserDetail.UserLicense.LicenseID);
                                            if (session.UserDetail.UserLicense.ErrorsDetected == false)
                                            {
                                                if (session.UserDetail.UserLicense.IsActive())
                                                    isLicensed = true;
                                                else
                                                {
                                                    session.ErrorsDetected = true;
                                                    if(session.UserDetail.UserLicense.HasExpired())
                                                        session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_LICENSE_EXPIRED", (int)pLanguageID);
                                                    else
                                                        session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_LICENSE_INACTIVE", (int)pLanguageID);
                                                    isLicensed = false;
                                                }
                                            }
                                            else
                                                isLicensed = false;
                                        }
                                        if (isLicensed)
                                        {
                                            if (bAllowConcurrentConnections == false)
                                            {
                                                // check to ensure we have no existing sessions that haven't expired



                                                // if we are all good, setup the session.
                                                session.SessionGUID = Guid.NewGuid();
                                                session.Language = new Entities.Globalisation.Language(pLanguageID);
                                                session.LastAccessDateTime = DateTime.Now;
                                                session.PrivateKey = "";
                                                session.SessionEndStatus = null;
                                                session.SessionStarted = DateTime.Now;
                                            }
                                            else
                                            {
                                                // concurrent connections are allowed
                                                session.SessionGUID = Guid.NewGuid();
                                                session.Language = new Entities.Globalisation.Language(pLanguageID);
                                                session.LastAccessDateTime = DateTime.Now;
                                                session.PrivateKey = "";
                                                session.SessionEndStatus = null;
                                                session.SessionStarted = DateTime.Now;
                                            }
                                            if (pIPAddress != null && pIPAddress.Trim().Length > 0)
                                                session.IPAddress = pIPAddress;
                                            session = InsertUserAccountSession(session);
                                            if (session.UserAccountSessionID != null)
                                            {
                                                session.UserDetail.IncorrectLoginAttempts = 0;
                                                session.UserDetail.LastLogonDate = DateTime.Now;
                                                session.UserDetail = UpdateUserAccount(session.UserDetail);

                                                session.UserDetail.AccountProfiles = ListUserAccountProfiles((int)session.UserDetail.PartyID);
                                                session.UserDetail.UserRoles = ListUserRoles((int)session.UserDetail.PartyID, pLanguageID);

                                                Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                                userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "]";
                                                userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                                userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINSUCCESS", pLanguageID);
                                                userAccountAuditEvent.EventDuringSession = new UserAccountSession(session.UserAccountSessionID);
                                                userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                                auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);
                                            }
                                            else
                                            {
                                                Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                                userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pUnEncryptedPassword + "]";
                                                userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                                userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                                                userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                                auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                                session.UserDetail.PreviousPasswords = ListUserAccountPasswordHistories((int)session.UserDetail.PartyID);

                                                session.UserAccountSessionID = -1;
                                                session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNTSESSION_CREATE", pLanguageID);
                                                session.ErrorsDetected = true;
                                            }
                                        }
                                        else
                                        {
                                            Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                            userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pUnEncryptedPassword + "]";
                                            userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                            userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                                            userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                            auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                            session.UserDetail.PreviousPasswords = ListUserAccountPasswordHistories((int)session.UserDetail.PartyID);

                                            session.UserAccountSessionID = -1;
                                            session.ErrorsDetected = true;
                                            session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_LICENSE_INVALID", pLanguageID);
                                        }
                                    }
                                    else
                                    {
                                        Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                        userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pUnEncryptedPassword + "]";
                                        userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                        userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                                        userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                        auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                        session.UserDetail.PreviousPasswords = ListUserAccountPasswordHistories((int)session.UserDetail.PartyID);

                                        session.UserAccountSessionID = -1;
                                        session.ErrorsDetected = true;
                                        session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_PASSWORD_EXPIRED", pLanguageID);
                                    }
                                }
                                else
                                {
                                    Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                    userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pUnEncryptedPassword + "]";
                                    userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                    userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                                    userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                    auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                    session.UserDetail.IncorrectLoginAttempts++;
                                    session.UserDetail = UpdateUserAccount(session.UserDetail);

                                    session.UserAccountSessionID = -1;
                                    session.ErrorsDetected = true;
                                    session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_PASSWORD_INVALID", pLanguageID);
                                }
                            }
                            else
                            {
                                Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pUnEncryptedPassword + "]";
                                userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                                userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                session.UserDetail.AccountStatus.Detail.Alias = "INACTIVE";
                                session.UserDetail = UpdateUserAccount(session.UserDetail);

                                session.UserAccountSessionID = -1;
                                session.ErrorsDetected = true;
                                session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_LOGIN_ATTEMPTS_EXCEEDED", pLanguageID);
                            }
                        }
                        else if(session.UserDetail.AccountStatus.Detail.Alias.CompareTo("INACTIVE") == 0)
                        {
                            Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                            userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pUnEncryptedPassword + "]";
                            userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                            userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                            userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                            auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                            session.UserAccountSessionID = -1;
                            session.ErrorsDetected = true;
                            session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_INACTIVE", pLanguageID);
                        }
                        else if (session.UserDetail.AccountStatus.Detail.Alias.CompareTo("DEACTIVED") == 0)
                        {
                            Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                            userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pUnEncryptedPassword + "]";
                            userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                            userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                            userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                            auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                            session.UserAccountSessionID = -1;
                            session.ErrorsDetected = true;
                            session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_DEACTIVED", pLanguageID);
                        }
                    }
                    else
                    {
                        Entities.Audit.AuditEvent auditEvent = new Entities.Audit.AuditEvent();
                        auditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password [" + pUnEncryptedPassword + "]";
                        auditEvent.EventOccurredAt = DateTime.Now;
                        auditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                        auditAbstraction.InsertAuditEvent(auditEvent);

                        session.UserAccountSessionID = -1;
                        session.ErrorsDetected = true;
                        session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_NAME_INVALID", pLanguageID);
                    }
                }
                return session;
            }
            else
                return null;
        }

        /// Error
        /// /// consultar con Kris la implementacion
        public UserAccountSession Login(string pAccountName, string pPassword, string pIPAddress, int pLanguageID)
        {
            return Login(pAccountName, pPassword, pIPAddress, pLanguageID, 30, 3, true);
        }

        public UserAccountSession Login(string pAccountName, string pPassword, string pIPAddress, int pLanguageID, int pNumberOfDaysBetweenPasswordChange, int pInvalidAttemptsBeforeAccountLock, bool bAllowConcurrentConnections)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                UserAccountSession session = new UserAccountSession();

                AuditAbstraction auditAbstraction = new AuditAbstraction(base.ConnectionString, base.DBType, base.ErrorLogFile);

                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountDOL(base.ConnectionString, base.ErrorLogFile);
                session.UserDetail = DOL.GetByName(pAccountName, pLanguageID);
                if (session.UserDetail.ErrorsDetected == false)
                {
                    if (session.UserDetail.PartyID != null)
                    {
                        if (session.UserDetail.AccountPassword.CompareTo(pPassword) == 0)
                        {
                            if (session.UserDetail.AccountStatus.Detail.Alias.CompareTo("ACTIVE") == 0)
                            {
                                if (session.UserDetail.IncorrectLoginAttempts < pInvalidAttemptsBeforeAccountLock)
                                {
                                    if (session.UserDetail.LastPasswordChangedDate == null || session.UserDetail.LastPasswordChangedDate.Value.AddDays(pNumberOfDaysBetweenPasswordChange).CompareTo(DateTime.Now) > 0)
                                    {
                                        bool isLicensed = true;
                                        if (session.UserDetail.UserLicense != null)
                                        {
                                            session.UserDetail.UserLicense = GetLicense((int)session.UserDetail.UserLicense.LicenseID);
                                            if (session.UserDetail.UserLicense.ErrorsDetected == false)
                                            {
                                                if (session.UserDetail.UserLicense.IsActive())
                                                {
                                                    isLicensed = true;
                                                }
                                                else
                                                {
                                                    session.ErrorsDetected = true;
                                                    if (session.UserDetail.UserLicense.HasExpired())
                                                        session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_LICENSE_EXPIRED", (int)pLanguageID);
                                                    else
                                                        session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_LICENSE_INACTIVE", (int)pLanguageID);
                                                    isLicensed = false;
                                                }
                                            }
                                            else
                                                isLicensed = false;
                                        }
                                        if (isLicensed)
                                        {
                                            if (bAllowConcurrentConnections == false)
                                            {
                                                // check to ensure we have no existing sessions that haven't expired



                                                // if we are all good, setup the session.
                                                session.SessionGUID = Guid.NewGuid();
                                                session.Language = new Entities.Globalisation.Language(pLanguageID);
                                                session.LastAccessDateTime = DateTime.Now;
                                                session.PrivateKey = "";
                                                session.SessionEndStatus = null;
                                                session.SessionStarted = DateTime.Now;
                                            }
                                            else
                                            {
                                                // concurrent connections are allowed
                                                session.SessionGUID = Guid.NewGuid();
                                                session.Language = new Entities.Globalisation.Language(pLanguageID);
                                                session.LastAccessDateTime = DateTime.Now;
                                                session.PrivateKey = "";
                                                session.SessionEndStatus = null;
                                                session.SessionStarted = DateTime.Now;
                                            }
                                            if (pIPAddress != null && pIPAddress.Trim().Length > 0)
                                                session.IPAddress = pIPAddress;
                                            session = InsertUserAccountSession(session);
                                            if (session.UserAccountSessionID != null)
                                            {
                                                session.UserDetail.IncorrectLoginAttempts = 0;
                                                session.UserDetail.LastLogonDate = DateTime.Now;
                                                session.UserDetail = UpdateUserAccount(session.UserDetail);

                                                session.UserDetail.AccountProfiles = ListUserAccountProfiles((int)session.UserDetail.PartyID);
                                                session.UserDetail.UserRoles = ListUserRoles((int)session.UserDetail.PartyID, pLanguageID);

                                                Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                                userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "]";
                                                userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                                userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINSUCCESS", pLanguageID);
                                                userAccountAuditEvent.EventDuringSession = new UserAccountSession(session.UserAccountSessionID);
                                                userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                                auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);
                                            }
                                            else
                                            {
                                                Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                                userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pPassword + "]";
                                                userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                                userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT",pLanguageID);
                                                userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                                auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                                session.UserDetail.PreviousPasswords = ListUserAccountPasswordHistories((int)session.UserDetail.PartyID);

                                                session.UserAccountSessionID = -1;
                                                session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNTSESSION_CREATE", pLanguageID);
                                                session.ErrorsDetected = true;
                                            }
                                        }
                                        else
                                        {
                                            Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                            userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pPassword + "]";
                                            userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                            userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                                            userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                            auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                            session.UserDetail.PreviousPasswords = ListUserAccountPasswordHistories((int)session.UserDetail.PartyID);

                                            session.UserAccountSessionID = -1;
                                            session.ErrorsDetected = true;
                                            session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_LICENSE_INVALID", pLanguageID);
                                        }
                                    }
                                    else
                                    {
                                        Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                        userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pPassword + "]";
                                        userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                        userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                                        userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                        auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                        session.UserDetail.PreviousPasswords = ListUserAccountPasswordHistories((int)session.UserDetail.PartyID);

                                        session.UserAccountSessionID = -1;
                                        session.ErrorsDetected = true;
                                        session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_PASSWORD_EXPIRED", pLanguageID);
                                    }
                                }
                                else
                                {
                                    Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                    userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pPassword + "]";
                                    userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                    userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                                    userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                    auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                    session.UserDetail.AccountStatus.Detail.Alias = "INACTIVE";
                                    session.UserDetail = UpdateUserAccount(session.UserDetail);

                                    session.UserAccountSessionID = -1;
                                    session.ErrorsDetected = true;
                                    session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_LOGIN_ATTEMPTS_EXCEEDED", pLanguageID);
                                }
                            }
                            else
                            {
                                Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                                userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pPassword + "]";
                                userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                                userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                                userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                                auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                                session.UserAccountSessionID = -1;
                                session.ErrorsDetected = true;
                                session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_INACTIVE", pLanguageID);
                            }
                        }
                        else if (session.UserDetail.AccountStatus.Detail.Alias.CompareTo("INACTIVE") == 0)
                        {
                            Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                            userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password[" + pPassword + "]";
                            userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                            userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                            userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                            auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                            session.UserDetail.IncorrectLoginAttempts++;
                            session.UserDetail = UpdateUserAccount(session.UserDetail);

                            session.UserAccountSessionID = -1;
                            session.ErrorsDetected = true;
                            session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_INACTIVE", pLanguageID);
                        }
                        else if (session.UserDetail.AccountStatus.Detail.Alias.CompareTo("DEACTIVED") == 0)
                        {
                            Entities.Audit.UserAccountAuditEvent userAccountAuditEvent = new Entities.Audit.UserAccountAuditEvent();
                            userAccountAuditEvent.AdditionalInformation = "AccountName [" + pAccountName + "]";
                            userAccountAuditEvent.EventOccurredAt = DateTime.Now;
                            userAccountAuditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                            userAccountAuditEvent.UserAccount = new UserAccount(session.UserDetail.PartyID);
                            auditAbstraction.InsertUserAccountAuditEvent(userAccountAuditEvent);

                            session.UserAccountSessionID = -1;
                            session.ErrorsDetected = true;
                            session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_DEACTIVED", pLanguageID);
                        }
                    }
                    else
                    {
                        Entities.Audit.AuditEvent auditEvent = new Entities.Audit.AuditEvent();
                        auditEvent.AdditionalInformation = "AccountName [" + pAccountName + "] Password [" + pPassword + "]";
                        auditEvent.EventOccurredAt = DateTime.Now;
                        auditEvent.AuditEventType = auditAbstraction.GetAuditEventTypeByAlias("LOGINATTEMPT", pLanguageID);
                        auditAbstraction.InsertAuditEvent(auditEvent);

                        session.UserAccountSessionID = -1;
                        session.ErrorsDetected = true;
                        session.ErrorCode = DOL.GetErrorCodeByAlias("ERR_USERACCOUNT_NAME_INVALID", pLanguageID);
                    }
                }
                return session;
            }
            else
                return null;
        }

        public UserAccount GetUserAccountByName(string pAccountName, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByName(pAccountName, pLanguageID);
            }
            else
                return null;
        }

        public UserAccount GetUserAccountByTelephoneNumber(string pTelephoneNumber, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByTelephoneNumber(pTelephoneNumber, pLanguageID);
            }
            else
                return null;
        }

        public UserAccount GetUserAccount(int pUserAccountID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserAccountID,pLanguageID);
            }
            else
                return null;
        }

        public UserAccount[] ListUserAccounts(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public UserAccount InsertUserAccount(UserAccount pUserAccount)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserAccount);
            }
            else
                return null;
        }

        public UserAccount UpdateUserAccount(UserAccount pUserAccount)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pUserAccount);
            }
            else
                return null;
        }

        public UserAccount DeleteUserAccount(UserAccount pUserAccount)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUserAccount);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * User Account Password History
         *********************************************************************/
        public UserAccountPasswordHistory GetUserAccountPasswordHistory(int pUserAccountPasswordHistoryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountPasswordHistoryDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountPasswordHistoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserAccountPasswordHistoryID);
            }
            else
                return null;
        }

        public UserAccountPasswordHistory[] ListUserAccountPasswordHistories(int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountPasswordHistoryDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountPasswordHistoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pUserAccountID);
            }
            else
                return null;
        }

        public UserAccountPasswordHistory InsertUserAccountPasswordHistory(UserAccountPasswordHistory pUserAccountPasswordHistory, int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountPasswordHistoryDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountPasswordHistoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserAccountPasswordHistory, pUserAccountID);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * User Account Profile
         *********************************************************************/
        public UserAccountProfile GetUserAccountProfile(int pUserAccountProfileID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserAccountProfileID);
            }
            else
                return null;
        }

        public UserAccountProfile[] ListUserAccountProfiles(int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pUserAccountID);
            }
            else
                return null;
        }

        public UserAccountProfile InsertUserAccountProfile(UserAccountProfile pUserAccountProfile, int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserAccountProfile, pUserAccountID);
            }
            else
                return null;
        }

        public UserAccountProfile UpdateUserAccountProfile(UserAccountProfile pUserAccountProfile, int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pUserAccountProfile, pUserAccountID);
            }
            else
                return null;
        }

        public UserAccountProfile DeleteUserAccountProfile(UserAccountProfile pUserAccountProfile)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountProfileDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUserAccountProfile);
            }
            else
                return null;
        }

        /**********************************************************************
         * User Account Question
         *********************************************************************/
        public UserAccountQuestion GetUserAccountQuestion(int pUserAccountQuestionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountQuestionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountQuestionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserAccountQuestionID, pLanguageID);
            }
            else
                return null;
        }

        public UserAccountQuestion InsertUserAccountQuestion(UserAccountQuestion pUserAccountQuestion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountQuestionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountQuestionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserAccountQuestion);
            }
            else
                return null;
        }

        public UserAccountQuestion DeleteUserAccountQuestion(UserAccountQuestion pUserAccountQuestion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountQuestionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountQuestionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUserAccountQuestion);
            }
            else
                return null;
        }

        /**********************************************************************
         * User Account Session
         *********************************************************************/

        /// consultar con Kris la implementacion
        public UserAccountSession Logout(UserAccountSession pUserAccountSession, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SessionEndStatusDOL DOL = new CORE.DOL.MSSQL.System.SessionEndStatusDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.System.SessionEndStatus sessionEndStatus = DOL.GetByAlias("LOGOUT", pLanguageID);
                return Logout(pUserAccountSession, sessionEndStatus);
            }
            else
                return null;
        }

       
        public UserAccountSession Logout(UserAccountSession pUserAccountSession, Entities.System.SessionEndStatus pSessionEndStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL(base.ConnectionString, base.ErrorLogFile);
                pUserAccountSession.SessionEndStatus = pSessionEndStatus;
                return DOL.Update(pUserAccountSession);
            }
            else
                return null;
        }
        /// consultar con Kris la implementacion
        public BaseBoolean UserAccountSessionHeartbeat(int pUserAccountSessionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Heartbeat(pUserAccountSessionID);
            }
            else
                return null;
        }

        public UserAccountSession GetUserAccountSession(int pUserAccountSessionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserAccountSessionID, pLanguageID);
            }
            else
                return null;
        }

        public UserAccountSession[] ListUserAccountSessions(int pUserAccountID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pUserAccountID, pLanguageID);
            }
            else
                return null;
        }

        public UserAccountSession InsertUserAccountSession(UserAccountSession pUserAccountSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserAccountSession);
            }
            else
                return null;
        }

        public UserAccountSession UpdateUserAccountSession(UserAccountSession pUserAccountSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pUserAccountSession);
            }
            else
                return null;
        }

        public UserAccountSession DeleteUserAccountSession(UserAccountSession pUserAccountSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUserAccountSession);
            }
            else
                return null;
        }

        /// consultar con Kris la implementacion

        public BaseBoolean DeleteUserAccountSessions(UserAccount pUserAccount)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteForUserAccount(pUserAccount.PartyID.Value);
            }
            else
                return null;
        }

        /**********************************************************************
         * User Account Status
         *********************************************************************/
        public UserAccountStatus GetUserAccountStatus(int pUserAccountStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserAccountStatusID,pLanguageID);
            }
            else
                return null;
        }

        public UserAccountStatus GetUserAccountStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public UserAccountStatus[] ListUserAccountStatus(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public UserAccountStatus InsertUserAccountStatus(UserAccountStatus pUserAccountStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserAccountStatus);
            }
            else
                return null;
        }

        public UserAccountStatus UpdateUserAccountStatus(UserAccountStatus pUserAccountStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pUserAccountStatus);
            }
            else
                return null;
        }

        public UserAccountStatus DeleteUserAccountStatus(UserAccountStatus pUserAccountStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL DOL = new CORE.DOL.MSSQL.Authentication.UserAccountStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUserAccountStatus);
            }
            else
                return null;
        }

        /**********************************************************************
         * User Configuration
         *********************************************************************/
        public UserConfiguration GetUserConfiguration(int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserConfigurationDOL DOL = new CORE.DOL.MSSQL.Authentication.UserConfigurationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserAccountID);
            }
            else
                return null;
        }

        public UserConfiguration InsertUserConfiguration(UserConfiguration pUserConfiguration, int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserConfigurationDOL DOL = new CORE.DOL.MSSQL.Authentication.UserConfigurationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserConfiguration, pUserAccountID);
            }
            else
                return null;
        }

        public UserConfiguration UpdateUserConfiguration(UserConfiguration pUserConfiguration, int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserConfigurationDOL DOL = new CORE.DOL.MSSQL.Authentication.UserConfigurationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pUserConfiguration, pUserAccountID);
            }
            else
                return null;
        }

        public UserConfiguration DeleteUserConfiguration(int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserConfigurationDOL DOL = new CORE.DOL.MSSQL.Authentication.UserConfigurationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUserAccountID);
            }
            else
                return null;
        }

        /**********************************************************************
         * User Role
         *********************************************************************/
        public UserRole GetUserRole(int pUserRoleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserRoleDOL DOL = new CORE.DOL.MSSQL.Authentication.UserRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserRoleID, pLanguageID);
            }
            else
                return null;
        }

        public UserRole[] ListUserRoles(int pUserAccountID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserRoleDOL DOL = new CORE.DOL.MSSQL.Authentication.UserRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pUserAccountID, pLanguageID);
            }
            else
                return null;
        }

        public UserRole InsertUserRole(UserRole pUserRole, int pUserAccountID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserRoleDOL DOL = new CORE.DOL.MSSQL.Authentication.UserRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserRole, pUserAccountID);
            }
            else
                return null;
        }

        public UserRole DeleteUserRole(UserRole pUserRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication.UserRoleDOL DOL = new CORE.DOL.MSSQL.Authentication.UserRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUserRole);
            }
            else
                return null;
        }
    }
}
