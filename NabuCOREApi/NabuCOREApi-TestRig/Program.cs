using Octavo.Gate.Nabu.CORE.Entities;
using System;

namespace Octavo.Gate.Nabu.CORE.API.Test.Rig
{
    class Program
    {
        static void Main(string[] args)
        {
            // Blazor Certify
            //ADS.Limathon.CORE.iBlips.To.Certify.Interaction.Manager blipsCertifyInterface = new ADS.Limathon.CORE.iBlips.To.Certify.Interaction.Manager("https://nabu-api-test.i-blips.com", "b5add9816d54474595eb4baeed0959a9", "OctavoGate", "https://test.i-blips.com/Generate/Certificate",true);

            Nabu.CORE.API.SDK.Globalisation.Language languageSDK = new SDK.Globalisation.Language("http://nabu-api.octavogate.com", "b5add9816d54474595eb4baeed0959a9", "OctavoGate");
            //Octavo.Gate.Nabu.CORE.Entities.BaseVersion languageAPIVersion = languageSDK.GetVersion();
            Octavo.Gate.Nabu.CORE.Entities.Globalisation.Language[] languages = languageSDK.ListLanguages();
            Octavo.Gate.Nabu.CORE.Entities.Globalisation.Language englishLanguage = languageSDK.GetLanguageBySystemName("English");

            Nabu.CORE.API.SDK.Education.AwardingBody awardingBodySDK = new SDK.Education.AwardingBody("http://nabu-api.octavogate.com", "b5add9816d54474595eb4baeed0959a9", "OctavoGate");
            Octavo.Gate.Nabu.CORE.Entities.BaseVersion awardingBodyAPIVersion = awardingBodySDK.GetVersion();
            Octavo.Gate.Nabu.CORE.Entities.Education.AwardingBody[] awardingBodies = awardingBodySDK.ListAwardingBodies(englishLanguage.LanguageID.Value);

            Nabu.CORE.API.SDK.Education.Specification specificationSDK = new SDK.Education.Specification("http://nabu-api.octavogate.com", "b5add9816d54474595eb4baeed0959a9", "OctavoGate");
            Octavo.Gate.Nabu.CORE.Entities.BaseVersion specificationAPIVersion = specificationSDK.GetVersion();
            Octavo.Gate.Nabu.CORE.Entities.Education.Specification[] specifications = specificationSDK.ListSpecifications(awardingBodies[0].PartyID.Value,englishLanguage.LanguageID.Value);
            Octavo.Gate.Nabu.CORE.Entities.Content.Content[] specificationContent = specificationSDK.ListContent(specifications[0].SpecificationID.Value);


            //Nabu.CORE.API.SDK.NabuProducts.Certify certifySDK = new SDK.NabuProducts.Certify("https://nabu-api-vay.i-blips.com", "b5add9816d54474595eb4baeed0959a9", "OctavoGate");
            //BaseString certificateURL = certifySDK.GetPNGCertificate(15564);

            // ASP Certify
            /*ADS.Limathon.CORE.iBlips.To.Certify.Interaction.Manager blipsCertifyInterface = new ADS.Limathon.CORE.iBlips.To.Certify.Interaction.Manager("https://nabu-api-test.i-blips.com", "b5add9816d54474595eb4baeed0959a9", "OctavoGate", "https://test.i-blips.com/Certify/LoggedOut/OEMCertificate.aspx");//,false);
            int blipsEnvironmentID = 1;
            int blipsUserId = 238;
            blipsCertifyInterface.Initialise(blipsEnvironmentID, blipsUserId, "ASP");
            if (blipsCertifyInterface.ErrorsDetected == false)
            {
                bool first = true;
                foreach (ADS.Limathon.CORE.iBlips.To.Certify.Interaction.BlipsCertifyRecord learningAndExamRecord in blipsCertifyInterface.LearningAndExamRecords)
                {
                    if (learningAndExamRecord.ErrorsDetected == false)
                    {
                        if (first == true)
                        {
                            Console.WriteLine("Instrument", "Attempt", "Started", "Ended", "State", "Url");
                            first = false;
                        }
                        string line = "";
                        line += learningAndExamRecord.InstrumentName;
                        line += ",";
                        line += learningAndExamRecord.Attempt;
                        line += ",";
                        line += learningAndExamRecord.Started;
                        line += ",";
                        line += learningAndExamRecord.Ended;
                        line += ",";
                        line += learningAndExamRecord.InstrumentState;
                        line += ",";
                        line += learningAndExamRecord.CertificateURL;

                        if (learningAndExamRecord.AssessmentInstrumentID.HasValue)
                        {
                            // if the record is for an Exam/AssessmentInstrument
                        }
                        else if (learningAndExamRecord.LearningInstrumentID.HasValue)
                        {
                            // otherwise we are expecting a learning instrument record
                        }
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine(blipsCertifyInterface.ErrorDetails[0].ErrorMessage);
            }*/
        }
    }
}
