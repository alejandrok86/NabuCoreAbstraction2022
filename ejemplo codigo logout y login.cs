

///Ver como imnplementar el login 


//UserAccountcontrolller 

/*
         * Este metodo esta duplicado, en el AuthenticationAbstraction consultar con KRIS
         * o si se implementa como un GET consultar con KRIS
         * 
        ///public UserAccountSession EncryptedLogin(string pAccountName, string pUnEncryptedPassword, string pIPAddress, int pLanguageID, bool pUserAccountIDAsExtraSalt)
        //Post 
        // this method Post it is ok?  
        */
        [HttpPost("EncryptedLogin")]
        public IActionResult EncryptedLogin([FromBody] string pAccountName, string pUnEncryptedPassword, string pIPAddress, int pLanguageID, bool pUserAccountIDAsExtraSalt)
        {
            Entities.Authentication.UserAccount userAccount = new Entities.Authentication.UserAccount();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.EncryptedLogin(pAccountName, pUnEncryptedPassword, pIPAddress, pLanguageID,pUserAccountIDAsExtraSalt));
                    }
                    else
                    {

                        userAccount.ErrorsDetected = true;
                        userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccount);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccount.ErrorsDetected = true;
                    userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccount);
                }
            }
            else
            {

                userAccount.ErrorsDetected = true;
                userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountdTo within Header"));
                return Unauthorized(userAccount);
            }
        }

        
 /*
         * 
        // public UserAccountSession Login(string pAccountName, string pPassword, string pIPAddress, int pLanguageID)
        //Post 
        // this method Post it is ok? (to EncryptedLogin)

        */
        [HttpPost("Login")]
        public IActionResult Login([FromBody] string pAccountName, string pPassword, string pIPAddress, int pLanguageID)
        {
            Entities.Authentication.UserAccount userAccount = new Entities.Authentication.UserAccount();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.Login(pAccountName, pPassword,  pIPAddress, pLanguageID));
                    }
                    else
                    {

                        userAccount.ErrorsDetected = true;
                        userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccount);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccount.ErrorsDetected = true;
                    userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccount);
                }
            }
            else
            {

                userAccount.ErrorsDetected = true;
                userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountdTo within Header"));
                return Unauthorized(userAccount);
            }
        }

        

        /// public UserAccountSession Login(string pAccountName, string pPassword, string pIPAddress, int pLanguageID, int pNumberOfDaysBetweenPasswordChange, int pInvalidAttemptsBeforeAccountLock, bool bAllowConcurrentConnections)
        //Post 
        // this method Post it is ok? (to EncryptedLogin)
        [HttpPost("Login")]
        public IActionResult Login([FromBody] string pAccountName, string pPassword, string pIPAddress, int pLanguageID, int pNumberOfDaysBetweenPasswordChange, int pInvalidAttemptsBeforeAccountLock, bool bAllowConcurrentConnections)
        {
            Entities.Authentication.UserAccount userAccount = new Entities.Authentication.UserAccount();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.Login( pAccountName,  pPassword,  pIPAddress,  pLanguageID,  pNumberOfDaysBetweenPasswordChange,  pInvalidAttemptsBeforeAccountLock,  bAllowConcurrentConnections));
                    }
                    else
                    {

                        userAccount.ErrorsDetected = true;
                        userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccount);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccount.ErrorsDetected = true;
                    userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccount);
                }
            }
            else
            {

                userAccount.ErrorsDetected = true;
                userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountdTo within Header"));
                return Unauthorized(userAccount);
            }
        }



        ///ver como pasar al body los parametros, no puedo haber mas de uno , implementar como clase separada
        ///
        //public UserAccountSession Logout(UserAccountSession pUserAccountSession, Entities.System.SessionEndStatus pSessionEndStatus)

        [HttpPost("Logout")]
        public IActionResult Logout([FromBody] Entities.Authentication.UserAccountSession pUserAccountSessionSession, Entities.System.SessionEndStatus pSessionEndStatus, int pLanguageID)
        {
            Entities.Authentication.UserAccountSession userAccountSession = new Entities.Authentication.UserAccountSession();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountSessiondTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountSessiondTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                        
                            ///Bloque de codigo nuevo 
                        if (pSessionEndStatus == null)
                            /// si la estado es NULL entonces crear una nueva sesion
                        {
                          Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SessionEndStatusDOL DOL = new CORE.DOL.MSSQL.System.SessionEndStatusDOL(base.ConnectionString, base.ErrorLogFile);
                            Entities.System.SessionEndStatus sessionEndStatus = DOL.GetByAlias("LOGOUT", pLanguageID);
                                ///crea la sesion en sessionEndStatus = DOL.GetByAlias("LOGOUT", pLanguageID) con los datos del front
                            return Ok(authenticationAbstraction.Logout(pUserAccountSessionSession, sessionEndStatus));
                        }
                        else
                         {
                            return Ok(authenticationAbstraction.Logout(pUserAccountSessionSession, pSessionEndStatus));

                        }
                        
                    }
                    else
                    {

                        userAccountSession.ErrorsDetected = true;
                        userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccountSession);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountSession.ErrorsDetected = true;
                    userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountSession);
                }
            }
            else
            {

                userAccountSession.ErrorsDetected = true;
                userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountSessiondTo within Header"));
                return Unauthorized(userAccountSession);
            }
        }


        