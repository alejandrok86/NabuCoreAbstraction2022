using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Octavo.Gate.Nabu.CORE.API.Helper
{
    public class APIAccessKey : BaseType
    {
        public string KeyGUID = "";
        public string LicensedTo = "";
        public DateTime ActiveFrom = DateTime.Parse("1980/1/1 00:00:00");
        public DateTime ActiveTo = DateTime.Parse("1980/1/1 00:00:00");
        public bool AuditActivity = false;
        public bool InvokeProtectedMethods = false;
        public bool InvokePrivateMethods = false;

        public APIAccessKey()
        {
        }
        public APIKeyState ValidateKey(string pConfigFileFile, string pAPIAccessKey, string pLicensedTo)
        {
            APIKeyState returnCode = APIKeyState.ProcessingConfigFile;

            bool KeyFound = false;

            if (File.Exists(pConfigFileFile))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(pConfigFileFile);
                    foreach (XmlNode node in doc.ChildNodes)
                    {
                        if (node.Name.ToString().CompareTo("nabu") == 0)
                        {
                            foreach (XmlElement child in node.ChildNodes)
                            {
                                if (child.Name.ToString().CompareTo("APIAccessKeys") == 0)
                                {
                                    foreach (XmlElement key in child.ChildNodes)
                                    {
                                        if (key.Name.ToString().CompareTo("key") == 0)
                                        {
                                            string guid = null;
                                            string licensedTo = null;
                                            DateTime? activeFrom = null;
                                            DateTime? activeTo = null;
                                            bool auditActivity =false;
                                            bool invokeProtectedMethods = false;
                                            bool invokePrivateMethods = false;
                                            foreach (XmlAttribute attrib in key.Attributes)
                                            {
                                                if (attrib.Name.ToString().CompareTo("id") == 0)
                                                {
                                                    guid = attrib.Value.ToString();
                                                }
                                                else if (attrib.Name.ToString().CompareTo("LicensedTo") == 0)
                                                {
                                                    licensedTo = attrib.Value.ToString();
                                                }
                                                else if (attrib.Name.ToString().CompareTo("ActiveFrom") == 0)
                                                {
                                                    activeFrom = DateTime.Parse(attrib.Value.ToString());
                                                }
                                                else if (attrib.Name.ToString().CompareTo("ActiveTo") == 0)
                                                {
                                                    activeTo = DateTime.Parse(attrib.Value.ToString());
                                                }
                                                else if (attrib.Name.ToString().CompareTo("AuditActivity") == 0)
                                                {
                                                    auditActivity = ((attrib.Value.ToString().ToLower().CompareTo("true") == 0) ? true : false);
                                                }
                                                else if (attrib.Name.ToString().CompareTo("InvokeProtectedMethods") == 0)
                                                {
                                                    invokeProtectedMethods = ((attrib.Value.ToString().ToLower().CompareTo("true") == 0) ? true : false);
                                                }
                                                else if (attrib.Name.ToString().CompareTo("InvokePrivateMethods") == 0)
                                                {
                                                    invokePrivateMethods = ((attrib.Value.ToString().ToLower().CompareTo("true") == 0) ? true : false);
                                                }
                                            }

                                            // now compare the key
                                            if (guid.Length > 0)
                                            {
                                                if (guid.CompareTo(pAPIAccessKey) == 0)
                                                {
                                                    if (licensedTo.ToLower().CompareTo(pLicensedTo.ToLower()) == 0)
                                                    {
                                                        this.KeyGUID = guid;
                                                        this.LicensedTo = licensedTo;
                                                        if (activeFrom.HasValue)
                                                            this.ActiveFrom = activeFrom.Value;
                                                        if (activeTo.HasValue)
                                                            this.ActiveTo = activeTo.Value;
                                                        this.AuditActivity = auditActivity;
                                                        this.InvokeProtectedMethods = invokeProtectedMethods;
                                                        this.InvokePrivateMethods = invokePrivateMethods;

                                                        KeyFound = true;
                                                        if ((this.ActiveFrom.CompareTo(DateTime.Now) < 0) && (this.ActiveTo.CompareTo(DateTime.Now) > 0))
                                                        {
                                                            returnCode = APIKeyState.KeyValidAccessGranted;
                                                        }
                                                        else
                                                            returnCode = APIKeyState.KeyInvalidOutsideActivePeriod;
                                                        break;
                                                    }
                                                    else
                                                        returnCode = APIKeyState.KeyInvalidPairMismatch;
                                                }
                                            }
                                        }
                                        if (KeyFound == true)
                                            break;
                                    }
                                }
                                if (KeyFound == true)
                                    break;
                            }
                        }
                        if (KeyFound == true)
                            break;
                    }
                    if (KeyFound == false && returnCode == APIKeyState.ProcessingConfigFile)
                        returnCode = APIKeyState.KeyInvalidUnknown;
                }
                catch (Exception e)
                {
                    string message = e.Message;
                }
            }
            else
                returnCode = APIKeyState.KeyInvalidConfigAccessError;
            return returnCode;
        }
        public APIKeyState ValidateKey(string pConfigFileFile, string pAPIAccessKey)
        {
            APIKeyState returnCode = APIKeyState.ProcessingConfigFile;

            bool KeyFound = false;

            if (File.Exists(pConfigFileFile))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(pConfigFileFile);
                    foreach (XmlNode node in doc.ChildNodes)
                    {
                        if (node.Name.ToString().CompareTo("nabu") == 0)
                        {
                            foreach (XmlElement child in node.ChildNodes)
                            {
                                if (child.Name.ToString().CompareTo("APIAccessKeys") == 0)
                                {
                                    foreach (XmlElement key in child.ChildNodes)
                                    {
                                        if (key.Name.ToString().CompareTo("key") == 0)
                                        {
                                            string guid = null;
                                            string licensedTo = null;
                                            DateTime? activeFrom = null;
                                            DateTime? activeTo = null;
                                            bool auditActivity = false;
                                            bool invokeProtectedMethods = false;
                                            bool invokePrivateMethods = false;
                                            foreach (XmlAttribute attrib in key.Attributes)
                                            {
                                                if (attrib.Name.ToString().CompareTo("id") == 0)
                                                {
                                                    guid = attrib.Value.ToString();
                                                }
                                                else if (attrib.Name.ToString().CompareTo("LicensedTo") == 0)
                                                {
                                                    licensedTo = attrib.Value.ToString();
                                                }
                                                else if (attrib.Name.ToString().CompareTo("ActiveFrom") == 0)
                                                {
                                                    activeFrom = DateTime.Parse(attrib.Value.ToString());
                                                }
                                                else if (attrib.Name.ToString().CompareTo("ActiveTo") == 0)
                                                {
                                                    activeTo = DateTime.Parse(attrib.Value.ToString());
                                                }
                                                else if (attrib.Name.ToString().CompareTo("AuditActivity") == 0)
                                                {
                                                    auditActivity = ((attrib.Value.ToString().ToLower().CompareTo("true") == 0) ? true : false);
                                                }
                                                else if (attrib.Name.ToString().CompareTo("InvokeProtectedMethods") == 0)
                                                {
                                                    invokeProtectedMethods = ((attrib.Value.ToString().ToLower().CompareTo("true") == 0) ? true : false);
                                                }
                                                else if (attrib.Name.ToString().CompareTo("InvokePrivateMethods") == 0)
                                                {
                                                    invokePrivateMethods = ((attrib.Value.ToString().ToLower().CompareTo("true") == 0) ? true : false);
                                                }
                                            }

                                            // now compare the key
                                            if (guid.Length > 0)
                                            {
                                                if (guid.CompareTo(pAPIAccessKey) == 0)
                                                {
                                                    this.KeyGUID = guid;
                                                    this.LicensedTo = licensedTo;
                                                    if (activeFrom.HasValue)
                                                        this.ActiveFrom = activeFrom.Value;
                                                    if (activeTo.HasValue)
                                                        this.ActiveTo = activeTo.Value;
                                                    this.AuditActivity = auditActivity;
                                                    this.InvokeProtectedMethods = invokeProtectedMethods;
                                                    this.InvokePrivateMethods = invokePrivateMethods;

                                                    KeyFound = true;
                                                    if ((this.ActiveFrom.CompareTo(DateTime.Now) < 0) && (this.ActiveTo.CompareTo(DateTime.Now) > 0))
                                                    {
                                                        returnCode = APIKeyState.KeyValidAccessGranted;
                                                    }
                                                    else
                                                        returnCode = APIKeyState.KeyInvalidOutsideActivePeriod;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (KeyFound == true)
                                        break;
                                }
                            }
                            if (KeyFound == true)
                                break;
                        }
                    }
                    if (KeyFound == false && returnCode == APIKeyState.ProcessingConfigFile)
                        returnCode = APIKeyState.KeyInvalidUnknown;
                }
                catch (Exception e)
                {
                    string message = e.Message;
                }
            }
            else
                returnCode = APIKeyState.KeyInvalidConfigAccessError;
            return returnCode;
        }
        public APIAccessKey[] List(string pConfigFileFile)
        {
            List<APIAccessKey> keys = new List<APIAccessKey>();

            if (File.Exists(pConfigFileFile))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(pConfigFileFile);
                    foreach (XmlNode node in doc.ChildNodes)
                    {
                        if (node.Name.ToString().CompareTo("nabu") == 0)
                        {
                            foreach (XmlElement child in node.ChildNodes)
                            {
                                if (child.Name.ToString().CompareTo("APIAccessKeys") == 0)
                                {
                                    foreach (XmlElement key in child.ChildNodes)
                                    {
                                        APIAccessKey registeredKey = new APIAccessKey();
                                        registeredKey.KeyGUID = "";
                                        registeredKey.LicensedTo = "";
                                        registeredKey.ActiveFrom = DateTime.Parse("1980/1/1 00:00:00");
                                        registeredKey.ActiveTo = DateTime.Parse("1980/1/1 00:00:00"); ;
                                        registeredKey.AuditActivity = false;

                                        if (key.Name.ToString().CompareTo("key") == 0)
                                        {
                                            foreach (XmlAttribute attrib in key.Attributes)
                                            {
                                                if (attrib.Name.ToString().CompareTo("id") == 0)
                                                {
                                                    registeredKey.KeyGUID = attrib.Value.ToString();
                                                }
                                                else if (attrib.Name.ToString().CompareTo("LicensedTo") == 0)
                                                {
                                                    registeredKey.LicensedTo = attrib.Value.ToString();
                                                }
                                                else if (attrib.Name.ToString().CompareTo("ActiveFrom") == 0)
                                                {
                                                    registeredKey.ActiveFrom = DateTime.Parse(attrib.Value.ToString());
                                                }
                                                else if (attrib.Name.ToString().CompareTo("ActiveTo") == 0)
                                                {
                                                    registeredKey.ActiveTo = DateTime.Parse(attrib.Value.ToString());
                                                }
                                                else if (attrib.Name.ToString().CompareTo("AuditActivity") == 0)
                                                {
                                                    registeredKey.AuditActivity = ((attrib.Value.ToString().ToLower().CompareTo("true") == 0) ? true : false);
                                                }
                                                else if (attrib.Name.ToString().CompareTo("InvokeProtectedMethods") == 0)
                                                {
                                                    registeredKey.InvokeProtectedMethods = ((attrib.Value.ToString().ToLower().CompareTo("true") == 0) ? true : false);
                                                }
                                                else if (attrib.Name.ToString().CompareTo("InvokePrivateMethods") == 0)
                                                {
                                                    registeredKey.InvokePrivateMethods = ((attrib.Value.ToString().ToLower().CompareTo("true") == 0) ? true : false);
                                                }
                                            }
                                        }

                                        keys.Add(registeredKey);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    APIAccessKey error = new APIAccessKey();
                    error.ErrorsDetected = true;
                    error.ErrorDetails.Add(new ErrorDetail(-1, exc.Message));
                    keys.Add(error);
                }
            }
            return keys.ToArray();
        }
        public void AuditAccess(string pAuditFolder, string pServiceName, string pMethodName, string pOptionalText)
        {
            if (this.LicensedTo.Length == 0)
                this.LicensedTo = "unknown";

            if (System.IO.Directory.Exists(pAuditFolder))
            {
                using (StreamWriter audit = new StreamWriter(pAuditFolder + "\\" + this.LicensedTo + DateTime.Now.ToString("yyyyMMdd") + ".xml", true))
                {
                    audit.WriteLine("<audit at=\"" + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss:fff") + "\" service=\"" + pServiceName + "\" method=\"" + pMethodName + "\" optional=\"" + pOptionalText + "\" />");
                    audit.Close();
                }
            }
        }
        public void AuditAccess(string pAuditFolder, string pServiceName, string pMethodName, string pOptionalText, string pOriginatorsIP, string pOriginatorsUserAgent)
        {
            if (this.LicensedTo.Length == 0)
                this.LicensedTo = "unknown";

            if (System.IO.Directory.Exists(pAuditFolder))
            {
                using (StreamWriter audit = new StreamWriter(pAuditFolder + "\\" + this.LicensedTo + DateTime.Now.ToString("yyyyMMdd") + ".xml", true))
                {
                    audit.WriteLine("<audit at=\"" + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss:fff") + "\" service=\"" + pServiceName + "\" method=\"" + pMethodName + "\" optional=\"" + pOptionalText + "\" ipAddress=\"" + pOriginatorsIP + "\" userAgent=\"" + pOriginatorsUserAgent + "\" />");
                    audit.Close();
                }
            }
        }
    }

    public enum APIKeyState
    {
        KeyValidAccessGranted,
        KeyInvalidOutsideActivePeriod,
        KeyInvalidUnknown,
        KeyInvalidConfigAccessError,
        KeyInvalidPairMismatch,
        ProcessingConfigFile
    }
}