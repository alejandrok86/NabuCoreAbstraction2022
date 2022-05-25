using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.System;
using System.Collections.Generic;
using System;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class SystemAbstraction : BaseAbstraction
    {
        public SystemAbstraction() : base()
        {
        }

        public SystemAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Application Task
         *********************************************************************/
        public ApplicationTask GetApplicationTask(int pApplicationTaskID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTaskDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pApplicationTaskID, pLanguageID);
            }
            else
                return null;
        }

        public ApplicationTask[] ListApplicationTasks(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTaskDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ApplicationTask InsertApplicationTask(ApplicationTask pApplicationTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTaskDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pApplicationTask);
            }
            else
                return null;
        }

        public ApplicationTask UpdateApplicationTask(ApplicationTask pApplicationTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTaskDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pApplicationTask);
            }
            else
                return null;
        }

        public ApplicationTask DeleteApplicationTask(ApplicationTask pApplicationTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTaskDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pApplicationTask);
            }
            else
                return null;
        }

        /**********************************************************************
         * Application Team
         *********************************************************************/
        public ApplicationTeam GetApplicationTeam(int pApplicationTeamID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTeamDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTeamDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pApplicationTeamID, pLanguageID);
            }
            else
                return null;
        }

        public ApplicationTeam[] ListApplicationTeams(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTeamDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTeamDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ApplicationTeam InsertApplicationTeam(ApplicationTeam pApplicationTeam)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTeamDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTeamDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pApplicationTeam);
            }
            else
                return null;
        }

        public ApplicationTeam UpdateApplicationTeam(ApplicationTeam pApplicationTeam)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTeamDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTeamDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pApplicationTeam);
            }
            else
                return null;
        }

        public ApplicationTeam DeleteApplicationTeam(ApplicationTeam pApplicationTeam)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTeamDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTeamDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pApplicationTeam);
            }
            else
                return null;
        }

        public SystemRole AssignApplicationTeamSystemRole(int pApplicationTeamID, int pSystemRoleID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTeamDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTeamDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pApplicationTeamID, pSystemRoleID);
            }
            else
                return null;
        }

        public SystemRole RemoveApplicationTeamSystemRole(int pApplicationTeamID, int pSystemRoleID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ApplicationTeamDOL DOL = new CORE.DOL.MSSQL.System.ApplicationTeamDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pApplicationTeamID, pSystemRoleID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Assembly
         *********************************************************************/
        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly GetAssembly(int pAssemblyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.AssemblyDOL DOL = new CORE.DOL.MSSQL.System.AssemblyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAssemblyID, pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly[] ListAssemblies(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.AssemblyDOL DOL = new CORE.DOL.MSSQL.System.AssemblyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly InsertAssembly(Octavo.Gate.Nabu.CORE.Entities.System.Assembly pAssembly)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.AssemblyDOL DOL = new CORE.DOL.MSSQL.System.AssemblyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAssembly);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly UpdateAssembly(Octavo.Gate.Nabu.CORE.Entities.System.Assembly pAssembly)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.AssemblyDOL DOL = new CORE.DOL.MSSQL.System.AssemblyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAssembly);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Assembly DeleteAssembly(Octavo.Gate.Nabu.CORE.Entities.System.Assembly pAssembly)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.AssemblyDOL DOL = new CORE.DOL.MSSQL.System.AssemblyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAssembly);
            }
            else
                return null;
        }

        /**********************************************************************
         * Functional Area
         *********************************************************************/
        public FunctionalArea GetFunctionalArea(int pFunctionalAreaID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.FunctionalAreaDOL DOL = new CORE.DOL.MSSQL.System.FunctionalAreaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pFunctionalAreaID, pLanguageID);
            }
            else
                return null;
        }

        public FunctionalArea[] ListFunctionalAreas(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.FunctionalAreaDOL DOL = new CORE.DOL.MSSQL.System.FunctionalAreaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public FunctionalArea InsertFunctionalArea(FunctionalArea pFunctionalArea)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.FunctionalAreaDOL DOL = new CORE.DOL.MSSQL.System.FunctionalAreaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pFunctionalArea);
            }
            else
                return null;
        }

        public FunctionalArea UpdateFunctionalArea(FunctionalArea pFunctionalArea)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.FunctionalAreaDOL DOL = new CORE.DOL.MSSQL.System.FunctionalAreaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pFunctionalArea);
            }
            else
                return null;
        }

        public FunctionalArea DeleteFunctionalArea(FunctionalArea pFunctionalArea)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.FunctionalAreaDOL DOL = new CORE.DOL.MSSQL.System.FunctionalAreaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pFunctionalArea);
            }
            else
                return null;
        }

        /**********************************************************************
         * Locale
         *********************************************************************/
        public Octavo.Gate.Nabu.CORE.Entities.System.Locale GetLocale(int pLocaleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.LocaleDOL DOL = new CORE.DOL.MSSQL.System.LocaleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLocaleID, pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Locale[] ListLocales(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.LocaleDOL DOL = new CORE.DOL.MSSQL.System.LocaleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Locale InsertLocale(Octavo.Gate.Nabu.CORE.Entities.System.Locale pLocale)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.LocaleDOL DOL = new CORE.DOL.MSSQL.System.LocaleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLocale);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Locale UpdateLocale(Octavo.Gate.Nabu.CORE.Entities.System.Locale pLocale)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.LocaleDOL DOL = new CORE.DOL.MSSQL.System.LocaleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLocale);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Locale DeleteLocale(Octavo.Gate.Nabu.CORE.Entities.System.Locale pLocale)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.LocaleDOL DOL = new CORE.DOL.MSSQL.System.LocaleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLocale);
            }
            else
                return null;
        }

        /**********************************************************************
         * Module
         *********************************************************************/
        public Octavo.Gate.Nabu.CORE.Entities.System.Module GetModule(int pModuleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ModuleDOL DOL = new CORE.DOL.MSSQL.System.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pModuleID, pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Module[] ListModules(int pAssembyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ModuleDOL DOL = new CORE.DOL.MSSQL.System.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAssembyID, pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Module InsertModule(Octavo.Gate.Nabu.CORE.Entities.System.Module pModule, int pAssemblyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ModuleDOL DOL = new CORE.DOL.MSSQL.System.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pModule, pAssemblyID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Module UpdateModule(Octavo.Gate.Nabu.CORE.Entities.System.Module pModule, int pAssemblyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ModuleDOL DOL = new CORE.DOL.MSSQL.System.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pModule, pAssemblyID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Module DeleteModule(Octavo.Gate.Nabu.CORE.Entities.System.Module pModule)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ModuleDOL DOL = new CORE.DOL.MSSQL.System.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pModule);
            }
            else
                return null;
        }

        /**********************************************************************
         * Screen
         *********************************************************************/
        public Octavo.Gate.Nabu.CORE.Entities.System.Screen GetScreen(int pScreenID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenDOL DOL = new CORE.DOL.MSSQL.System.ScreenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pScreenID, pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen[] ListScreens(int pModuleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenDOL DOL = new CORE.DOL.MSSQL.System.ScreenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pModuleID, pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen InsertScreen(Octavo.Gate.Nabu.CORE.Entities.System.Screen pScreen, int pModuleID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenDOL DOL = new CORE.DOL.MSSQL.System.ScreenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pScreen, pModuleID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen UpdateScreen(Octavo.Gate.Nabu.CORE.Entities.System.Screen pScreen, int pModuleID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenDOL DOL = new CORE.DOL.MSSQL.System.ScreenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pScreen, pModuleID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen DeleteScreen(Octavo.Gate.Nabu.CORE.Entities.System.Screen pScreen)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenDOL DOL = new CORE.DOL.MSSQL.System.ScreenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pScreen);
            }
            else
                return null;
        }

        /**********************************************************************
         * Screen Element
         *********************************************************************/
        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement GetScreenElement(int pScreenElementID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenElementDOL DOL = new CORE.DOL.MSSQL.System.ScreenElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pScreenElementID, pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement[] ListScreenElements(int pScreenID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenElementDOL DOL = new CORE.DOL.MSSQL.System.ScreenElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pScreenID, pLanguageID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement[] ListScreenElements(string pAssemblyName, string pModuleName, string pScreenName, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenElementDOL DOL = new CORE.DOL.MSSQL.System.ScreenElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAssemblyName, pModuleName, pScreenName, pLanguageID);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement InsertScreenElement(Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement pScreenElement, int pScreenID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenElementDOL DOL = new CORE.DOL.MSSQL.System.ScreenElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pScreenElement, pScreenID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement UpdateScreenElement(Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement pScreenElement, int pScreenID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenElementDOL DOL = new CORE.DOL.MSSQL.System.ScreenElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pScreenElement, pScreenID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement[] UpdateScreenElements(string pAssemblyName, string pModuleName, string pScreenName, int pLanguageID, Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement[] pScreenElements)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                if (pScreenElements != null)
                {
                    if (pScreenElements.Length > 0)
                    {
                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.AssemblyDOL assemblyDOL = new CORE.DOL.MSSQL.System.AssemblyDOL(base.ConnectionString, base.ErrorLogFile);
                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ModuleDOL moduleDOL = new CORE.DOL.MSSQL.System.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenDOL screenDOL = new CORE.DOL.MSSQL.System.ScreenDOL(base.ConnectionString, base.ErrorLogFile);
                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenElementDOL screenElementDOL = new CORE.DOL.MSSQL.System.ScreenElementDOL(base.ConnectionString, base.ErrorLogFile);

                        Assembly assembly = assemblyDOL.GetByName(pAssemblyName, pLanguageID);
                        if (assembly.ErrorsDetected == false)
                        {
                            if (assembly.AssemblyID == null)
                            {
                                assembly.DefaultLanguage = new Entities.Globalisation.Language(pLanguageID);
                                assembly.Name = pAssemblyName;
                                assembly = assemblyDOL.Insert(assembly);
                            }
                            if (assembly.ErrorsDetected == false)
                            {
                                Module module = moduleDOL.GetByName((int)assembly.AssemblyID, pModuleName);
                                if (module.ErrorsDetected == false)
                                {
                                    if (module.ModuleID == null)
                                    {
                                        module.Name = pModuleName;
                                        module.FromDate = DateTime.Now;
                                        module = moduleDOL.Insert(module, (int)assembly.AssemblyID);
                                    }
                                    if (module.ErrorsDetected == false)
                                    {
                                        Screen screen = screenDOL.GetByName((int)module.ModuleID, pScreenName);
                                        if (screen.ErrorsDetected == false)
                                        {
                                            if (screen.ScreenID == null)
                                            {
                                                screen.Name = pScreenName;
                                                screen = screenDOL.Insert(screen, (int)module.ModuleID);
                                            }
                                            if (screen.ErrorsDetected == false)
                                            {
                                                List<Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement> screenElements = new List<Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement>();
                                                foreach (Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement screenElement in pScreenElements)
                                                {
                                                    if (screenElement.ScreenElementID == null)
                                                        screenElements.Add(screenElementDOL.Insert(screenElement, (int)screen.ScreenID));
                                                    else
                                                        screenElements.Add(screenElementDOL.Update(screenElement, (int)screen.ScreenID));
                                                }
                                                return screenElements.ToArray();
                                            }
                                            else
                                                return null;
                                        }
                                        else
                                            return null;
                                    }
                                    else
                                        return null;
                                }
                                else
                                    return null;
                            }
                            else
                                return null;
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement DeleteScreenElement(Octavo.Gate.Nabu.CORE.Entities.System.ScreenElement pScreenElement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.ScreenElementDOL DOL = new CORE.DOL.MSSQL.System.ScreenElementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pScreenElement);
            }
            else
                return null;
        }

        /**********************************************************************
         * Session End Status
         *********************************************************************/
        public SessionEndStatus GetSessionEndStatus(int pSessionEndStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SessionEndStatusDOL DOL = new CORE.DOL.MSSQL.System.SessionEndStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSessionEndStatusID, pLanguageID);
            }
            else
                return null;
        }

        public SessionEndStatus[] ListSessionEndStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SessionEndStatusDOL DOL = new CORE.DOL.MSSQL.System.SessionEndStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public SessionEndStatus InsertSessionEndStatus(SessionEndStatus pSessionEndStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SessionEndStatusDOL DOL = new CORE.DOL.MSSQL.System.SessionEndStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSessionEndStatus);
            }
            else
                return null;
        }

        public SessionEndStatus UpdateSessionEndStatus(SessionEndStatus pSessionEndStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SessionEndStatusDOL DOL = new CORE.DOL.MSSQL.System.SessionEndStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSessionEndStatus);
            }
            else
                return null;
        }

        public SessionEndStatus DeleteSessionEndStatus(SessionEndStatus pSessionEndStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SessionEndStatusDOL DOL = new CORE.DOL.MSSQL.System.SessionEndStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSessionEndStatus);
            }
            else
                return null;
        }

        /**********************************************************************
         * System Role
         *********************************************************************/
        public SystemRole AssignSystemRole(SystemRole pSystemRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemRoleDOL DOL = new CORE.DOL.MSSQL.System.SystemRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pSystemRole);
            }
            else
                return null;
        }

        public SystemRole RemoveSystemRole(SystemRole pSystemRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemRoleDOL DOL = new CORE.DOL.MSSQL.System.SystemRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pSystemRole);
            }
            else
                return null;
        }

        /**********************************************************************
         * System Specification Disk
         *********************************************************************/
        public SystemSpecificationDisk GetSystemSpecificationDisk(int? pSystemSpecificationDiskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSystemSpecificationDiskID);
            }
            else
                return null;
        }

        public SystemSpecificationDisk[] ListSystemSpecificationDisks(int pSystemSpecificationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public SystemSpecificationDisk InsertSystemSpecificationDisk(SystemSpecificationDisk pSystemSpecificationDisk)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSystemSpecificationDisk);
            }
            else
                return null;
        }

        public SystemSpecificationDisk UpdateSystemSpecificationDisk(SystemSpecificationDisk pSystemSpecificationDisk)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSystemSpecificationDisk);
            }
            else
                return null;
        }

        public SystemSpecificationDisk DeleteSystemSpecificationDisk(SystemSpecificationDisk pSystemSpecificationDisk)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSystemSpecificationDisk);
            }
            else
                return null;
        }

        /**********************************************************************
         * System Specification
         *********************************************************************/
        public SystemSpecification GetSystemSpecification(int? pSystemSpecificationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSystemSpecificationID);
            }
            else
                return null;
        }

        public SystemSpecification[] ListSystemSpecifications()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public SystemSpecification InsertSystemSpecification(SystemSpecification pSystemSpecification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSystemSpecification);
            }
            else
                return null;
        }

        public SystemSpecification UpdateSystemSpecification(SystemSpecification pSystemSpecification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSystemSpecification);
            }
            else
                return null;
        }

        public SystemSpecification DeleteSystemSpecification(SystemSpecification pSystemSpecification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SystemSpecificationDOL DOL = new CORE.DOL.MSSQL.System.SystemSpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSystemSpecification);
            }
            else
                return null;
        }

        /**********************************************************************
         * User Interface Skin
         *********************************************************************/
        public UserInterfaceSkin GetUserInterfaceSkin(int pUserInterfaceSkinID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.UserInterfaceSkinDOL DOL = new CORE.DOL.MSSQL.System.UserInterfaceSkinDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserInterfaceSkinID, pLanguageID);
            }
            else
                return null;
        }

        public UserInterfaceSkin[] ListUserInterfaceSkins(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.UserInterfaceSkinDOL DOL = new CORE.DOL.MSSQL.System.UserInterfaceSkinDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public UserInterfaceSkin InsertUserInterfaceSkin(UserInterfaceSkin pUserInterfaceSkin)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.UserInterfaceSkinDOL DOL = new CORE.DOL.MSSQL.System.UserInterfaceSkinDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserInterfaceSkin);
            }
            else
                return null;
        }

        public UserInterfaceSkin UpdateUserInterfaceSkin(UserInterfaceSkin pUserInterfaceSkin)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.UserInterfaceSkinDOL DOL = new CORE.DOL.MSSQL.System.UserInterfaceSkinDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pUserInterfaceSkin);
            }
            else
                return null;
        }

        public UserInterfaceSkin DeleteUserInterfaceSkin(UserInterfaceSkin pUserInterfaceSkin)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.UserInterfaceSkinDOL DOL = new CORE.DOL.MSSQL.System.UserInterfaceSkinDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUserInterfaceSkin);
            }
            else
                return null;
        }
    }
}
